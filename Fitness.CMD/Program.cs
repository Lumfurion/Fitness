using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Model;
using System;
using System.Globalization;
using System.Resources;
using System.Linq;

namespace Fitness.CMD
{    /// <summary>
    /// Консольный интерфейс
    /// </summary>
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birtdayDate;
            while (true)
            {
                Console.Write($"Введите {value}(dd.MM.yyyy):");

                // Преобразовывает указанное строковое представление даты и времени в его эквивалент
                // System.DateTime и возвращает значение, позволяющее определить успешность преобразования.
                if (DateTime.TryParse(Console.ReadLine(), out birtdayDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}!");
                }
            }

            return birtdayDate;
        }

        /// <summary>
        /// Заполнение приема пищи.
        /// </summary>
        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта:");
            var food = Console.ReadLine();
            var weight = ParseDauble("вес порции");
            var fats = ParseDauble("жиры");
            var proteins = ParseDauble("протеины");
            var carbohydrates = ParseDauble("углеводы");
            var calories = ParseDauble("калорийность");

            var product = new Food(food, proteins, fats, carbohydrates, calories);

            return (Food: product, Weight: weight);
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения:");
            var name = Console.ReadLine();
            var energy = ParseDauble("расход энергии в минуту");

            var begin = ParseDateTime("начало упражнения");
            var end = ParseDateTime("окончание упражнения");
            var activity = new Activity(name, energy);
            return (begin,end,activity);
        }
        static void Main()
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");//создание культуры.
            //typeof(Program).Assembly-получаем cборку.
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Localization", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));//получение строки словоря

            Console.Write(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

           

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            foreach (var us in userController.Users)
            {
                Console.WriteLine(us.Name);

                Console.WriteLine();
            }
            if (userController.isNewUser == true)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birtdayDate = ParseDateTime("дату раждения");
                var weight = ParseDauble("вес");
                var height = ParseDauble("рост");

                userController.SetNewUserData(gender, birtdayDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);


            Console.WriteLine("\nЕда");


            foreach (var et in eatingController.Foods)
            {
                if (eatingController.Eating.User.Name == userController.CurrentUser.Name)
                {
                    Console.WriteLine(et.Name + " " + et.Pats + " " + et.Proteins + " " + et.Carbohydrates + " " + et.Calories);
                    Console.WriteLine();
                }
                else break;
              
            }
                   
                
                Console.WriteLine("\nУпражнение");
                foreach (var ex in exerciseController.Exercises)
                {   if (ex.User.Name == userController.CurrentUser.Name)
                    {
                      Console.WriteLine(ex.Activity.Name + " " + ex.Start.ToString("t") + " " + ex.Finish.ToString("t") + " " + ex.User.Name);
                      Console.WriteLine();
                    }
                    else break;
                }
           



            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - Ввести прием пищи");
                Console.WriteLine("A - Ввести упражнение");
                Console.WriteLine("Q - Выход");
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        Console.Clear();
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        Console.Clear();
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t {item.Key} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity,exe.Begin, exe.End);
                        Console.Clear();
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Такой  команды нет!!");
                        break;

                }
              
                Console.Read();
                Console.Clear();
            } 

        }

       
    }
}