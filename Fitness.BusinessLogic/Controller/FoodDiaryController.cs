using System.Collections.Generic;
using Fitness.BusinessLogic.Model;

namespace Fitness.BusinessLogic.Controller
{
    public class FoodDiaryController : ControllerBase
    {
        public List<FoodDiary> FoodDiaries { get; set; }
        public string User { get; set; }
       
        public FoodDiaryController()
        {
            FoodDiaries = GetFoodDiary();
            User = UserController.CurrentUserName;
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
