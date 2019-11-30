using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Model;
using System;
using System.Globalization;
using System.Resources;
using System.Linq;
using System.Collections.Generic;

namespace Fitness.CMD
{    /// <summary>
    /// Консольный интерфейс
    /// </summary>
    class Program
    {  
      
        static void Main()
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");//создание культуры.
            //typeof(Program).Assembly-получаем cборку.
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Localization", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));//получение строки словоря

            Console.Write(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();
            var userController = new UserController(name);
            
            var training = new TrainingController();
            var eatingController = new EatingController();
            var exercise = new ExerciseController();



            var noob = "NoobMan";
            training.SelectTraining(noob);
            training.Saver();
            training.AddNewDay();


            foreach (var Data in training.SelectProgram())
            {
                Console.WriteLine(Data.Key);
                foreach (var key in Data.Value)
                {

                    Console.WriteLine(key.Name);
                    Console.WriteLine(key.Amount);
                    Console.WriteLine(key.CaloriesPerMinute);
  
                    Console.WriteLine(key.Image);
                   
                    Console.WriteLine("\n");

                }
            }




            //Console.WriteLine(training.Description);
            // foreach (var Data in training.CurrentTraining)
            // {
            //     Console.WriteLine(Data.Key);
            //     foreach (var key in Data.Value)
            //     {

            //         Console.WriteLine(key.Name);
            //         Console.WriteLine(key.Amount);
            //         Console.WriteLine(key.CaloriesPerMinute);
            //         Console.WriteLine(key.Start);
            //         Console.WriteLine(key.Finish);
            //         Console.WriteLine(key.Image);
            //         Console.WriteLine(key.Description);
            //         Console.WriteLine(key.Username);
            //         Console.WriteLine(key.Type);
            //         Console.WriteLine("\n");

            //     }
            // }
            // Console.WriteLine("\n");
            // Console.WriteLine("\n");


            // //training.Check();

            // Console.WriteLine("\n");



            // foreach (var us in userController.Users)
            // {
            //     Console.WriteLine(us.Name);

            //     Console.WriteLine();
            // }




            Console.WriteLine("\nЕда");

            //foreach (var item in eatingController.Eating.Foods)
            //{
            //    Console.WriteLine($"\t {item.Key} - {item.Value}");
            //}

            //foreach (var et in eatingController.Foods)
            //{
            //    if (eatingController.Eating.User.Name == userController.CurrentUser.Name)
            //    {
            //        Console.WriteLine(et.Name + " " + et.Pats + " " + et.Proteins + " " + et.Carbohydrates + " " + et.Calories);
            //        Console.WriteLine();
            //    }


            //}

            //foreach (var et in eatingController.Foods)
            //{
            //    if (et.Username == name)
            //    {
            //        Console.WriteLine(et.Name + " " + et.Pats + " " + et.Proteins + " " + et.Carbohydrates + " " + et.Calories);
            //        Console.WriteLine();
            //    }
            //    else break;

            //}

            Console.ReadKey();


        }

       

    }
}