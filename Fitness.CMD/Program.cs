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
       

        //private static void  SetPro(TrainingController training)
        //{
            
           

        //    List<Exercise> ex1 = new List<Exercise>()
        //    {
        //        new Exercise ("Пресс и талия",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Круги руками",4,@"Как делать: Планка — упражнение изометрическое (выполняется статично). Главное — правильно держать тело. Следуйте примеру на фото: спина и ноги прямые, поясница не должна провисать или выгибаться.
        //         Прокачка: При правильном выполнении прокачиваются не только мышцы пресса, но и спины, ягодиц, ног и рук. Улучшается осанка и общий тонус мышц."),

        //        new Exercise ("Пресс и ягодицы",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4,@"Как делать: Примите позу планки на вытянутых руках как стартовую. Далее медленно опускайтесь как можно ниже. Важно, чтобы спина, таз и ноги сохраняли прямую линию. Затем так же медленно возвращайте тело в начальное положение.
        //                       Прокачка: Воздействует на мышцы груди, рук и пресса.")
        //    };

        //    List<Exercise> ex2 = new List<Exercise>()
        //    {
        //        new Exercise ("Приседания",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Круги руками",4,@"Как делать: Встаньте на четвереньки. Вытяните левую ногу и правую руку в одну прямую линию. Затем медленно согните их и коснитесь правым локтем левого колена. Снова выпрямитесь. То же самое проделайте с правой ногой и левой рукой.
        //        Прокачка: Хорошо тренирует корпус и мышцы, сгибающие бедро. Укрепляет и растягивает мышцы спины, ягодичные мышцы и поясницу."),

        //        new Exercise ("Укрепление мышц бедер и спины",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4," sd")
        //    };

        //    training.Add("Day1", ex1);
        //    training.Add("Day2", ex2);

        //}


        //private static void Fullbody(TrainingController training)
        //{
           
        //    training.Training.Description = @"Фулбоди (от англ. «full body» — всё тело) - это программа тренировок всего тела за одно занятие, которая предназначена главным образом для новичков, но также часто применяется опытными атлетами после длительного перерыва, чтобы постепенно войти в тренировочный режим.

        //    Фулбоди тренировка предполагает меньшее количество подходов на группу мышц (как правило не более трех на одну группу).

        //    Тренировки всего тела являются более эффективными для новичков, чем сплит-схемы
        //    Бодибилдеры прогрессируют, тренируясь как по системе «фулбади» (тренировки всего тела), так и по сплит-схемам, но для новичков система тренировки всего тела оказалась более эффективной.
        //    Это выдержка из исследования американского спортивного исследователя Брэда Шонфельда (Brad Schoenfeld), которое будет опубликовано в ближайшее время в журнале «Strength and Conditioning Research».";

        //    List<Exercise> ex1 = new List<Exercise>()
        //    {
        //        new Exercise ("Жим лёжа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Круги руками",4,@"Как делать: Планка — упражнение изометрическое (выполняется статично). Главное — правильно держать тело. Следуйте примеру на фото: спина и ноги прямые, поясница не должна провисать или выгибаться.
        //         Прокачка: При правильном выполнении прокачиваются не только мышцы пресса, но и спины, ягодиц, ног и рук. Улучшается осанка и общий тонус мышц."),

        //        new Exercise ("Наклонный жим",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4,@"Как делать: Примите позу планки на вытянутых руках как стартовую. Далее медленно опускайтесь как можно ниже. Важно, чтобы спина, таз и ноги сохраняли прямую линию. Затем так же медленно возвращайте тело в начальное положение.
        //                       Прокачка: Воздействует на мышцы груди, рук и пресса."),

        //        new Exercise ("Тяга верхнего блока широким хватом",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4,@"Как делать: Примите позу планки на вытянутых руках как стартовую. Далее медленно опускайтесь как можно ниже. Важно, чтобы спина, таз и ноги сохраняли прямую линию. Затем так же медленно возвращайте тело в начальное положение.
        //                       Прокачка: Воздействует на мышцы груди, рук и пресса."),

        //        new Exercise ("Тяга к поясу",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4,@"Как делать: Примите позу планки на вытянутых руках как стартовую. Далее медленно опускайтесь как можно ниже. Важно, чтобы спина, таз и ноги сохраняли прямую линию. Затем так же медленно возвращайте тело в начальное положение.
        //                       Прокачка: Воздействует на мышцы груди, рук и пресса.")


        //    };

        //    //List<Exercise> ex2 = new List<Exercise>()
        //    //{
        //    //    new Exercise ("Приседания",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Круги руками",4,@"Как делать: Встаньте на четвереньки. Вытяните левую ногу и правую руку в одну прямую линию. Затем медленно согните их и коснитесь правым локтем левого колена. Снова выпрямитесь. То же самое проделайте с правой ногой и левой рукой.
        //    //    Прокачка: Хорошо тренирует корпус и мышцы, сгибающие бедро. Укрепляет и растягивает мышцы спины, ягодичные мышцы и поясницу."),

        //    //    new Exercise ("Укрепление мышц бедер и спины",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4," sd")
        //    //};

        //    training.Add("Day1", ex1);
        //    //training.Add("Day2", ex2);

        //}


        //private static void ds(TrainingController training)
        //{

        //    training.Training.Description = @"sdsd";

        //    List<Exercise> ex1 = new List<Exercise>()
        //    {
        //        new Exercise ("dass",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Круги руками",4,@"Как делать: Планка — упражнение изометрическое (выполняется статично). Главное — правильно держать тело. Следуйте примеру на фото: спина и ноги прямые, поясница не должна провисать или выгибаться.
        //         Прокачка: При правильном выполнении прокачиваются не только мышцы пресса, но и спины, ягодиц, ног и рук. Улучшается осанка и общий тонус мышц."),

        //        new Exercise ("sdasa",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4,@"Как делать: Примите позу планки на вытянутых руках как стартовую. Далее медленно опускайтесь как можно ниже. Важно, чтобы спина, таз и ноги сохраняли прямую линию. Затем так же медленно возвращайте тело в начальное положение.
        //                       Прокачка: Воздействует на мышцы груди, рук и пресса."),

        //        new Exercise ("sdas",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4,@"Как делать: Примите позу планки на вытянутых руках как стартовую. Далее медленно опускайтесь как можно ниже. Важно, чтобы спина, таз и ноги сохраняли прямую линию. Затем так же медленно возвращайте тело в начальное положение.
        //                       Прокачка: Воздействует на мышцы груди, рук и пресса."),

        //        new Exercise ("sdasa",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4,@"Как делать: Примите позу планки на вытянутых руках как стартовую. Далее медленно опускайтесь как можно ниже. Важно, чтобы спина, таз и ноги сохраняли прямую линию. Затем так же медленно возвращайте тело в начальное положение.
        //                       Прокачка: Воздействует на мышцы груди, рук и пресса.")


        //    };


        //    training.Add("Day1", ex1);

        //}



        static void Main()
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");//создание культуры.
            //typeof(Program).Assembly-получаем cборку.
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Localization", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));//получение строки словоря

            Console.Write(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();
            var userController = new UserController(name);
            var eatingController = new EatingController();
          
            var noob = "NoobMan";
            var training = new TrainingController();
            training.SelectTraining(noob);


            Console.WriteLine(training.Description);
            foreach (var Data in training.CurrentTraining)
            {
                Console.WriteLine(Data.Key);
                foreach (var key in Data.Value)
                {

                    Console.WriteLine(key.Name);
                    Console.WriteLine(key.Amount);
                    Console.WriteLine(key.CaloriesPerMinute);
                    Console.WriteLine(key.Start);
                    Console.WriteLine(key.Finish);
                    Console.WriteLine(key.Image);
                    Console.WriteLine(key.Description);
                    Console.WriteLine(key.Username);
                    Console.WriteLine(key.Type);
                    Console.WriteLine("\n");

                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("\n");


            //training.Check();

            Console.WriteLine("\n");



            foreach (var us in userController.Users)
            {
                Console.WriteLine(us.Name);

                Console.WriteLine();
            }

          


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