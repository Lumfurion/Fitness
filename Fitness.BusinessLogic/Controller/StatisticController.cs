using Fitness.BusinessLogic.Model;
using System.Collections.Generic;
using System.Linq;
namespace Fitness.BusinessLogic.Controller
{   /// <summary>
    ///Класс будет считать сколько калорий пользователь набрал калорий когда питался и метаболизм.
    /// </summary>
    public class StatisticController :ControllerBase
    {   /// <summary>
        /// Контроллер пользователя.
        /// </summary>
        readonly UserController userController;
        /// <summary>
        /// Контроллер программы тренировок.
        /// </summary>
        readonly TrainingController trainingController;
        /// <summary>
        /// Контроллер дневника питания.
        /// </summary>
        readonly FoodDiaryController foodDiaryController;
        /// <summary>
        /// Хранение данных о статистике.
        /// </summary>
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
            //Формула Маффина-Джеора.
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
        /// Тут будет рассчитана статистика для всего.
        /// </summary>
        /// <returns></returns>
        private int Total()
        {   var BMR = СalculateBMR();
            var training = GetSumTraining();
            var FoodDiary = GetSumFoodDiary();
            var total = -(BMR + training) + FoodDiary;
            return (int)total;
        }
        /// <summary>
        /// Будет выполнять расчеты каждый раз при вызове конструктора.
        /// </summary>
        private void init()
        {
            statistics.Clear();
            var login = UserController.CurrentUserName;
            var BMR = СalculateBMR();
            var sumtraining = GetSumTraining();
            var sumFoodDiary = GetSumFoodDiary();
            var total = Total();

            statistics.Add(new Statistic(login, -BMR, -sumtraining, sumFoodDiary, total));
            Save();
            UpDate();

        }
        /// <summary>
        /// Получение статистики для текущего пользователя.
        /// </summary>
        /// <returns></returns>
        public Statistic StatisticObject()
        {
            var login = UserController.CurrentUserName;
            var statistic = statistics.Where(st => st.Login == login).FirstOrDefault();
            return statistic;
        }

        /// <summary>
        /// Обновление данных о статистике.
        /// </summary>
        private void UpDate()
        {
            statistics = GetStatistic();
        }
        /// <summary>
        /// Получение данных из файла статистике.
        /// </summary>
        private List<Statistic> GetStatistic()
        {
            return Load<Statistic>() ?? new List<Statistic>();
        }
        /// <summary>
        /// Сохранение  данных о статистике  в файл.
        /// </summary>
        private void Save()
        {
            Save(statistics);
        }



    }
}
