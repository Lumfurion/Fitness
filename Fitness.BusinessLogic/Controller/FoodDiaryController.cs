using System;
using System.Collections.Generic;
using System.Linq;
using Fitness.BusinessLogic.Model;
using Fitness.BusinessLogic.Services.Initializers;

namespace Fitness.BusinessLogic.Controller
{    /// <summary>
     /// Дневник питания -позволяет пользователю каждой тренировки составить дневник питания или выбрать готовый  дневник питания.
     /// </summary>
    public class FoodDiaryController : ControllerBase
    {  /// <summary>
       ///Все дневники питания.
       /// </summary>
        public List<FoodDiary> FoodDiaries { get; set; }

        /// <summary>
        /// Рекомендуемый днивник приём пищи.
        /// </summary>
        public List<FoodDiary> Recommended { get; set; }
        /// <summary>
        /// Днивник приём пищи созданный пользователем.
        /// Для удобности привязки список. 
        /// </summary>
        public List<FoodDiary> UserFoodDiary { get; set; }
        private string User { get; set; }
        private string Type { get; set; }
        private TrainingController trainingController { get; set; }

        public FoodDiaryController()
        {
            trainingController = new TrainingController();
            Recommended = new List<FoodDiary>();
            UserFoodDiary = new List<FoodDiary>();

            FoodDiaries = GetFoodDiary();
            User = UserController.CurrentUserName;
            Type = trainingController.GetTypeSelectTraining();

   
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
            var isSuch = FoodDiaries.Any(fd => fd.Name == User && fd.Traning == Type);//Проверка есть ли в пользователя шаблон.
            if (isSuch == false)
            {
                FoodDiaries.Add(new FoodDiary(User, Type, Eating));
            }

        }
        /// <summary>
        /// Добавление рекомендованный прием пищи. 
        /// </summary>
        public void InitTemplateRecommended()
        {
            var IndeхfoodDiary = FoodDiaries.FindIndex(fd => fd.Name == User && fd.Traning == Type);

            if (Recommended.Count != 0 )//если данной тренировки рекомендованный дневник приема пищи.
            {   
                var rec = Recommended.Where(r => r.Traning == Type).FirstOrDefault();//получение по типу тренировки и дневник питания.
                FoodDiaries.RemoveAt(IndeхfoodDiary);//Удаление предыдущего дневник питания.
                FoodDiaries.Add(rec);
                Save();
            }
        }
        /// <summary>
        /// Дневник питания текущего пользователя.
        /// </summary>
        public void SetFoodDiaryCurrentUser()
        {
            var foodDiary = FoodDiaries.Where(fd => fd.Name == User && fd.Traning  == Type).FirstOrDefault();
            if (foodDiary != null)
            {
                UserFoodDiary.Add(foodDiary);
            }
            else
            {
                throw new ArgumentException("Нету дневника питания");
            }
           
        }

        /// <summary>
        /// Рекомендованные для тренировки.
        /// </summary>
        private void SetRecommended()
        {
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
            var foodDiary = FoodDiaries.Where(fd => fd.Name == User && fd.Traning == Type).FirstOrDefault();
            var IndeхfoodDiary = FoodDiaries.FindIndex(fd => fd.Name == User && fd.Traning == Type);
            var IndeхEating = foodDiary.FindEatingIndeх(eating);

            var product = InitializingFoods.GetFood(name);
            FoodDiaries[IndeхfoodDiary].Eatings[IndeхEating].Add(product.Key, product.Value);
            Save();
            Update();
        }

        /// <summary>
        /// Удаление еды из дневника питания.
        /// </summary>
        /// <param name="name">Имя еды</param>
        /// <param name="eating">Вреня приема пищи(например:обед)</param>
        public void Delete(string name, string eating)
        {
            var foodDiary = FoodDiaries.Where(fd => fd.Name == User && fd.Traning == Type).FirstOrDefault();
            var IndeхfoodDiary = FoodDiaries.FindIndex(fd => fd.Name == User && fd.Traning == Type);
            var IndeхEating = foodDiary.FindEatingIndeх(eating);

            var product = foodDiary.Eatings[IndeхEating].Foods.Where(f => f.Key.Name == name).FirstOrDefault();
            var food = product.Key;
            FoodDiaries[IndeхfoodDiary].Eatings[IndeхEating].Delete(food);
            Save();
            Update();
        }

        /// <summary>
        ///Замена еды в дневнике питания.
        /// </summary>
        /// <param name="name">Имя еды</param>
        /// <param name="replace">На что будем менять</param>
        /// <param name="eating">Вреня приема пищи(например:обед)</param>
        public void Replacement(string name,string replace, string eating)
        {
            var foodDiary = FoodDiaries.Where(fd => fd.Name == User && fd.Traning == Type).FirstOrDefault();
            var IndeхfoodDiary = FoodDiaries.FindIndex(fd => fd.Name == User && fd.Traning == Type);
            var IndeхEating = foodDiary.FindEatingIndeх(eating);

            var rep = InitializingFoods.GetFood(replace);
           

            foreach(var i in FoodDiaries[IndeхfoodDiary].Eatings[IndeхEating].Foods)
            {  
                if(i.Key.Name == name)
                {
                    FoodDiaries[IndeхfoodDiary].Eatings[IndeхEating].Foods.Remove(i.Key);
                    FoodDiaries[IndeхfoodDiary].Eatings[IndeхEating].Add(rep.Key,rep.Value);
                    break;
                }
            }
            
            Save();
            Update();
        }


        /// <summary>
        /// Обновление данных.
        /// </summary>
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
