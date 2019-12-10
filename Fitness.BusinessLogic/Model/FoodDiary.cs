using System;
using System.Collections.Generic;

namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Днивник приёма пищи.
    /// </summary> 
    [Serializable]
    public class FoodDiary
    {
        public string Name { get; set; }
        public List<Eating> Eatings { get; set; }
        public string Traning { get; set; }

        public FoodDiary(){}

        public FoodDiary(List<Eating> eatings, string traning)
        {
            Eatings = eatings;
            Traning = traning;
        }

        public FoodDiary(string name, List<Eating> eatings, string traning)
        {
            Name = name;
            Eatings = eatings;
            Traning = traning;
        }

        //public void Add(Food food, double count)
        //{
        //    Eating.Add(food, count);
        //}
        
        //public void Delete(Food food)
        //{
        //    Eating.Delete(food);
        //}

    }
}
