using System;
namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Активность
    /// </summary>
    [Serializable]
    public class Activity
    {   /// <summary>
        /// Название вида активности.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Количество калорий сжигаемых в единицу времени
        /// </summary>
        public double CaloriesPerMinute  { get; }

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
