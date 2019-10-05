using System;
using System.Collections.Generic;

namespace Fitness.BusinessLogic.Model
{  /// <summary>
   /// Класс Food(продукт питания) будет хранить меню еды и сколько в еде:
   /// белков,жеров,углевов,калорий.
   /// </summary>
    [Serializable]
    public class Food
    {
        #region Свойства
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }
        public double Pats { get; set; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; set; }
        /// <summary>
        /// Калории за 100 грамм продукта.
        /// </summary>
        private double CalloriesOneGramm { get { return Calories / 100.0;} }
        /// <summary>
        /// Протеинов за 100 грамм продукта.
        /// </summary>
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }

        /// <summary>
        ///Жиров  за 100 грамм продукта.
        /// </summary>
        private double FatsOneGramm { get { return Fats / 100.0; } }
        /// <summary>
        ///Угливодов  за 100 грамм продукта.
        /// </summary>
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }
        #endregion
        public virtual ICollection<Eating> Eatings { get; set; }

        public Food() { }

        /// <summary>
        /// Получения продукта по имени.
        /// </summary>

        public Food(string name) : this(name, 0, 0, 0, 0) { }
       
        /// <summary>
        /// Будет принимать максимальное количество параметров.
        /// </summary>
        public Food(string name,double proteins, double fats,double carbohydrates, double calories)
        {
            #region Проверки
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя еды не может  быть пустым или null.", nameof(name));
            }

            if (proteins <= 0)
            {
                throw new ArgumentException("Белков не может быть ноль.", nameof(proteins));
            }
            if (fats <= 0)
            {
                throw new ArgumentException("Жиры не может быть нулем.", nameof(fats));
            }

            if (carbohydrates <= 0)
            {
                throw new ArgumentException("Жиры не может быть нулем.", nameof(carbohydrates));
            }

            if (calories <= 0)
            {
                throw new ArgumentException("Жиры не может быть нулем.", nameof(calories));
            }
            #endregion
            Name = name;
            Proteins = proteins / 100.0;
            Pats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
