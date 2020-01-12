using System.Collections.Generic;
using System.Linq;
using Fitness.BusinessLogic.Model;
using Fitness.BusinessLogic.Services.Initializers;

namespace Fitness.BusinessLogic.Controller
{
    public class FoodDiaryController : ControllerBase
    {
        public List<FoodDiary> FoodDiaries { get; set; }

        /// <summary>
        /// Рекомендуемый днивник приём пищи.
        /// </summary>
        public List<FoodDiary> Recommended { get; set; }
        /// <summary>
        /// Дневник полный узором.
        /// </summary>
        public List<FoodDiary> UserFoodDiary { get; set; }
        private string User { get; set; }
        private string Type { get; set; }
        private TrainingController trainingController { get; set; }

        public FoodDiaryController()
        {   
            FoodDiaries = GetFoodDiary();
            User = UserController.CurrentUserName;
            trainingController = new TrainingController();
            Recommended = new List<FoodDiary>();
            UserFoodDiary = new List<FoodDiary>();
            SetRecommended();
            SetFoodDiaryCurrentUser();
        }

       

        /// <summary>
        /// Шаблон который пользователь будет заполнять продуктами.
        /// </summary>
        public void SetFoodDiaryTemplate()
        {
            List<Eating> Eating = new List<Eating>()
            {
              new Eating("Завтрак",new Dictionary<Food, double>()),
              new Eating("Обед",new Dictionary<Food, double>()),
              new Eating("Ужин",new Dictionary<Food, double>())
            };
            var isSuch = FoodDiaries.Any(fd => fd.Name == User);//Проверка есть ли в пользователя шаблон.
            if (isSuch == false)
            {
                FoodDiaries.Add(new FoodDiary(User, Type, Eating));
            }

        }

        public void SetFoodDiaryCurrentUser()
        {
            var foodDiary = FoodDiaries.Where(fd => fd.Name == User).FirstOrDefault();
            UserFoodDiary.Add(foodDiary);
        }

        /// <summary>
        /// Рекомендованные для тренировки.
        /// </summary>
        /// <returns></returns>
        public void SetRecommended()
        {
           Type = trainingController.GetTypeSelectTraining();
           var foodDiary = InitializingFoodDiary.GetFoodDiary(Type);

            if(foodDiary != null)
            {
                Type = foodDiary.Traning;
                var Eatings = foodDiary.Eatings;
                FoodDiary  food= new FoodDiary(User, Type, Eatings);
                Recommended.Add(food);
            }
            SetFoodDiaryTemplate();
        }

        /// <summary>
        ///Добавление еды в дневник питания.
        /// </summary>
        /// <param name="name">Имя еды</param>
        /// <param name="eating">Вреня приема пищи(например:обед)</param>
        public void Add(string name, string eating)
        {
            var foodDiary = FoodDiaries.Where(fd => fd.Name == User).FirstOrDefault();
            var IndeхfoodDiary = FoodDiaries.FindIndex(fd => fd.Name == User);
            var IndeхEating = foodDiary.FoundEatingIndeх(eating);

            var product = InitializingFoods.GetFood(name);
            FoodDiaries[IndeхfoodDiary].Eatings[IndeхEating].Add(product.Key, product.Value);
            Save();
            Update();
        }

        public void Update()
        {
            FoodDiaries.Clear();
            UserFoodDiary.Clear();
            FoodDiaries = GetFoodDiary();
            SetFoodDiaryCurrentUser();
        }

        private List<FoodDiary>  GetFoodDiary()
        {
            return Load<FoodDiary>() ?? new List<FoodDiary>();
        }

        private void Save()
        {
            Save(FoodDiaries);
        }

    }
}
