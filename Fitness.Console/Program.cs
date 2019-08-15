using Fitness.BusinessLogic.Controller;
using System;

namespace Fitness.CMD
{
    class Program
    {   /// <summary>
        /// Проверка преобразования в double.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static double ParseDauble(string name)
        {
            while (true)
            {
                Console.WriteLine($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}!");
                }
            }
        }

        private static DateTime ParseDateTime()
        {
            DateTime birtdayDate;
            while (true)
            {
                Console.WriteLine("Введите дату раждения(dd.MM.yyyy):");

                // Преобразовывает указанное строковое представление даты и времени в его эквивалент
                // System.DateTime и возвращает значение, позволяющее определить успешность преобразования.
                if (DateTime.TryParse(Console.ReadLine(), out birtdayDate))
                { //var birhday = DateTime.Parse(Console.ReadLine());
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }

            return birtdayDate;
        }

        static void Main()
        {
            Console.WriteLine("Вас приветствует приложение Fitness Сlub Sparta");
            Console.WriteLine("Введте имя пользователя:");
            var name = Console.ReadLine(); 

            var userController = new UserController(name);

            if (userController.isNewUser == true)
            {
                Console.WriteLine("Введите пол:");
                var gender = Console.ReadLine();
                var birtdayDate = ParseDateTime();
                var weight = ParseDauble("вес");
                var height = ParseDauble("рост");

                userController.SetNewUserData(gender, birtdayDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            //userController.Save();

            Console.Read();
        }

       
    }
}
