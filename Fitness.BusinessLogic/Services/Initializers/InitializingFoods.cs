using Fitness.BusinessLogic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Services.Initializers
{
    public static class InitializingFoods
    {
        /// <summary>
        /// 
        /// </summary>
        public static Dictionary<Food, double> Foods { get; set; }
        

        static InitializingFoods ()
        {
            InitFoods();  
        }
        /// <summary>
        /// Вернет заполнений прием еды и заполнит.
        /// </summary>
        private static void InitFoods()
        {
            Foods = new Dictionary<Food, double>();
            Add(new Food("Каша овсяная на воде со сливочным маслом", 132, 6, 2, 25), 100);
            Add(new Food("Чай черный без сахара", 0, 0, 0, 0), 100);
            Add(new Food("Зефир", 317, 1.2, 0, 78), 100);
            Add(new Food("Кефир 1% жирности", 41, 3.5, 1, 4.5), 100);
            Add(new Food("Яблоки", 46, 0.4, 0, 11.2), 100);
            Add(new Food("Рыба жирная в соевом с. припущенная без масла", 200, 18, 15, 0), 100);
            Add(new Food("Рис бурый без масла", 109, 3, 0.5, 23), 100);
            Add(new Food("Творог обезжиренный", 94, 18, 1, 3.3), 100);
            Add(new Food("Хлебцы отрубные", 320, 9, 2, 66), 100);
            Add(new Food("Апельсин", 37, 0.8, 0, 8.5), 100);
            Add(new Food("Куриная грудка, запеченная с овощами", 75, 8, 3, 75), 100);
            Add(new Food("Салат из огурцов,помидоров,зелени, с соком лимона", 14, 1, 0, 2.5), 100);
            Add(new Food("Чай зеленый с молоком без сахара", 26, 1.4, 1.3, 2.4), 100);

        }

        /// <summary>
        /// Получение еды и день в который съели еду.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static KeyValuePair<Food, double> GetFood(string name)
        {
            var poduct = Foods.Where(f => f.Key.Name == name).FirstOrDefault();
            return poduct;
        }
        /// <summary>
        /// Добавления еды.
        /// </summary>
        /// <param name="food"></param>
        /// <param name="count"></param>
        private static void Add(Food food, double count)
        {  //Есть такой в списке продукт.
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, count);
            }
            else
            {   //Получаем значения,мы не добавляем еду а увеличиваем количество еды.
                //Если пользователь ел такое увеличить счет еды.

                Foods[product] += count;
            }
        }

    }
}
