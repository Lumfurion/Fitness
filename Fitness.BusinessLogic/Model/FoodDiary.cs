using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Днивник приёма пищи.
    /// </summary> 
    [Serializable]
    public class FoodDiary
    {
        private List<Eating> eating;

        /// <summary>
        ///Имя пользователя. 
        /// </summary>
        public string Name { get; set; }
        public List<Eating> Eatings { get; set; }
        public string Traning { get; set; }

        public FoodDiary(){}

        public FoodDiary(List<Eating> eating)
        {
            this.eating = eating;
        }

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

        public Eating FoundEating(string name)
        {
            var eating = Eatings.Where(ea=>ea.EatingTime == name).FirstOrDefault();
            return eating;
        }
        public int FoundEatingIndeх(string name)
        {
            var Index = Eatings.FindIndex(ea => ea.EatingTime == name);
            return Index;
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
