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

        public virtual ICollection<Exercise> Exercises { get; set; }

        /// <summary>
        /// Количество калорий сжигаемых в единицу времени
        /// </summary>
        public double CaloriesPerMinute  { get; set; }
        public Activity() { }
        public Activity(string name, double caloriesPerMinute)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может  быть пустым или null.", nameof(name));
            }
            if (caloriesPerMinute <= 0)
            {
                throw new ArgumentException("Имя пользователя не может  быть  нулем.", nameof(name));
            }
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
