using System.Collections.Generic;
using Fitness.BusinessLogic.Model;
using Fitness.BusinessLogic.Services.Initializers;

namespace Fitness.BusinessLogic.Controller
{
    public class FoodDiaryController : ControllerBase
    {
        public List<FoodDiary> FoodDiaries { get; set; }

        /// <summary>
        /// Рекомендуемый приём пищи.
        /// </summary>
        public FoodDiary Recommended { get; set; }
        private string User { get; set; }
        private string Type { get; set; }
        private TrainingController trainingController { get; set; }

        public FoodDiaryController()
        {
            FoodDiaries = GetFoodDiary();
            User = UserController.CurrentUserName;
            trainingController = new TrainingController();
            

        }

       


        public FoodDiary SetRecommended()
        {
           Type = trainingController.GetTypeSelectTraining();
           var foodDiary = InitializingFoodDiary.GetFoodDiary(Type);

            if(foodDiary != null)
            {
                var Type = foodDiary.Traning;
                var Eatings = foodDiary.Eatings;
                Recommended= new FoodDiary(User, Type, Eatings);
                return Recommended;
            }

            return null;
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
