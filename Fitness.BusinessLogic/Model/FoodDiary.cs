using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Дневник питания
    /// </summary> 
    [Serializable]
    public class FoodDiary
    {
        /// <summary>
        ///Имя пользователя. 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тренировка.
        /// </summary>
        public string Traning { get; set; }

        /// <summary>
        /// Прием пищи.
        /// </summary>
        public List<Eating> Eatings { get; set; }
       
        public FoodDiary(){}

        public FoodDiary(List<Eating> eatings, string traning)
        {
            Eatings = eatings;
            Traning = traning;
        }

        public FoodDiary(string name,string traning, List<Eating> eatings)
        {
            Name = name;
            Traning = traning;
            Eatings = eatings;   
        }

        /// <summary>
        /// Получение объекта приема пищи.
        /// </summary>
        /// <param name="name">Прием пищи когда в Обед,Ужин.</param>
        public Eating FindEating(string name)
        {
            var eating = Eatings.Where(ea=>ea.EatingTime == name).FirstOrDefault();
            return eating;
        }

        /// <summary>
        /// В какое время прием пищи находим индекс.
        /// </summary>
        /// <param name="name">Прием пищи когда в Обед,Ужин.</param>
        public int FindEatingIndeх(string name)
        {
            var Index = Eatings.FindIndex(ea => ea.EatingTime == name);
            return Index;
        }
       
    }
}
