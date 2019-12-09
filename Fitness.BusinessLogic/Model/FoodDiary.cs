using System;
namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Днивник питания
    /// </summary> 
    [Serializable]
    public class FoodDiary
    {
        public string Name { get; set; }
        public Eating Eating { get; set; }
        public string Traning { get; set; }

        public FoodDiary(){}

        public FoodDiary(Eating eating)
        {
            Eating = eating;
        }

        public FoodDiary(Eating eating, string traning)
        {
            Eating = eating;
            Traning = traning;
        }

        public FoodDiary(string name, Eating eating, string traning)
        {
            Name = name;
            Eating = eating;
            Traning = traning;
        }

        public void Add(Food food, double count)
        {
            Eating.Add(food, count);
        }
        
        public void Delete(Food food)
        {
            Eating.Delete(food);
        }

    }
}
