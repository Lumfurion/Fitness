using Fitness.BusinessLogic.Controller;
using System;

namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Упражнения
    /// </summary>
    [Serializable]
    public class Exercise
    {
        #region Cвойства

        /// <summary>
        /// Какого прльзователя упражнения
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Тип тренировки.
        /// </summary>
        public  string Type { get; set; }

        /// <summary>
        /// Название вида активности.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Количество калорий сжигаемых в единицу времени
        /// </summary>
        public double CaloriesPerMinute { get; set; }

      
        /// <summary>
        /// Изображение активности
        /// </summary>
        public string Image { get; set; }
       
       /// <summary>
       /// Количество раз.
       /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Количество подходов.
        /// </summary>
        public int Сount { get; set; }
        /// <summary>
        /// Обозначение
        /// </summary>
        public string Designation { get; set; }

      
        #endregion

        public Exercise() { }
        public Exercise(string name, double caloriesPerMinute, string image, int amount, int count,string designation)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
            Image = image;
            Сount = count;
            Amount = amount;
            Designation = designation;
            Username = UserController.CurrentUserName;
            Type = TrainingController.Type;

        }
    }
}
