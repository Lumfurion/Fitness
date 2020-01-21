using Fitness.BusinessLogic.Model;
using System.Collections.Generic;
using System.Linq;
namespace Fitness.BusinessLogic.Controller
{   /// <summary>
    ///
    /// </summary>
    public class StatisticController :ControllerBase
    {
        readonly UserController userController;
        readonly TrainingController trainingController;
        readonly FoodDiaryController foodDiaryController;
        public List<Statistic> statistics { private set;  get; }

        public StatisticController()
        {
           
            userController = new UserController(UserController.CurrentUserName);
            trainingController = new TrainingController();
            foodDiaryController = new FoodDiaryController();
            statistics = GetStatistic();
            init();

        }
        /// <summary>
        /// Подсчет суммы сжигаемых калорий упражнений.
        /// </summary>
        private double GetSumTraining()
        {
            var sum = 0.00;
            var program = trainingController.SelectProgram();

            foreach (var v  in program.Values)
                foreach (var ex in v)
                sum += ex.CaloriesPerMinute;

            return sum;
        }
        /// <summary>
        /// Сколько набрано калорий в дневнике питания.
        /// </summary>
        private double GetSumFoodDiary()
        {
            var login = UserController.CurrentUserName;
            var sum = 0.00;
            var foodDiary = foodDiaryController.UserFoodDiary.Where(t => t.Name == login).FirstOrDefault();
            var Eatings = foodDiary.Eatings;
          
            foreach (var eating in Eatings)
               foreach (var food in eating.Foods)
                   sum += food.Key.Calories;
            
            return sum;
        }
        /// <summary>
        /// Расчет BMR(Уровень базального метаболизма)-это измерение энергетического расхода(ккал) организма в состоянии покоя.
        /// </summary>
        /// <returns></returns>
        private int СalculateBMR()
        {
            var user = userController.CurrentUser;
            var result = 0;
            var weight = user.Weight;
            var height = user.Height;
            var age = user.Age;
            var gender = user.Gender;

            var BMRMAN =  (10 * weight) + (6.25 * height) - (5 * age + 5);
            var BMRGirl = (10 * weight) + (6.25 * height) - (5 * age - 161);

            if (gender.Name == "Мужчина")
            {
                result = (int)BMRMAN;
            }
            else if (gender.Name == "Женщина")
            {
                result = (int)BMRGirl;
            }


            return result;
        }
        /// <summary>
        /// Итог всего
        /// </summary>
        /// <returns></returns>
        private int Total()
        {   var BMR = СalculateBMR();
            var training = GetSumTraining();
            var FoodDiary = GetSumFoodDiary();
            var total = -(BMR + training) + FoodDiary;
            return (int)total;
        }

        private void init()
        {
            statistics.Clear();
            var login = UserController.CurrentUserName;
            var BMR = СalculateBMR();
            var sumtraining = GetSumTraining();
            var sumFoodDiary = GetSumFoodDiary();
            var total = Total();

            statistics.Add(new Statistic(login, BMR, sumtraining, sumFoodDiary, total));
            Save();
            UpDate();

            //var isSuch = statistics.Any(statistic => statistic.Login == login);
          
            //if (isSuch == false)
            //{
            //    statistics.Add(new Statistic(login, BMR, sumtraining, sumFoodDiary, total));
            //    Save();
            //    UpDate();
            //}
        }

        public Statistic StatisticObject()
        {
            var login = UserController.CurrentUserName;
            var statistic = statistics.Where(st => st.Login == login).FirstOrDefault();
            return statistic;
        }


        private void UpDate()
        {
            statistics = GetStatistic();
        }

        private List<Statistic> GetStatistic()
        {
            return Load<Statistic>() ?? new List<Statistic>();
        }

        private void Save()
        {
            Save(statistics);
        }



    }
}
