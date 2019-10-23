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

                case "SlimmingGirl":
                    SlimmingGirl();
                    break;

                case "SlimmingMan":
                    SlimmingMan();
                    break;

                case "BodyBuildingMan":
                    BodyBuildingMan();
                    break;
                case "BodyBuildingGirl":
                    BodyBuildingGirl();
                    break;
            }
         

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

            var des = @"Программа призначена для начинающих, которые хотят увеличить объемы мышц, стать накаченными.Им нужно программа тренировок на массу для начинающих. Она должна включать в себя базовые упражнения.";

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
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Кардио.jpg",0,5,"минут",@""),
                new Exercise ("Жим штанги лежа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Жим штанги лежа.jpg",2,10,"раз",@""),
                new Exercise ("Разведение гантелей лежа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Разведение гантелей лежа.jpg",2,10,"раз",@""),
                new Exercise ("Разгибание рук на блоке",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Разгибание рук на блоке.jpg",2,10,"раз",@""),
                new Exercise ("Жим гантели из-за головы",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Жим гантели из-за головы.jpg",2,10,"раз",@""),
                new Exercise ("Пресс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Пресс.png",3,10,"раз",@"")


            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Кардио.jpg",0,6,"минут",@""),
                new Exercise ("Приседания с пустым грифом",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Приседания с пустым грифом.jpg",2,10,"раз"," "),
                new Exercise ("Жим ногами в тренажере",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Жим ногами в тренажере.jpg",2,10,"раз"," "),
                new Exercise ("Жим гантелей сидя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Жим гантелей сидя.jpg",2,10,"раз"," "),
                new Exercise ("Тяга грифа к подбородку",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Тяга грифа к подбородку.jpg",2,10,"раз"," "),
                new Exercise ("Пресс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Пресс.png",2,15,"раз"," ")
            };


            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Кардио.jpg",0,7,"минут",@""),
                new Exercise ("Гиперэкстензия",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day3/Гиперэкстензия.jpg",2,15,"раз"," "),
                new Exercise ("Тяга верхнего блока",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day3/Тяга верхнего блока.jpg",2,10,"раз"," "),
                new Exercise ("Сгибание рук с грифом на бицепс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day3/Сгибание рук с грифом на бицепс.jpg",2,10,"раз"," "),
                new Exercise ("Молот",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day3/Молот.jpg",2,10,"раз"," "),
                new Exercise ("Пресс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Пресс.png",3,10,"раз"," ")

            };


            AddNew("День 1", day1);
            AddNew("День 2", day2);
            AddNew("День 3", day3);
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

        #region Сброс веса 
        private void SlimmingGirl()
        {
            var des = @"Предпочтительнее заниматься в зале трижды в неделю. Например, если тренировки для сжигания жира будут проходить в понедельник, среду и пятницу.
                        Данная программа направлена на формирование и рельефообразование мышц всего тела с упором на проблемные женские зоны.";

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
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Кардио.jpg",0,30,"минут",@""),
                new Exercise ("Приседание со штангой",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Приседание со штангой.jpg",3,15,"кг",@""),
                new Exercise ("Приседания плие",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Приседания плие.jpg",3,15,"раз",@""),
                new Exercise ("Выпады с гантелями",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Выпады с гантелями.jpg",3,20,"на каждую ногу",@""),
                new Exercise ("Гиперэкстензия",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day3/Гиперэкстензия.jpg",2,20,"раз",@""),
                new Exercise ("Сгибание рук с гантелями",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day3/Сгибания рук с гантелями.jpg",3,20,"раз",@""),
                new Exercise ("Пресс подъем туловища на римском стуле и подъем ног лежа.",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Пресс подъем туловища на римском стуле и подъем ног лежа..jpg",3,30,"раз",@""),
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Кардио.jpg",0,15,"минут",@"")

            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Кардио.jpg",0,30,"минут",@""),
                new Exercise ("Гиперэкстензия",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobgril/Day3/Гиперэкстензия.jpg",2,20,"раз",@""),
                new Exercise ("Румынская тяга",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Румынская тяга.jpg",3,15,"раз",@""),
                new Exercise ("Сведение ног в тренажере",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Сведение ног в тренажере.jpg",2,20,"раз",@""),
                new Exercise ("Жим гантелей лежа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Жим гантелей лежа.jpg",2,20,"раз",@""),
                new Exercise ("Разведение рук с гантелями на горизонтальной скамье",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Разведение рук с гантелями на горизонтальной скамье.jpg",2,20,"раз",@""),
                new Exercise ("Разведение рук с гантелями на скамье под углом 30 градусов",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Разведение рук с гантелями на скамье под углом 30 градусов.jpg",2,20,"раз",@""),
                new Exercise ("Разгибание рук на блоке",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Разгибание рук на блоке.jpg",3,20,"раз",@""),
                new Exercise ("Косые скручивания",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Косые скручивания.jpg",3,20,"на каждую сторону",@""),
                new Exercise ("Подъем туловища на полу",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Подъем туловища на полу.jpg",4,20,"раз",@""),
                new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Кардио.jpg",0,10,"минут",@"")

            };


            List<Exercise> day3 = new List<Exercise>()
            {  new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Кардио.jpg",0,20,"минут",@""),
               new Exercise ("Жим ногами (стопы на верхней части платформы, расставлены широко)",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
               "Training/SlimmingGirl/Day3/Жим ногами (стопы на верхней части платформы, расставлены широко).jpg",2,15,"раз",@""),

               new Exercise ("Разгибание ног в тренажере",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
               "Training/SlimmingGirl/Day3/Разгибание ног в тренажере.jpg",0,20,"минут",@""),

               new Exercise ("Сведение ног в тренажере",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
               "Training/SlimmingGirl/Day2/Сведение ног в тренажере.jpg",2,20,"раз",@""),
               new Exercise ("Подъем на носки на икры",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
               "Training/SlimmingGirl/Day3/Подъем на носки на икры.jpg",4,30,"раз",@""),
               new Exercise ("Жим гантелей сидя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
               "Training/SlimmingGirl/Day3/Жим гантелей сидя.jpg",3,20,"раз",@""),
               new Exercise ("Разведение гантелей через стороны",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),
               "Training/SlimmingGirl/Day3/Разведение гантелей через стороны.jpg",3,15,"раз",@""),
               new Exercise ("Кардио",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day1/Кардио.jpg",0,20,"минут",@"")

            };


            AddNew("Понедельник", day1);
            AddNew("Среда", day2);
            AddNew("Пятница", day3);
            //Training.Add("День 1", day1);
            //Training.Add("День 2", day2);
            //Training.Add("День 3", day3);
        }

        private void SlimmingMan()
        {
            var des = @"Программа тренировок для сушки мышц тела направлена на максимальное сжигание жира и сохранение мышечной массы.
             В программе тренировок для сушки мышц тела можно менять упражнения, но день, в который они проводятся, а также стиль тренировок (высокоинтенсивный, объёмный или силовой) – нельзя. Количество повторений, сетов, упражнений и время отдыха должны быть такими, как указано в программе.
             Тренировки проводятся по дням:Понедельник,Вторник,Четверг.Остальные дни Отдых. Если есть желание и силы, можно сделать кардио вечером (для ускорения процесса сушки мышц).
             ";

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
                new Exercise ("Жим ногами",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Жим ногами.jpg", 3,15,"раз",@"Чем шире постановка ног и чем ближе пятки к краю платформы, тем сильнее задействованы приводящие (внутренняя часть бедра) и ягодичные мышцы. Если у вас сводит колени во время Приседаний, значит приводящие мышцы бедра слабые.Не отрывайте поясницу от тренажёра, иначе она получает ненужную нагрузку и можно получить травму."),
                new Exercise ("Сгибание ног",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Сгибание ног.jpg",3,15,"раз",@""),
                new Exercise ("Жим лёжа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Жим штанги лёжа.jpg",3,15,"раз",@""),
                new Exercise ("Тяга нижнего блока",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Тяга нижнего блока.jpg",3,15,"раз",@""),
                new Exercise ("Разведение рук с гантелями стоя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg",2,20,"раз",@"Разведение рук с гантелями стоя – изолирующее упражнение для средних пучков дельтовидных мышц.Помните, в данном упражнении ваша цель – не поднять гантели как можно выше, а привести плечи в положение, параллельное полу.
                 Чтобы максимум нагрузки приходился на плечи, не раскачивайтесь корпусом и не выполняйте движение за счёт инерции."),
                new Exercise ("Подъёмы на икры",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Подъёмы на икры.jpg",3,15,"раз",@""),
                new Exercise ("Подъём штанги на бицепс стоя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg",2,15,"раз",@""),
                new Exercise ("Разгибания рук на блоке на трицепс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Разгибания рук на блоке на трицепс.jpg",2,15,"раз",@"")

            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Жим ногами",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Жим ногами.jpg", 3,15,"раз",@"Чем шире постановка ног и чем ближе пятки к краю платформы, тем сильнее задействованы приводящие (внутренняя часть бедра) и ягодичные мышцы. Если у вас сводит колени во время Приседаний, значит приводящие мышцы бедра слабые.Не отрывайте поясницу от тренажёра, иначе она получает ненужную нагрузку и можно получить травму."),
                new Exercise ("Сгибание ног",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Сгибание ног.jpg",3,15,"раз",@""),
                new Exercise ("Жим штанги лёжа на наклонной скамье",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day2/Жим штанги лёжа на наклонной скамье.jpg",3,15,"раз",@""),
                new Exercise ("Тяга верхнего блока к груди",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day3/Тяга верхнего блока.jpg",3,15,"раз",@""),
                new Exercise ("Разведение рук с гантелями стоя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg",3,15,"раз",@""),
                new Exercise ("Подъёмы на икры",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Подъёмы на икры.jpg",3,15,"раз",@""),
                new Exercise ("Подъём штанги на бицепс стоя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg",2,15,"раз",@""),
                new Exercise ("Разгибания рук на блоке на трицепс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Разгибания рук на блоке на трицепс.jpg",2,15,"раз",@"")

            };


            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Жим ногами",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Жим ногами.jpg", 2,15,"раз",@"Чем шире постановка ног и чем ближе пятки к краю платформы, тем сильнее задействованы приводящие (внутренняя часть бедра) и ягодичные мышцы. Если у вас сводит колени во время Приседаний, значит приводящие мышцы бедра слабые.Не отрывайте поясницу от тренажёра, иначе она получает ненужную нагрузку и можно получить травму."),
                new Exercise ("Сгибание ног стоя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day3/Сгибание ног стоя.jpg", 2,15,"раз",@""),
                new Exercise ("Разгибания ног в тренажёре",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day3/Разгибания ног в тренажёре.jpg", 1,12,"раз",@""),
                new Exercise ("Сгибание ног",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Сгибание ног.jpg",1,16,"раз",@""),
                new Exercise ("Подъёмы на икры",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Подъёмы на икры.jpg",3,16,"раз",@""),
                new Exercise ("Жим лёжа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Жим штанги лёжа.jpg",2,12,"раз",@""),
                new Exercise ("Тяга нижнего блока",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Тяга нижнего блока.jpg",2,12,"раз",@""),
                new Exercise ("Жим штанги лёжа на наклонной скамье",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day2/Жим штанги лёжа на наклонной скамье.jpg",1,12,"раз",@""),
                new Exercise ("Тяга верхнего блока к груди",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day3/Тяга верхнего блока.jpg",1,12,"раз",@""),
                new Exercise ("Разведение рук с гантелями стоя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg",2,12,"раз",@"Разведение рук с гантелями стоя – изолирующее упражнение для средних пучков дельтовидных мышц.Помните, в данном упражнении ваша цель – не поднять гантели как можно выше, а привести плечи в положение, параллельное полу.
                 Чтобы максимум нагрузки приходился на плечи, не раскачивайтесь корпусом и не выполняйте движение за счёт инерции."),
                new Exercise ("Подъём штанги на бицепс стоя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg",2,12,"раз",@""),
                new Exercise ("Разгибания рук на блоке на трицепс",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Разгибания рук на блоке на трицепс.jpg",2,12,"раз",@"")

            };




            AddNew("Понедельник", day1);
            AddNew("Вторник", day2);
            AddNew("Четверг", day3);
            //Training.Add("День 1", day1);
            //Training.Add("День 2", day2);
            //Training.Add("День 3", day3);
        }
        #endregion


        #region  Бодибилдинг
        private void BodyBuildingGirl()
        {
            var des = @"Для девушек боди бдинг";
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
                new Exercise ("Жим гантелей лежа на горизонтальной скамье",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day1/Жим гантелей лежа на горизонтальной скамье.jpg", 2,10,"раз",@"Чем шире постановка ног и чем ближе пятки к краю платформы, тем сильнее задействованы приводящие (внутренняя часть бедра) и ягодичные мышцы. Если у вас сводит колени во время Приседаний, значит приводящие мышцы бедра слабые.Не отрывайте поясницу от тренажёра, иначе она получает ненужную нагрузку и можно получить травму."),
                new Exercise ("Жим гантелей лежа на наклонной скамье",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day1/Жим гантелей лежа на наклонной скамье.jpg",2,10,"раз",@""),
                new Exercise ("Сведение рук в кроссовере",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day1/Сведение рук в кроссовере.png",2,10,"раз",@""),
                new Exercise ("Разгибание рук стоя на нижнем блоке",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day1/Разгибание рук стоя на нижнем блоке.jpg",2,8,"раз",@""),
                new Exercise ("Отжимания на брусьях",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day1/Отжимания на брусьях.jpg",1,8,"раз",@""),
                new Exercise ("Жим на плечи в тросовом тренажёре сидя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day1/Жим на плечи в тросовом тренажёре.PNG",3,10,"раз",@""),
                new Exercise ("Фронтальный подъём штанги над головой",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day1/Фронтальный подъём штанги над головой .png",2,10,"раз",@""),
                new Exercise ("Разведение рук с гантелями на горизонтальной скамье",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingGirl/Day2/Разведение рук с гантелями на горизонтальной скамье.jpg",2,10,"раз",@"")
            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Подтягивания",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day2/Подтягивания.jpg", 3,8,"раз",@""),
                new Exercise ("Подтягивания обратным хватом",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day2/Подтягивания обратным хватом.jpg", 2,10,"раз",@""),
                new Exercise ("Подъем EZ-штанги на бицепс на скамье Скотта",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day2/Подъем EZ-штанги на бицепс на скамье Скотта.jpeg", 2,10,"раз",@""),
                new Exercise ("Попеременный подъем гантелей на бицепс стоя",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day2/Попеременный подъем гантелей на бицепс стоя.jpg", 1,12,"раз",@"")
            };


            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Приседания со штангой",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day3/Приседания со штангой.jpg", 2,15,"раз",@""),
                new Exercise ("Становая тяга в машине Смита с прямыми ногами",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day3/Становая тяга в машине Смита с прямыми ногами.jpg", 2,15,"раз",@""),

                new Exercise ("Выпад с гантелями вперед",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day3/Выпад с гантелями вперед.jpg", 2,15,"раз",@""),
                new Exercise ("Выпады со штангой в сторону",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day3/Выпады со штангой в сторону.jpg", 2,15,"раз",@""),
                new Exercise ("Подъем на носки на одной ноге",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingGirl/Day3/Подъем на носки на одной ноге.jpg", 2,15,"раз",@""),

            };

            AddNew("День 1", day1);
            AddNew("День 2", day2);
            AddNew("День 3", day3);

        }




        private void BodyBuildingMan()
        {
            var des = @"Упражнения бодибилдинг тренировок на массу.Базовые(или многосуставные) упражнения – это упражнения, где задействовано сразу несколько групп мышц и работают несколько суставов. Приседания, становая тяга,жим лежа, подтягивания, тяга штанги кпоясу в наклоне, отжимания на брусьях– все это базовые упражнения.Какправило, они – самые тяжелые для выполнения. Но они же – самое эффективноесредство для набора мышечной массы.База – платформа, на которой строитсяпрограмма тренировок на массу вбодибилдинге. Изолирующие упражнения– те, которые прорабатывают лишь однумышцу (и задействуют один сустав. Втренинге на массу они второстепенны ивыступают лишь как дополнение дляотстающих мышц.";

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
                new Exercise ("Приседания со штангой",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingMan/Day1/Приседания со штангой.jpeg", 3,10,"раз",@""),
                new Exercise ("Жим ногами в тренажере ",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Жим ногами в тренажере.jpg", 3,10,"раз",@""),
                new Exercise ("Жим штанги стоя ",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingMan/Day1/Жим штанги стоя.jpg", 3,8,"раз",@""),
                new Exercise ("Тяга штанги к подбородку  ",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day2/Тяга грифа к подбородку.jpg", 3,10,"раз",@""),
                new Exercise ("Пресс ",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Пресс.png", 3,50,"раз",@""),


            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Cтановая тяга",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingMan/Day2/Cтановая тяга.jpg", 3,8,"раз",@""),
                new Exercise ("Подтягивания",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingMan/Day2/Подтягивания.jpg", 3,15,"раз",@""),
                new Exercise ("Жим лежа узким хватом",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingMan/Day2/Жим лежа узким хватом.jpg", 3,10,"раз",@""),
                new Exercise ("Французский жим",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/BodyBuildingMan/Day2/Французский жим.jpg", 3,10,"раз",@""),
                new Exercise ("Пресс ",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Пресс.png", 3,50,"раз",@"")

            };


            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Жим штанги лежа",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Жим штанги лежа.jpg", 3,8,"раз",@""),
                new Exercise ("Жим штанги на наклонной скамье",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day2/Жим штанги лёжа на наклонной скамье.jpg", 3,10,"раз",@""),
                new Exercise ("Разводка гантелей ",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg", 3,12,"раз",@""),
                new Exercise ("Подъем штанги на бицепс ",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg", 3,10,"раз",@""),
                new Exercise ("Пресс ",100,Convert.ToDateTime("22:00"),Convert.ToDateTime("22:30"),"Training/Noobman/Day1/Пресс.png", 3,50,"раз",@"")

            };

            AddNew("Понедельник(ноги, плечи)",day1);
            AddNew("Среда(спина, трицепс)",day2);
            AddNew("Пятница(грудь, бицепс)", day3);

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
            if (exercises != null &&  string.IsNullOrEmpty(day))
            {
                Training.Add(day,exercises);
                //GetCurrentTraining();
                Save();
            }
            else
            {
                //Ошибка.
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
