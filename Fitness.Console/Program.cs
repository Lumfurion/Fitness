using Fitness.BusinessLogic.Controller;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Вас приветствует приложение Fitness Сlub Sparta");
            Console.WriteLine("Введте имя пользователя:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите пол:");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату раждения:");
            var birhday = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите вес:");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите рост:");
            var height = double.Parse(Console.ReadLine());


            var userController = new UserController(name,gender,birhday,weight,height);
            userController.Save();

            Console.Read();
        }
    }
}
