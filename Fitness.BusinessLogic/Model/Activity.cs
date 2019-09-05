using System;
using System.Collections.Generic;

namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Активность
    /// </summary>
    [Serializable]
    public class Activity
    {   
        public int Id { get; set; }
        
        /// <summary>
        /// Название вида активности.
        /// </summary>
        public string Name { get; set; }

        //public virtual ICollection<Exercise> Exercises { get; set; }

        /// <summary>
        /// Количество калорий сжигаемых в единицу времени
        /// </summary>
        public double CaloriesPerMinute  { get; set; }
        public Activity() { }
        public Activity(string name, double caloriesPerMinute)
        {   //Проверка
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
