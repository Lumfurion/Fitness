using System;

namespace Fitness.BusinessLogic.Model
{  /// <summary>
   /// Класс Food(продукт питания) будет хранить меню еды и сколько в еде:
   /// белков,жеров,углевов,калорий.
   /// </summary>
    [Serializable]
    public class Food
    {
        #region Свойства
        /// <summary>
        ///имя еды.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }


        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }



        /// <summary>
        /// Жирность
        /// </summary>
        public double Fat { get; set; }
        #endregion


        public Food() { }

        /// <summary>
        /// Получения продукта по имени.
        /// </summary>
        public Food(string name) : this(name, 0, 0, 0, 0,0) { }

        public Food(string name, double calories, double proteins, double fats, double carbohydrates, double fat)
        {
            Name = name;
            Calories = calories;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Fat = fat;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
