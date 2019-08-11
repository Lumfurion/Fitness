using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BusinessLogic.Controller
{   /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {   /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName,string genderName,DateTime birthDay,double weight,double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName,gender, birthDay,weight, height);
             
        }

        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {

                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                else
                {
                    throw new FileLoadException("Не удалось получить данные пользователя из файла!", "users.dat");
                }
                //TODO:Сделать сериализацию для n пользователей.

            }

        }


        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void  Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }   
        }
     
        
        /// <summary>
       /// Получить данные пользователя.
       /// </summary>
       /// <returns>
       /// Пользователь приложения.
       /// </returns>
       
    }
}
