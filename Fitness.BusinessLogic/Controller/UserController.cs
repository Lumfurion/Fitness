using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Fitness.BusinessLogic.Controller
{   /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
    {
       
        #region Cвойства
        /// <summary>
        /// Пользователь приложения.
        /// Будем использовать список он не безопасен мозно его зменить даже если он приватный.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Текущий пользователь,для проверки есть такой пользователь.
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Проверка являться пользователь новый или получили из приложения.
        /// </summary>
        public bool isNewUser { get; } = false;
        #endregion

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// При вводе пользователь вводит свой логин проверяем в наличии такого  логина в файле,
        /// если файле есть такой пользователь с таким логином подтягиваем его данные
        /// если пользователя нет с таким никнеймом мы получаем данные и добавляем в список всех пользователей.
        /// </summary>
        /// <param name="user">Имя пользователя.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым",nameof(userName));
            }
            Users =GetUsersData();

            //Будем искать пользователя 1 единственным именами,ecли пользователь есть.
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);//Добавление нового пользователя.
                isNewUser = true;
                Save();
            }
  
        }

        /// <summary>
        /// Получить сохраненный список пользователей(десериализация).
        /// </summary>
        public List<User> GetUsersData()
        {   //?? new List<User>()-праверка нужна потому что default(T) возращает null.
            return Load<User>() ?? new List<User>();
        }

        /// <summary>
        /// Инициализация нового пользователя.
        /// </summary>
        public void SetNewUserData(string genderName, DateTime birthdaydate, double weight = 1, double height = 1)
        { //Проверка.
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthdayDate = birthdaydate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя(Сериализация).
        /// </summary>
        public void  Save()
        {
            Save(Users);
        }
     
    }
}
