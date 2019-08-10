using System;
namespace Fitness.BusinessLogic.Model
{ /// <summary>
  /// Пользователь.
  /// </summary>
    public class User
    {
        #region Cвойства.
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthdayDate { get; }
        /// <summary>
        ///Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        #endregion 


        /// <summary>
        /// Создать  нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthdayDate">Дата раждения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name,Gender gender,DateTime birthdayDate, double weight,double height)
        {
            #region Проверка условий.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может  быть пустым или null.", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Пол нк может быть null.", nameof(gender));
            }
            //birthdayDate >= DateTime.Now-дата быть определенных датах.
            if(birthdayDate < DateTime.Parse("01.01.1900") || birthdayDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthdayDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше нуля и равен нулю.", nameof(weight));
            }

            if(height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше нуля и равен нулю.", nameof(height));
            }
            #endregion 
            Name = name;
            Gender = gender;
            BirthdayDate = birthdayDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
