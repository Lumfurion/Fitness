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
        public List<User> Users { get; }
        /// <summary>
        /// Текущий пользователь,для проверки есть такой пользователь.
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Проверка являться пользователь новый или получили из приложения.
        /// </summary>
        public bool isNewUser { get; } = false;

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

            //Будем искать пользователя 1 единственным именами,ecли пользователь есть.
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            CurrentUserName = userName;

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);//Добавление нового пользователя.
                isNewUser = true;
                Save();
            }

        }



        /// <summary>
        /// Инициализация нового пользователя.
        /// </summary>
        public void SetNewUserData(string genderName, string password, DateTime birthdaydate, double weight, double height)
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
            CurrentUser.Password = password;
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthdayDate = birthdaydate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Перемещение файла.
        /// </summary>
        /// <param name="value">Старый путь файла.</param>
        public void CopyImage(string value)
        {
            string directory = @"UserImage\" + CurrentUser.Name;
            string sourceDirectory = value;
            string targetDirectory = directory + @"\" + $"UserAvatar{CurrentUser.Name}.jpg";
            string pathImage = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), targetDirectory); ;

            if (File.Exists(pathImage))
            {
                int n = CurrentUser.Imagecount++;
                targetDirectory = directory + @"\" + $"UserAvatar{n + CurrentUser.Name}.jpg";

            }

            if (!Directory.Exists(directory))//Создание папок.
            {
                Directory.CreateDirectory(directory);
            }


            if (!File.Exists(targetDirectory))//Нету файла
            {
                File.Copy(sourceDirectory, targetDirectory);
            }
            pathImage = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), targetDirectory);
            CurrentUser.Image = pathImage;

        }



        /// <summary>
        /// Получить сохраненный список пользователей(десериализация).
        /// </summary>
        public List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>(); //?? new List<User>()-праверка нужна потому что default(T) возращает null.
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