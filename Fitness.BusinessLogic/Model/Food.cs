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
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }
        public double Pats { get; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; }
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
        /// <summary>
        /// Получения продукта по имени.
        /// </summary>
        public Food(string name) : this(name, 0, 0, 0, 0) { }
       
        /// <summary>
        /// Будет принимать максимальное количество параметров.
        /// </summary>
        public Food(string name,double proteins, double pats,double carbohydrates, double calories)
        {   //TODO: проверки
            Name = name;
            Proteins = proteins / 100.0;
            Pats = pats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
