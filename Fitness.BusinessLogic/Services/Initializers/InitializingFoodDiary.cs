using System.Collections.Generic;
using System.Linq;
using Fitness.BusinessLogic.Model;

namespace Fitness.BusinessLogic.Services.Initializers
{
    public static class InitializingFoodDiary
    {
        static readonly List<FoodDiary> FoodDiaries;

        static  InitializingFoodDiary()
        {
            FoodDiaries = InitFoodDiary();
        }

        private static List<FoodDiary> InitFoodDiary()
        {
            var foodDiaries = new List<FoodDiary>();

            var DicBreakfast = new Dictionary<Food, double>();
            DicBreakfast.Add(new Food("Каша овсяная на воде со сливочным маслом", 132, 6, 2, 25),100);
            DicBreakfast.Add(new Food("Чай черный без сахара", 0, 0, 0, 0),100);
            DicBreakfast.Add(new Food("Зефир", 317, 1.2, 0, 78),100);

            var DicFristSnack = new Dictionary<Food, double>();
            DicFristSnack.Add(new Food("Кефир 1% жирности",41,3.5,1,4.5), 100);
            DicFristSnack.Add(new Food("Яблоки", 46,0.4,0,11.2), 100);

            var Diclunch = new Dictionary<Food, double>();
            Diclunch.Add(new Food("Рыба жирная в соевом с. припущенная без масла",200,18,15,0),100);
            Diclunch.Add(new Food("Рис бурый без масла", 109,3,0.5,23), 100);
            Diclunch.Add(new Food("Чай зеленый без сахара", 0, 0, 0, 0), 100);


            var SecondSnack = new Dictionary<Food, double>();
            SecondSnack.Add(new Food("Творог обезжиренный",94,18,1,3.3), 100);
            SecondSnack.Add(new Food("Хлебцы отрубные", 320,9,2,66), 100);
            SecondSnack.Add(new Food("Апельсин",37,0.8,0,8.5), 100);

            var DicDinner = new Dictionary<Food, double>();
            DicDinner.Add(new Food("Куриная грудка, запеченная с овощами",75,8,3,75), 100);
            DicDinner.Add(new Food("Салат из огурцов,помидоров,зелени, с соком лимона", 14,1,0,2.5), 100);
            DicDinner.Add(new Food("Чай зеленый с молоком без сахара",26,1.4,1.3,2.4), 100);

            List<Eating> Eating1 = new List<Eating>()
            {
              new Eating("Завтрак",DicBreakfast),
              new Eating("Первый перекус",DicFristSnack),
              new Eating("Обед",Diclunch),
              new Eating("Второй перекус",SecondSnack),
              new Eating("Ужин",DicDinner)

            };

            foodDiaries.Add(new FoodDiary(Eating1, "Похудения для девушек"));

            return foodDiaries;
        }

        public static List<FoodDiary> GetFoodDiaries()=> FoodDiaries;

        public static FoodDiary GetFoodDiary(string type)
        {
            var FoodDiary = FoodDiaries.Where(f => f.Traning == type).FirstOrDefault();
            return FoodDiary;
        }

    }
}
