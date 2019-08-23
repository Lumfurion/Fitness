﻿using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Model;
using System;

namespace Fitness.CMD
{
    class Program
    {   /// <summary>
        /// Проверка преобразования в double.
        /// </summary>
        private static double ParseDauble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}!");
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
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }

            return birtdayDate;
        }
        /// <summary>
        /// (Food Food,double Weight)-картежи.
        /// картежи-набор значеный.
        /// </summary>
        private static (Food Food,double Weight) EnterEating()
        {  
            Console.Write("Введите имя продукта:");
            var food = Console.ReadLine();
            var weight = ParseDauble("вес порции");
            var fats = ParseDauble("жиры");
            var proteins = ParseDauble("протеины");
            var carbohydrates = ParseDauble("углеводы");
            var calories = ParseDauble("калорийность");

            var product = new Food(food, proteins, fats, carbohydrates, calories);

            return (Food:product, Weight:weight);
        }

        static void Main()
        {
            Console.WriteLine("Вас приветствует приложение Fitness Сlub Sparta");
            Console.WriteLine("Введте имя пользователя:");
            var name = Console.ReadLine(); 

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

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

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();

            if (key.Key== ConsoleKey.E)
            {
                Console.Clear();
               var foods = EnterEating();
               eatingController.Add(foods.Food, foods.Weight);

               foreach (var item in eatingController.Eating.Foods)
               {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
               }
            }

            Console.Read();
        }

       
    }
}
