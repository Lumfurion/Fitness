using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        /// Будем использовать список он не безопасен можно его заменить даже если он приватный.
        /// </summary>
        public List<User> Users { get; private set; }
        /// <summary>
        /// Текущий пользователь,для проверки есть такой пользователь.
        /// </summary>
        public User CurrentUser { get; private set; }
        /// <summary>
        /// Проверка являться пользователь новый или получили из приложения.
        /// </summary>
        public bool isNewUser { get; private set; } = false;
        /// <summary>
        /// Имя текущего пользователя.
        /// </summary>
        public static string CurrentUserName { get; set; }

        public string Image
        {
            set
            {
                if (CurrentUser != null)
                {
                    CurrentUser.Image = value;
                    CopyImage(value);
                }
                Save();
            }
            get
            {
                if (!string.IsNullOrEmpty(CurrentUser.Image))
                {
                    return CurrentUser.Image;
                }

                return null;
            }
        }
        /// <summary>
        /// Перемещение файла.
        /// </summary>
        /// <param name="value">Старый путь файла.</param>
        public void CopyImage(string value)
        {
            string directory = @"UserImage\";//Папка.
            string sourceDirectory = value;//старый путь к файлу.
            string targetDirectory = directory + @"\" + $"UserAvatar{CurrentUser.Name}.jpg";//где будет находиться файдл
            string pathImage = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), targetDirectory);//путь к файлу.

            if (!Directory.Exists(directory))//Создание папоки.
            {
                Directory.CreateDirectory(directory);
            }
            //if (File.Exists(targetDirectory))//есть файл
            //{
            //    File.Delete(targetDirectory);
            //    File.Copy(sourceDirectory, targetDirectory);
            //}

            if (!File.Exists(targetDirectory))//Нету файла
            {
                File.Copy(sourceDirectory, targetDirectory);
            }
            CurrentUser.Image = pathImage;
        }

        #endregion
        public UserController()
        {
            Users = GetUsersData();
        }

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
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);//поиск пользователя.
            CurrentUserName = userName;

    
            if (CurrentUser == null)
            {
                isNewUser = true;
            }

        }

        public bool isExist(string userName)
        {
            var isexist = false;
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);//поиск пользователя.
            CurrentUserName = userName;

            if (CurrentUser == null) { }
            else if (CurrentUser != null)
            {
                isexist = true;
            }
            return isexist;
        }


        /// <summary>
        /// Инициализация нового пользователя.
        /// </summary>
        public void SetNewUserData(string password,string genderName, DateTime birthdaydate, double weight, double height)
        {
            #region Проверки.
            if (string.IsNullOrEmpty(genderName))
            {
                throw new ArgumentNullException("Пол пользователя не может быть пустым", nameof(genderName));
            }
            if (birthdaydate < DateTime.Parse("01.01.1900") || birthdaydate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthdaydate));
            }

            if (weight == 0)
            {
                throw new ArgumentException("Вес не может быть 0", nameof(height));
            }
            if (height == 0)
            {
                throw new ArgumentException("Рост не может быть 0", nameof(height));
            }
            #endregion

            if (CurrentUser == null)
            {
                CurrentUser = new User(CurrentUserName,password, new Gender(genderName), birthdaydate, weight, height);
                Users.Add(CurrentUser);//Добавление нового пользователя.
                Save();
            }
      
        }
        



        /// <summary>
        /// Получить сохраненный список пользователей(десериализация).
        /// </summary>
        public List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>(); //?? new List<User>()-праверка нужна потому что default(T) возращает null.
        }
        /// <summary>
        /// Обновляет данные модели.
        /// </summary>
        public void UpDate()
        {
            Users = GetUsersData();
        }

        /// <summary>
        /// Сохранить данные пользователя(Сериализация).
        /// </summary>
        public void Save()
        {
            Save(Users);
        }


    }
}