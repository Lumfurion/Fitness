using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Model
{  /// <summary>
   /// Прием пищи.
   /// </summary>
    [Serializable]
    public class Eating
    {
        #region Свойства

        /// <summary>
        /// Прием пищи когда в Обед,Ужин.
        /// </summary>
        public string EatingTime { get; set;}
      
        /// <summary>
        /// Список еды и сколько сел пользователь еды в грамах.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }
 
        #endregion
        public Eating(){}

        public Eating(string eatingTime, Dictionary<Food, double> foods)
        {
            EatingTime = eatingTime;
            Foods = foods;
        }

        public void Add(Food food,double count)
        {  //Есть такой в списке продукт.
            var product=Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, count);
            }
            else
            {   //Получаем значения,мы не добавляем еду а увеличиваем количество еды.
                //Если пользователь ел такое увеличить счет еды.
               
                Foods[product] += count;
            }
        }


        public void Delete(Food food)
        {  
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product != null)
            {
                Foods.Remove(food);
            }
           
        }

    }
}
