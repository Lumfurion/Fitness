using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BusinessLogic.Controller
{   /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {   /// <summary>
        /// Пользователь приложения.
        /// Будем использовать список он не безопасен мозно его зменить даже если он приватный.
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool isNewUser { get; } = false;//Проверка являться нопользователь новый или получили из приложения.
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// При вводе пользователь вводит свой логин проверяем в наличии такого  логина в файле,
        /// если файле есть такой пользователь с таким логином подтягиваем его данные
        /// если пользователя нет с таким никнеймом мы получаем данные и добавляем в список всех пользователей.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым",nameof(userName));
            }
            Users =GetUsersData();
            
            //Будем искать пользователя 1 единственным именами,ecли пользователь есть.
            CurrentUser = Users.SingleOrDefault(u=>u.Name==userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);//Добавление нового пользователя.
                isNewUser = true;
                Save();
            }
  
        }
       
        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        public List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (formatter.Deserialize(fs) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                    //throw new FileLoadException("Не удалось получить данные пользователя из файла!", "users.dat");
                }
            }
        }

        public void SetNewUserData(string genderName, DateTime birthdaydate, double weight = 1, double height = 1)
        { //Проверка.
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthdayDate = birthdaydate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void  Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }   
        }
     
    }
}
