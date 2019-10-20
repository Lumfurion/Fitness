using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Fitness.BusinessLogic.Controller
{
    public class TrainingController:ControllerBase
    {
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        public List<Exercise> Exercises { get;}

        public Training Training { get;}

        public bool Select { get; set; } = false;

        /// <summary>
        /// Будет хранить тренировку пользователя
        /// </summary>
        public Dictionary<string, List<Exercise>> CurrentTraining { get;}

        internal static string Type { get; set; }

        
        public TrainingController()
        {
            CurrentTraining = new Dictionary<string, List<Exercise>>();
            Exercises = GetAllExercises();
            Training = GetTraining();
        }

        public TrainingController(string type)
        {
            Type = type;
            CurrentTraining = new Dictionary<string, List<Exercise>>();
            Exercises = GetAllExercises();
            Training = GetTraining();

            if (Training !=null)
            {
                GetCurrentTraining();
            }
        }

        /// <summary>
        /// Получение тренировки для кокретного пользователя.
        /// </summary>
        public void GetCurrentTraining()
        {
            var name = UserController.CurrentUserName;
            var settraining = Type;

            if (CurrentTraining != null)
            {
                CurrentTraining.Clear();
            }

            foreach (var ex in Training.Exercises)
            {
                var day = ex.Key;
                foreach (var vulue in ex.Value)
                {   
                    if (vulue.Username == name && vulue.Type == settraining)
                    {
                        List<Exercise> exe;
                        if (!CurrentTraining.TryGetValue(day, out exe))
                        {
                            exe = new List<Exercise>();
                            CurrentTraining.Add(day, exe);
                        }
                        exe.Add(new Exercise(vulue.Name, vulue.CaloriesPerMinute, vulue.Start, vulue.Finish, vulue.Image, vulue.Amount, vulue.Сount,vulue.Designation, vulue.Description));

                    }

                }
            }

        }

        #region Выбор тренировки.
        public void AddNew(string day, List<Exercise> exercises)
        {
            if (!CurrentTraining.ContainsKey(day))
            {
                CurrentTraining.Add(day, exercises);
            }
            else
            {
                foreach (var ex in exercises)
                {
                    CurrentTraining[day].Add(new Exercise(ex.Name, ex.CaloriesPerMinute, ex.Start, ex.Finish, ex.Image, ex.Amount, ex.Сount,ex.Designation,ex.Description));
                }
            }


        }
        public void SelectTraining(string name)
        {
            Type = name;
            //var type =Training.Exercises.Any(ex => ex.Value.Any(e => e.Type == Type && e.Username == UserController.CurrentUserName));
            
            CurrentTraining.Clear();
            switch (name)
            {
                case "NoobMan":
                    NoobMan();
                    break;

                case "NoobGirl":
                    NoobGirl();
                    break;
            }
            Description = Training.DescriptionSet[Type];

            //if (type == false)
            //{
            //    CurrentTraining.Clear();
            //    switch (name)
            //    {
            //        case "NoobMan":
            //            NoobMan();
            //            break;

            //        case "NoobGirl":
            //            NoobGirl();
            //            break;
            //    }
            //   GetCurrentTraining();
            //}
            //else
            //{ 
            //    Description = Training.DescriptionSet[Type];
            //    GetCurrentTraining();

            //}
        }

        #region Новичок
        private void NoobMan()
        {

            var des = @"Обычно парни приходят в тренажерный зал, чтобы увеличить объемы мышц, стать накаченными.Им нужно программа тренировок на массу для начинающих. Она должна включать в себя базовые упражнения. Это базовая программа тренировок для начинающих.";

            if (!Training.DescriptionSet.ContainsKey(Type))
            {
                Training.DescriptionSet.Add(Type, des);
                Description = Training.DescriptionSet[Type];//Получение описание треровки.
            }
            else
            {
                Description = Training.DescriptionSet[Type];//Получение описание треровки.
            }


            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Кардио.jpg",0,7,"минут",@""),
                new Exercise ("Жим штанги лежа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Жим штанги лежа.jpg",2,10,"раз",@""),
                new Exercise ("Разведение гантелей лежа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Разведение гантелей лежа.jpg",2,10,"раз",@""),
                new Exercise ("Разгибание рук на блоке",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Разгибание рук на блоке.jpg",2,10,"раз",@""),
                new Exercise ("Жим гантели из-за головы",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Жим гантели из-за головы.jpg",2,10,"раз",@""),
                new Exercise ("Пресс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Пресс.png",3,10,"раз",@"")


            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Кардио.jpg",0,7,"минут",@""),
                new Exercise ("Приседания с пустым грифом",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Приседания с пустым грифом.jpg",2,10,"раз"," "),
                new Exercise ("Жим ногами в тренажере",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Жим ногами в тренажере.jpg",2,10,"раз"," "),
                new Exercise ("Жим гантелей сидя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Жим гантелей сидя.jpg",2,10,"раз"," "),
                new Exercise ("Тяга грифа к подбородку",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Тяга грифа к подбородку.jpg",2,10,"раз"," "),
                new Exercise ("Пресс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Пресс.png",2,15,"раз"," "),
            };


            //List<Exercise> day3 = new List<Exercise>()
            //{
            //    new Exercise ("Укрепление мышц бедер и спины",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Круги руками",4,@"Как делать: Встаньте на четвереньки. Вытяните левую ногу и правую руку в одну прямую линию. Затем медленно согните их и коснитесь правым локтем левого колена. Снова выпрямитесь. То же самое проделайте с правой ногой и левой рукой.
            //    Прокачка: Хорошо тренирует корпус и мышцы, сгибающие бедро. Укрепляет и растягивает мышцы спины, ягодичные мышцы и поясницу."),

            //    new Exercise ("Наклоны с руками за головой",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Imege Наклоны с руками за головой",4," sd")
            //};


            AddNew("День 1", day1);
            AddNew("День 2", day2);
            //AddNew("День 3", day3);
            //Training.Add("День 1", day1);
            //Training.Add("День 2", day2);
            //Training.Add("День 3", day3);
        }
        private void NoobGirl()
        {

            var des = 
             @"Легкую зарядку продолжительностью 10-20 минут можно выполнять каждый день. 
              Для более интенсивных занятий, длящихся 45-60 минут, выделите три дня в неделю, чтобы организм успевал восстанавливаться. 
             Перед каждой тренировкой хорошенько разминайтесь – делайте суставную гимнастику или кардио средней интенсивности. 
             Для заминки после тренировки делайте растяжку (но не переусердствуйте) и легкое кардио (быстрая ходьба, кручение обруча, велосипед).";

            if (!Training.DescriptionSet.ContainsKey(Type))
            {
                Training.DescriptionSet.Add(Type, des);
                Description = Training.DescriptionSet[Type];//Получение описание треровки.
            }
            else
            {
                Description = Training.DescriptionSet[Type];//Получение описание треровки.
            }

            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Выпады в движении (без отягощения или с гантелями)",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day1/Lunges-with-dumbbells.jpg",4,20,"(по 10 шагов на каждую ногу)",
                @"Выпад – это одно из основных упражнений для ног, которое задействует ягодичные мышцы и мышцы бедер. В зависимости от длины выпада, можно накачать те или иные мышцы ног."),

                new Exercise ("Махи ногами назад, стоя на четвереньках (с утяжелителями или без)",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
               "Training/Noobgril/Day1/mahi-nogami.jpg",4,15,"раз",@"Махи ногами – это целый ряд упражнений для бедер и ягодиц, включающий в себя множество различных вариаций. При помощи махов вы можете эффективно проработать заднюю, переднюю, внешнюю и внутреннюю поверхность бедра, а также большие и средние ягодичные мышцы. Грамотное использование этого упражнения поможет вам добиться результатов в похудении, подтянуть мускулатуру нижней части тела, сделать фигуру упругой и привлекательной."),

                new Exercise ("Тяга верхнего блока к груди (или подтягивания с резинкой)",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
                "Training/Noobgril/Day1/Тяга-блока-к-груди.png",5,10,"раз",@"«Тяга грифа сверху вниз к груди на блочном тренажере в положении сидя» является наиболее функциональным упражнением по сравнению с традиционно дополняющей его «тягой грифа широким хватом сверху вниз за голову на блочном тренажере в положении сидя»."),

                new Exercise ("Разведение рук в стороны в наклоне (с гантелями или эспандером)",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
                "Training/Noobgril/Day1/razvedeniya-ruk-v-naklone-dlya-devushek.jpg",4,12,"раз",@""),

                 new Exercise ("Сведение рук лежа с гантелями (или стоя с эспандером)",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
                "Training/Noobgril/Day1/DSC_5501_1545278749-630x315.jpg",4,12,"раз",@"Лучшее дополнительное упражнение на мышцы груди – это разводка гантелей лежа, или правильно говоря – разведение. За счет различных углов наклона скамьи этим упражнением можно прокачать все участки грудных мышц."),

                 new Exercise ("Скручивания корпуса лежа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
                "Training/Noobgril/Day1/skruchivaniya-kak-pravilno-delat_20.jpg",4,20,"раз",@"Упражнение «Скручивание лежа на полу» является отличным упражнением для проработки прямой мышцы живота. Благодаря своей простоте и доступности, его можно выполнять не только в тренажерном зале, но и дома.")

            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Румынская становая тяга (с гантелями или эспандером)",100,
                Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day2/Румынская становая тяга.jpg",5,10,"раз",@""),

                new Exercise ("Ягодичный мостик (без отягощения или с блином)",100,
                Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day2/Ягодичный мостик.jpg",4,12,"раз",""),

                new Exercise ("Подъем рук стоя через стороны (с гантелями или эспандером)",100,
                Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day2/Подъем рук стоя через стороны.jpg",4,12,"раз",""),

                new Exercise ("Тяга гантели к поясу в наклоне (можно заменить эспандером)",100,
                Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day2/Тяга гантели к поясу в наклоне.jpg",4,10,"раз",""),

                new Exercise ("Разгибание рук из-за головы с гантелью или эспандером",100,
                Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day2/Разгибание рук из-за головы с гантелью.jpg",3,12,"раз",""),

                new Exercise ("Подъем ног лежа",100,
                Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day2/Подъем ног лежа.jpg",4,15,"раз","")
            };

            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Приседания с широкой постановкой ног (без отягощения или с гантелью),",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day3/Приседания с широкой постановкой ног.jpg",5,10,"раз",@""),
                new Exercise ("Гиперэкстензия",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day3/Гиперэкстензия.jpg",4,15,"раз",""),
                new Exercise ("Отжимания от пола",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day3/Отжимания от пола.jpg",4,10,"раз",""),
                new Exercise ("Тяга верхнего блока к груди (или подтягивания)",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day1/Тяга-блока-к-груди.png",4,10,"раз",""),
                new Exercise ("Сгибания рук с гантелями (или эспандером)",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day3/Сгибания рук с гантелями.jpg",4,10,"раз",""),
                new Exercise ("Планка",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day3/планка.jpg",3,1,"минуте","")

            };

            AddNew("День 1", day1);
            AddNew("День 2", day2);
            AddNew("День 3", day3);
            //Training.Add("День 1", day1);
            //Training.Add("День 2", day2);
            //Training.Add("День 3", day3);
        }
        #endregion
        #endregion

        /// <summary>
        /// Дабавление  тренировки.
        /// </summary>
        /// <param name="day"></param>
        /// <param name="exercises"></param>
        public void Add(string day, List<Exercise> exercises)
        {
            if (exercises != null )
            {
                Training.Add(day,exercises);
                GetCurrentTraining();
                Save();
            }
 
        }


        public void Saver()
        {   var isSuch =Training.Exercises.Any(ex => ex.Value.Any(e => e.Type == Type && e.Username == UserController.CurrentUserName));

            if (isSuch == false)//Нету
            {
                foreach (var tr in CurrentTraining)
                {
                    Training.Add(tr.Key, tr.Value);
                }
                Select = true;
                Save();
            }
           
        }


        //public void Check()
        //{
        //    foreach (var key in Training.Exercises)
        //    {
        //        Console.WriteLine(key.Key);
        //        foreach (var vulue in key.Value)
        //        {
        //            if (vulue.Type != Type && vulue.Username == UserController.CurrentUserName)
        //            {
        //                Console.WriteLine(vulue.Name);
        //                Console.WriteLine(vulue.Amount);
        //                Console.WriteLine(vulue.CaloriesPerMinute);
        //                Console.WriteLine(vulue.Start);
        //                Console.WriteLine(vulue.Finish);
        //                Console.WriteLine(vulue.Image);
        //                Console.WriteLine(vulue.Description);
        //                Console.WriteLine(vulue.Username);
        //                Console.WriteLine(vulue.Type);
        //                Console.WriteLine("\n");
        //            }



        //        }
        //    }
        //}


        private Training GetTraining()
        {
            return Load<Training>().FirstOrDefault() ?? new Training();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        private void Save()
        {
            Save(Exercises);
            Save(new List<Training>() { Training });
        }


    }
}
