using System.Collections.Generic;
using Fitness.BusinessLogic.Model;

namespace Fitness.BusinessLogic.Services.Initializers
{
    static class InitializingFoodDiary
    {
        readonly static List<FoodDiary> FoodDiaries;

        static  InitializingFoodDiary()
        {
            FoodDiaries = InitFoodDiary();
        }

        private static List<FoodDiary> InitFoodDiary()
        {
            var foodDiaries = new List<FoodDiary>();
            Eating eating1 = new Eating();
            eating1.Add(new Food("Молоко", 60, 3, 3, 6, 28), 100);
            eating1.Add(new Food("Чай", 204, 31, 6, 4, 50), 100);
            foodDiaries.Add(new FoodDiary(eating1));

            return foodDiaries;
        }
    }
}
