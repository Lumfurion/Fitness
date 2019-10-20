using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Model
{  /// <summary>
   /// Прием пищи.Будем фиксировать кто поел что поел когда поел.
   /// </summary>
    [Serializable]
    public class Eating
    {
        #region Cвойство
      
        /// <summary>
        /// Момент приема пищи.
        /// </summary>
        public DateTime Moment { get; set; }
        /// <summary>
        /// Список еды и сколько сел пользователь еды.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }
 
        #endregion
        public Eating()
        {
            Moment = DateTime.UtcNow;//если приложение мультиязычное, то время нужно utcnow
            Foods = new Dictionary<Food,double>();
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
 
   }
}
