using System;
using System.Collections.Generic;

namespace Fitness.BusinessLogic.Model
{ /// <summary>
  /// Пользователь.
  /// </summary>
    [Serializable]//Указуем что будем сериализовать.
    public class User
    {
        #region Cвойства.
        public int Id { get; set; }
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthdayDate { get; set; }
        /// <summary>
        ///Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        public virtual ICollection<Eating> Eatings { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public int Age { get { return DateTime.Now.Year - BirthdayDate.Year; }}
        #endregion
        public User() { }

        /// <summary>
        /// Создать  нового пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="gender">Пол.</param>
        /// <param name="birthdayDate">Дата раждения.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name ,string password,Gender gender,DateTime birthdayDate, double weight,double height)
        {
            #region Проверка условий.
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может  быть пустым или null.", nameof(name));
            }

            if(gender == null)
            {
                throw new ArgumentNullException("Пол может быть null.", nameof(gender));
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
            Password = password;
            Gender = gender;
            BirthdayDate = birthdayDate;
            Weight = weight;
            Height = height;
        }
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может  быть пустым или null.", nameof(name));
            }
            Name = name;
        }


        public override string ToString()
        {
            return Name + " " + Password + " " + Age + " " + Gender + " " + BirthdayDate.ToString("D") + " " + Weight + " " + Height;
        }

    }
}
