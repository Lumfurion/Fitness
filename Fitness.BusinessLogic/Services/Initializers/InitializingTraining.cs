using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Services.Initializers
{
    public static class InitializingTraining
    {
        static List<Training> Trainings { get; set; }

        static InitializingTraining()
        {
            Trainings = new List<Training>();
            if(Trainings.Count == 0)
            {
                Init();
            }
        }

        private static void Init()
        {   //База для начинающих
            NoobMan();
            NoobGirl();

            //Cброс веса.
            SlimmingGirl();
            SlimmingMan();

            //Бодибилдинг
            BodyBuildingGirl();
            BodyBuildingMan();

            //Турник дома
            AthomeHorizontalbarMan();

            //В домашних условиях
            AtHomeConditions();

            //Фулбоди
            FullbodyMan();
            FullbodyGirl();

        }

        #region Новичок
        private static void NoobMan()
        {

            var des = @"Программа призначена для начинающих, которые хотят увеличить объемы мышц, стать накаченными.Им нужно программа тренировок на массу для начинающих. Она должна включать в себя базовые упражнения.";
        
            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,"Training/Noobman/Day1/Кардио.jpg",0,5,"минут"),
                new Exercise ("Жим штанги лежа",100,"Training/Noobman/Day1/Жим штанги лежа.jpg",2,10,"раз"),
                new Exercise ("Разведение гантелей лежа",100,"Training/Noobman/Day1/Разведение гантелей лежа.jpg",2,10,"раз"),
                new Exercise ("Разгибание рук на блоке",100,"Training/Noobman/Day1/Разгибание рук на блоке.jpg",2,10,"раз"),
                new Exercise ("Жим гантели из-за головы",100,"Training/Noobman/Day1/Жим гантели из-за головы.jpg",2,10,"раз"),
                new Exercise ("Пресс",100,"Training/Noobman/Day1/Пресс.png",3,10,"раз")
            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,"Training/Noobman/Day1/Кардио.jpg",0,6,"минут"),
                new Exercise ("Приседания с пустым грифом",100,"Training/Noobman/Day2/Приседания с пустым грифом.jpg",2,10,"раз"),
                new Exercise ("Жим ногами в тренажере",100,"Training/Noobman/Day2/Жим ногами в тренажере.jpg",2,10,"раз"),
                new Exercise ("Жим гантелей сидя",100,"Training/Noobman/Day2/Жим гантелей сидя.jpg",2,10,"раз"),
                new Exercise ("Тяга грифа к подбородку",100,"Training/Noobman/Day2/Тяга грифа к подбородку.jpg",2,10,"раз"),
                new Exercise ("Пресс",100,"Training/Noobman/Day1/Пресс.png",2,15,"раз")
            };


            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,"Training/Noobman/Day1/Кардио.jpg",0,7,"минут"),
                new Exercise ("Гиперэкстензия",100,"Training/Noobman/Day3/Гиперэкстензия.jpg",2,15,"раз"),
                new Exercise ("Тяга верхнего блока",100,"Training/Noobman/Day3/Тяга верхнего блока.jpg",2,10,"раз"),
                new Exercise ("Сгибание рук с грифом на бицепс",100,"Training/Noobman/Day3/Сгибание рук с грифом на бицепс.jpg",2,10,"раз"),
                new Exercise ("Молот",100,"Training/Noobman/Day3/Молот.jpg",2,10,"раз"),
                new Exercise ("Пресс",100,"Training/Noobman/Day1/Пресс.png",3,10,"раз")

            };

            var ex = new Dictionary<string, List<Exercise>>();

            ex.Add("День 1", day1);
            ex.Add("День 2", day2);
            ex.Add("День 3", day3);
            Trainings.Add(new Training("Для новичков мужчин", des, ex));

        }



        private static void NoobGirl()
        {

            var des =
             @"Легкую зарядку продолжительностью 10-20 минут можно выполнять каждый день. 
              Для более интенсивных занятий, длящихся 45-60 минут, выделите три дня в неделю, чтобы организм успевал восстанавливаться. 
             Перед каждой тренировкой хорошенько разминайтесь – делайте суставную гимнастику или кардио средней интенсивности. 
             Для заминки после тренировки делайте растяжку (но не переусердствуйте) и легкое кардио (быстрая ходьба, кручение обруча, велосипед).";

           
            List<Exercise> day1 = new List<Exercise>()
            {
                 new Exercise ("Выпады в движении",100,"Training/Noobgril/Day1/Lunges-with-dumbbells.jpg",4,20,"(по 10 шагов на каждую ногу)"),
                 new Exercise ("Махи ногами назад, стоя на четвереньках",100,"Training/Noobgril/Day1/mahi-nogami.jpg",4,15,"раз"),
                 new Exercise ("Тяга верхнего блока к груди",100,"Training/Noobgril/Day1/Тяга-блока-к-груди.png",5,10,"раз"),
                 new Exercise ("Разведение рук в стороны в наклоне",100,"Training/Noobgril/Day1/razvedeniya-ruk-v-naklone-dlya-devushek.jpg",4,12,"раз"),
                 new Exercise ("Сведение рук лежа с гантелями",100,"Training/Noobgril/Day1/DSC_5501_1545278749-630x315.jpg",4,12,"раз"),
                 new Exercise ("Скручивания корпуса лежа",100,"Training/Noobgril/Day1/skruchivaniya-kak-pravilno-delat_20.jpg",4,20,"раз")
            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Румынская становая тяга (с гантелями или эспандером)",100,"Training/Noobgril/Day2/Румынская становая тяга.jpg",5,10,"раз"),
                new Exercise ("Ягодичный мостик (без отягощения или с блином)",100,"Training/Noobgril/Day2/Ягодичный мостик.jpg",4,12,"раз"),
                new Exercise ("Подъем рук стоя через стороны с гантелями",100,"Training/Noobgril/Day2/Подъем рук стоя через стороны.jpg",4,12,"раз"),
                new Exercise ("Тяга гантели к поясу в наклоне",100,"Training/Noobgril/Day2/Тяга гантели к поясу в наклоне.jpg",4,10,"раз"),
                new Exercise ("Разгибание рук из-за головы с гантелью",100,"Training/Noobgril/Day2/Разгибание рук из-за головы с гантелью.jpg",3,12,"раз"),
                new Exercise ("Подъем ног лежа",100,"Training/Noobgril/Day2/Подъем ног лежа.jpg",4,15,"раз")
            };

            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Приседания с широкой постановкой ног (без отягощения или с гантелью),",100,"Training/Noobgril/Day3/Приседания с широкой постановкой ног.jpg",5,10,"раз"),
                new Exercise ("Гиперэкстензия",100,"Training/Noobgril/Day3/Гиперэкстензия.jpg",4,15,"раз"),
                new Exercise ("Отжимания от пола",100,"Training/Noobgril/Day3/Отжимания от пола.jpg",4,10,"раз"),
                new Exercise ("Тяга верхнего блока к груди",100,"Training/Noobgril/Day1/Тяга-блока-к-груди.png",4,10,"раз"),
                new Exercise ("Сгибания рук с гантелями",100,"Training/Noobgril/Day3/Сгибания рук с гантелями.jpg",4,10,"раз"),
                new Exercise ("Планка",100,"Training/Noobgril/Day3/планка.jpg",3,1,"минуте")

            };
          
            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("День 1", day1);
            ex.Add("День 2", day2);
            ex.Add("День 3", day3);
            Trainings.Add(new Training("Для новичков женщин", des, ex));
        }
        #endregion
        #region Сброс веса 
        private static void SlimmingGirl()
        {
            var des = @"Предпочтительнее заниматься в зале трижды в неделю. Например, если тренировки для сжигания жира будут проходить в понедельник, среду и пятницу.
                        Данная программа направлена на формирование и рельефообразование мышц всего тела с упором на проблемные женские зоны.";


            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,30,"минут"),
                new Exercise ("Приседание со штангой",100,"Training/SlimmingGirl/Day1/Приседание со штангой.jpg",3,15,"кг"),
                new Exercise ("Приседания плие",100,"Training/SlimmingGirl/Day1/Приседания плие.jpg",3,15,"раз"),
                new Exercise ("Выпады с гантелями",100,"Training/SlimmingGirl/Day1/Выпады с гантелями.jpg",3,20,"на каждую ногу"),
                new Exercise ("Гиперэкстензия",100,"Training/Noobgril/Day3/Гиперэкстензия.jpg",2,20,"раз"),
                new Exercise ("Сгибание рук с гантелями",100,"Training/Noobgril/Day3/Сгибания рук с гантелями.jpg",3,20,"раз"),
                new Exercise ("Пресс подъем туловища на римском стуле и подъем ног лежа.",100,"Training/SlimmingGirl/Day1/Пресс подъем туловища на римском стуле и подъем ног лежа..jpg",3,30,"раз"),
                new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,15,"минут")

            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,30,"минут"),
                new Exercise ("Гиперэкстензия",100,"Training/Noobgril/Day3/Гиперэкстензия.jpg",2,20,"раз"),
                new Exercise ("Румынская тяга",100,"Training/SlimmingGirl/Day2/Румынская тяга.jpg",3,15,"раз"),
                new Exercise ("Сведение ног в тренажере",100,"Training/SlimmingGirl/Day2/Сведение ног в тренажере.jpg",2,20,"раз"),
                new Exercise ("Жим гантелей лежа",100,"Training/SlimmingGirl/Day2/Жим гантелей лежа.jpg",2,20,"раз"),
                new Exercise ("Разведение рук с гантелями на горизонтальной скамье",100,"Training/SlimmingGirl/Day2/Разведение рук с гантелями на горизонтальной скамье.jpg",2,20,"раз"),
                new Exercise ("Разведение рук с гантелями на скамье под углом 30 градусов",100,"Training/SlimmingGirl/Day2/Разведение рук с гантелями на скамье под углом 30 градусов.jpg",2,20,"раз"),
                new Exercise ("Разгибания с верхним блоком",100,"Training/SlimmingGirl/Day2/Разгибание рук на блоке.jpg",3,20,"раз"),
                new Exercise ("Косые скручивания",100,"Training/SlimmingGirl/Day2/Косые скручивания.jpg",3,20,"на каждую сторону"),
                new Exercise ("Подъем туловища на полу",100,"Training/SlimmingGirl/Day2/Подъем туловища на полу.jpg",4,20,"раз"),
                new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,10,"минут")

            };


            List<Exercise> day3 = new List<Exercise>()
            {  new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,20,"минут"),
               new Exercise ("Жим ногами",100,"Training/SlimmingGirl/Day3/Жим ногами (стопы на верхней части платформы, расставлены широко).jpg",2,15,"раз"),
               new Exercise ("Разгибание ног в тренажере",100,"Training/SlimmingGirl/Day3/Разгибание ног в тренажере.jpg",0,20,"минут"),
               new Exercise ("Сведение ног в тренажере",100,"Training/SlimmingGirl/Day2/Сведение ног в тренажере.jpg",2,20,"раз"),
               new Exercise ("Подъем на носки на икры",100, "Training/SlimmingGirl/Day3/Подъем на носки на икры.jpg",4,30,"раз"),
               new Exercise ("Жим гантелей сидя",100,"Training/SlimmingGirl/Day3/Жим гантелей сидя.jpg",3,20,"раз"),
               new Exercise ("Разведение гантелей через стороны",100,"Training/SlimmingGirl/Day3/Разведение гантелей через стороны.jpg",3,15,"раз"),
               new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,20,"минут")
            };



            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("Понедельник", day1);
            ex.Add("Среда", day2);
            ex.Add("Пятница", day3);
            Trainings.Add(new Training("Похудения для девушек", des, ex));
        }

        private static void SlimmingMan()
        {
            var des = @"Программа тренировок для сушки мышц тела направлена на максимальное сжигание жира и сохранение мышечной массы.
             В программе тренировок для сушки мышц тела можно менять упражнения, но день, в который они проводятся, а также стиль тренировок (высокоинтенсивный, объёмный или силовой) – нельзя. Количество повторений, сетов, упражнений и время отдыха должны быть такими, как указано в программе.
             Тренировки проводятся по дням:Понедельник,Вторник,Четверг.Остальные дни Отдых. Если есть желание и силы, можно сделать кардио вечером (для ускорения процесса сушки мышц).
             ";
            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Жим ногами",100,"Training/SlimmingMan/Day1/Жим ногами.jpg", 3,15,"раз"),
                new Exercise ("Сгибание ног",100,"Training/SlimmingMan/Day1/Сгибание ног.jpg",3,15,"раз"),
                new Exercise ("Жим лёжа",100,"Training/SlimmingMan/Day1/Жим штанги лёжа.jpg",3,15,"раз"),
                new Exercise ("Тяга нижнего блока",100,"Training/SlimmingMan/Day1/Тяга нижнего блока.jpg",3,15,"раз"),
                new Exercise ("Разведение рук с гантелями стоя",100,"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg",2,20,"раз"),
                new Exercise ("Подъёмы на икры",100,"Training/SlimmingMan/Day1/Подъёмы на икры.jpg",3,15,"раз"),
                new Exercise ("Подъём штанги на бицепс стоя",100,"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg",2,15,"раз"),
                new Exercise ("Разгибания рук на блоке на трицепс",100,"Training/SlimmingMan/Day1/Разгибания рук на блоке на трицепс.jpg",2,15,"раз")

            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Жим ногами",100,"Training/SlimmingMan/Day1/Жим ногами.jpg", 3,15,"раз"),
                new Exercise ("Сгибание ног",100,"Training/SlimmingMan/Day1/Сгибание ног.jpg",3,15,"раз"),
                new Exercise ("Жим штанги лёжа на наклонной скамье",100,"Training/SlimmingMan/Day2/Жим штанги лёжа на наклонной скамье.jpg",3,15,"раз"),
                new Exercise ("Тяга верхнего блока к груди",100,"Training/Noobman/Day3/Тяга верхнего блока.jpg",3,15,"раз"),
                new Exercise ("Разведение рук с гантелями стоя",100,"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg",3,15,"раз"),
                new Exercise ("Подъёмы на икры",100,"Training/SlimmingMan/Day1/Подъёмы на икры.jpg",3,15,"раз"),
                new Exercise ("Подъём штанги на бицепс стоя",100,"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg",2,15,"раз"),
                new Exercise ("Разгибания рук на блоке на трицепс",100,"Training/SlimmingMan/Day1/Разгибания рук на блоке на трицепс.jpg",2,15,"раз")

            };


            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Жим ногами",100,"Training/SlimmingMan/Day1/Жим ногами.jpg", 2,15,"раз"),
                new Exercise ("Сгибание ног стоя",100,"Training/SlimmingMan/Day3/Сгибание ног стоя.jpg", 2,15,"раз"),
                new Exercise ("Разгибания ног в тренажёре",100,"Training/SlimmingMan/Day3/Разгибания ног в тренажёре.jpg", 1,12,"раз"),
                new Exercise ("Сгибание ног",100,"Training/SlimmingMan/Day1/Сгибание ног.jpg",1,16,"раз"),
                new Exercise ("Подъёмы на икры",100,"Training/SlimmingMan/Day1/Подъёмы на икры.jpg",3,16,"раз"),
                new Exercise ("Жим лёжа",100,"Training/SlimmingMan/Day1/Жим штанги лёжа.jpg",2,12,"раз"),
                new Exercise ("Тяга нижнего блока",100,"Training/SlimmingMan/Day1/Тяга нижнего блока.jpg",2,12,"раз"),
                new Exercise ("Жим штанги лёжа на наклонной скамье",100,"Training/SlimmingMan/Day2/Жим штанги лёжа на наклонной скамье.jpg",1,12,"раз"),
                new Exercise ("Тяга верхнего блока к груди",100,"Training/Noobman/Day3/Тяга верхнего блока.jpg",1,12,"раз"),
                new Exercise ("Разведение рук с гантелями стоя",100,"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg",2,12,"раз"),
                new Exercise ("Подъём штанги на бицепс стоя",100,"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg",2,12,"раз"),
                new Exercise ("Разгибания рук на блоке на трицепс",100,"Training/SlimmingMan/Day1/Разгибания рук на блоке на трицепс.jpg",2,12,"раз")

            };


            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("Понедельник", day1);
            ex.Add("Вторник", day2);
            ex.Add("Четверг", day3);
            Trainings.Add(new Training("Похудение для мальчиков", des, ex));
        }
        #endregion
        #region  Бодибилдинг
        private static void BodyBuildingGirl()
        {
            var des = @"Ваши тренировки должны быть направлены в сторону наращивания мышечной массы и потери жира, это будет способствовать улучшению форм, повышению упругости и тонуса мышц, и поможет сохранить соблазнительные изгибы женского тела.";

            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Жим гантелей лежа на горизонтальной скамье",100,"Training/BodyBuildingGirl/Day1/Жим гантелей лежа на горизонтальной скамье.jpg", 2,10,"раз"),
                new Exercise ("Жим гантелей лежа на наклонной скамье",100,"Training/BodyBuildingGirl/Day1/Жим гантелей лежа на наклонной скамье.jpg",2,10,"раз"),
                new Exercise ("Сведение рук в кроссовере",100,"Training/BodyBuildingGirl/Day1/Сведение рук в кроссовере.png",2,10,"раз"),
                new Exercise ("Разгибание рук стоя на нижнем блоке",100,"Training/BodyBuildingGirl/Day1/Разгибание рук стоя на нижнем блоке.jpg",2,8,"раз"),
                new Exercise ("Отжимания на брусьях",100,"Training/BodyBuildingGirl/Day1/Отжимания на брусьях.jpg",1,8,"раз"),
                new Exercise ("Жим на плечи в тросовом тренажёре сидя",100,"Training/BodyBuildingGirl/Day1/Жим на плечи в тросовом тренажёре.PNG",3,10,"раз"),
                new Exercise ("Фронтальный подъём штанги над головой",100,"Training/BodyBuildingGirl/Day1/Фронтальный подъём штанги над головой .png",2,10,"раз"),
                new Exercise ("Разведение рук с гантелями на горизонтальной скамье",100,"Training/SlimmingGirl/Day2/Разведение рук с гантелями на горизонтальной скамье.jpg",2,10,"раз")
            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Подтягивания",100,"Training/BodyBuildingGirl/Day2/Подтягивания.jpg", 3,8,"раз"),
                new Exercise ("Подтягивания обратным хватом",100,"Training/BodyBuildingGirl/Day2/Подтягивания обратным хватом.jpg", 2,10,"раз"),
                new Exercise ("Подъем EZ-штанги на бицепс на скамье Скотта",100,"Training/BodyBuildingGirl/Day2/Подъем EZ-штанги на бицепс на скамье Скотта.jpeg", 2,10,"раз"),
                new Exercise ("Попеременный подъем гантелей на бицепс стоя",100,"Training/BodyBuildingGirl/Day2/Попеременный подъем гантелей на бицепс стоя.jpg", 1,12,"раз")
            };


            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Приседания со штангой",100,"Training/BodyBuildingGirl/Day3/Приседания со штангой.jpg", 2,15,"раз"),
                new Exercise ("Становая тяга в машине Смита с прямыми ногами",100,"Training/BodyBuildingGirl/Day3/Становая тяга в машине Смита с прямыми ногами.jpg", 2,15,"раз"),
                new Exercise ("Выпад с гантелями вперед",100,"Training/BodyBuildingGirl/Day3/Выпад с гантелями вперед.jpg", 2,15,"раз"),
                new Exercise ("Выпады со штангой в сторону",100,"Training/BodyBuildingGirl/Day3/Выпады со штангой в сторону.jpg", 2,15,"раз"),
                new Exercise ("Подъем на носки на одной ноге",100,"Training/BodyBuildingGirl/Day3/Подъем на носки на одной ноге.jpg", 2,15,"раз"),

            };


            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("День 1", day1);
            ex.Add("День 2", day2);
            ex.Add("День 3", day3);
            Trainings.Add(new Training("Бодибилдинг для девушек", des, ex));
        }

        private static void BodyBuildingMan()
        {
            var des = @"Упражнения бодибилдинг тренировок на массу.Базовые(или многосуставные) упражнения – это упражнения, где задействовано сразу несколько групп мышц и работают несколько суставов. Приседания, становая тяга,жим лежа, подтягивания, тяга штанги кпоясу в наклоне, отжимания на брусьях– все это базовые упражнения.Какправило, они – самые тяжелые для выполнения. Но они же – самое эффективноесредство для набора мышечной массы.База – платформа, на которой строитсяпрограмма тренировок на массу вбодибилдинге. Изолирующие упражнения– те, которые прорабатывают лишь однумышцу (и задействуют один сустав. Втренинге на массу они второстепенны ивыступают лишь как дополнение дляотстающих мышц.";
          
            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Приседания со штангой",100,"Training/BodyBuildingMan/Day1/Приседания со штангой.jpeg", 3,10,"раз"),
                new Exercise ("Жим ногами в тренажере ",100,"Training/Noobman/Day2/Жим ногами в тренажере.jpg", 3,10,"раз"),
                new Exercise ("Жим штанги стоя ",100,"Training/BodyBuildingMan/Day1/Жим штанги стоя.jpg", 3,8,"раз"),
                new Exercise ("Тяга штанги к подбородку  ",100,"Training/Noobman/Day2/Тяга грифа к подбородку.jpg", 3,10,"раз"),
                new Exercise ("Пресс ",100,"Training/Noobman/Day1/Пресс.png", 3,50,"раз"),


            };

            List<Exercise> day2 = new List<Exercise>()
            {
                new Exercise ("Cтановая тяга",100,"Training/BodyBuildingMan/Day2/Cтановая тяга.jpg", 3,8,"раз"),
                new Exercise ("Подтягивания",100,"Training/BodyBuildingMan/Day2/Подтягивания.jpg", 3,15,"раз"),
                new Exercise ("Жим лежа узким хватом",100,"Training/BodyBuildingMan/Day2/Жим лежа узким хватом.jpg", 3,10,"раз"),
                new Exercise ("Французский жим",100,"Training/BodyBuildingMan/Day2/Французский жим.jpg", 3,10,"раз"),
                new Exercise ("Пресс ",100,"Training/Noobman/Day1/Пресс.png", 3,50,"раз")

            };


            List<Exercise> day3 = new List<Exercise>()
            {
                new Exercise ("Жим штанги лежа",100,"Training/Noobman/Day1/Жим штанги лежа.jpg", 3,8,"раз"),
                new Exercise ("Жим штанги на наклонной скамье",100,"Training/SlimmingMan/Day2/Жим штанги лёжа на наклонной скамье.jpg", 3,10,"раз"),
                new Exercise ("Разводка гантелей ",100,"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg", 3,12,"раз"),
                new Exercise ("Подъем штанги на бицепс ",100,"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg", 3,10,"раз"),
                new Exercise ("Пресс ",100,"Training/Noobman/Day1/Пресс.png", 3,50,"раз")

            };

            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("Понедельник(ноги, плечи)", day1);
            ex.Add("Среда(спина, трицепс)", day2);
            ex.Add("Пятница(грудь, бицепс)", day3);
            Trainings.Add(new Training("Бодибилдинг для мужчин", des, ex));
        }
        #endregion
        #region  Турник дома
        private static void AthomeHorizontalbarMan()
        {
            var des = @"Набор упражнений для занятий  дома,требует гантели  и турник.";
           
            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Подтягивания",100,"Training/BodyBuildingGirl/Day2/Подтягивания.jpg",2,5,"раз"),
                new Exercise ("Подтягивания обратным хватом",100,"Training/BodyBuildingGirl/Day2/Подтягивания обратным хватом.jpg",2,5,"раз"),
                new Exercise ("Подтягивание широким хватом",100,"Training/AthomeHorizontalbarMan/Day1/Подтягивание широким хватом.jpg",2,5,"раз"),
                new Exercise ("Отжимания от пола",100,"Training/AthomeHorizontalbarMan/Day1/Отжимания от пола.jpg",2,5,"раз"),

            };

            List<Exercise> day2 = new List<Exercise>()
            {
                 new Exercise ("Приседания",100,"Training/AthomeHorizontalbarMan/Day2/Приседания.jpg",3,10,"раз"),
                 new Exercise ("Приседания с выпрыгиванием",100,"Training/AthomeHorizontalbarMan/Day2/Приседания с выпрыгиванием.jpg",3,10,"раз"),
                 new Exercise ("Приседания с гантелями плие",100,"Training/AthomeHorizontalbarMan/Day2/Приседания с гантелями плие.jpg",3,10,"раз"),
                 new Exercise ("Скручивания на пресс на наклоной скамье",100,"Training/AthomeHorizontalbarMan/Day2/Скручивания на пресс на наклоной скамье.jpg",3,10,"раз"),
                 new Exercise ("Обратное скручивание",100,"Training/AthomeHorizontalbarMan/Day2/Обратное скручивание.jpg",3,10,"раз"),
                 new Exercise ("Планка",100,"Training/Noobgril/Day3/планка.jpg",2,10,"секунд"),
                 new Exercise ("Лодка",100,"Training/AthomeHorizontalbarMan/Day2/Лодка.jpg",3,10,"раз")
            };


            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("День 1", day1);
            ex.Add("День 2", day2);
            
            Trainings.Add(new Training("Турник дома", des, ex));

        }
        #endregion
        #region В домашних условиях
        private static void AtHomeConditions()
        {
            var des = @"Цель: Базовое развитие мышц и поднятие тонуса организма.Универсальный набор упражнений для занятий дома с гантелями.Отлично подходит для поддержания тонуса, не выходя из дома или для предварительной подготовки к походу в зал.В наклоне со штангой можно использовать гантели.";
           
            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Скручивания корпуса лежа",100,"Training/Noobgril/Day1/skruchivaniya-kak-pravilno-delat_20.jpg",3,10,"раз"),
                new Exercise ("Выпады с гантелями",100,"Training/Noobgril/Day1/Lunges-with-dumbbells.jpg",3,10,"(по 10 шагов на каждую ногу)"),
                new Exercise ("Отжимания от пола",100,"Training/AthomeHorizontalbarMan/Day1/Отжимания от пола.jpg",3,5,"раз"),
                new Exercise ("Приседания с гантелями",100,"Training/AtHomeConditions/Day1/Приседания с гантелями.jpg",3,10,"раз"),
                new Exercise ("Пуловер лежа с гантелями",100,"Training/AtHomeConditions/Day1/Пуловер лежа с гантелями.jpg",3,5,"раз"),
                new Exercise ("Французский жим с гантелями сидя",100,"Training/Noobman/Day1/Жим гантели из-за головы.jpg",2,10,"раз")
            };

            List<Exercise> day2 = new List<Exercise>()
            {  new Exercise ("Подем корпуса",100,"Training/AtHomeConditions/Day2/Подем корпуса.jpg",3,10,"раз"),
               new Exercise ("Тяга одной гантели в наклоне",100,"Training/AtHomeConditions/Day2/Тяга одной гантели в наклоне.jpg",3,10,"раз"),
               new Exercise ("Отжимания от пола",100,"Training/AthomeHorizontalbarMan/Day1/Отжимания от пола.jpg",3,5,"раз"),
               new Exercise ("Наклоны со штангой на плечах",100,"Training/AtHomeConditions/Day2/Наклоны со штангой на плечах.jpg",3,10,"раз"),

            };

            List<Exercise> day3 = new List<Exercise>()
            {  new Exercise ("Подем ног в висе",100,"Training/AtHomeConditions/Day3/Подем ног в висе.jpg",3,10,"раз"),
               new Exercise ("Жим арнольда",100,"Training/AtHomeConditions/Day3/Жим арнольда.jpg",2,10,"раз"),
               new Exercise ("Лодка",100,"Training/AthomeHorizontalbarMan/Day2/Лодка.jpg",3,10,"раз"),
               new Exercise ("Разведение гантелей через стороны",100,"Training/SlimmingGirl/Day3/Разведение гантелей через стороны.jpg",3,10,"раз"),
               new Exercise ("Подъем гантелей перед собой",100,"Training/AtHomeConditions/Day3/Подъем гантелей перед собой.jpg",3,10,"раз"),
               new Exercise ("Концентрированный подъем на бицепс",100,"Training/AtHomeConditions/Day3/Концентрированный подъем на бицепс.jpg",3,10,"раз"),
               new Exercise ("Шраги с гантелями стоя",100,"Training/AtHomeConditions/Day3/Шраги с гантелями стоя.jpg",3,10,"раз")


            };

  
            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("День 1", day1);
            ex.Add("День 2", day2);
            ex.Add("День 3", day3);
            Trainings.Add(new Training("В домашних условиях", des, ex));
        }
        #endregion
        #region Фулбоди
        private static void FullbodyMan()
        {
            var des = @"  Подойдет для начинающих, упор на базовые упражнения без перегрузки изолирующими.  Базовые упражнения - это тип упражнений, которые включают в работу несколько мышц или групп мышц, может задействоваться сразу несколько суставов. Как правило, это тяжелые упражнения, которые выполняются со свободным весом.Альтернатива базовому сплиту, для тех у кого мало времени.Будьте аккуратны, и не допустите перетренированности.";
          
            List<Exercise> day1 = new List<Exercise>()
            {
                new Exercise ("Приседания со штангой",100,"Training/BodyBuildingMan/Day1/Приседания со штангой.jpeg", 3,10,"раз"),
                new Exercise ("Жим штанги широким хватом ",100,"Training/FullbodyMan/Day1/Жим штанги лежа широким хватом.jpg", 3,15,"раз"),
                new Exercise ("Подтягивания прямым хватом",100,"Training/BodyBuildingMan/Day2/Подтягивания.jpg", 3,15,"раз"),
                new Exercise ("Армейский жим стоя",100,"Training/FullbodyMan/Day1/Армейский жим стоя.jpg", 3,15,"раз"),
                new Exercise ("Разведение гантелей лежа на скамье",100,"Training/FullbodyMan/Day1/Разведение гантелей лежа на скамье.png", 3,15,"раз")
            };

            List<Exercise> day2 = new List<Exercise>()
            {
               new Exercise ("Cтановая тяга",100,"Training/BodyBuildingMan/Day2/Cтановая тяга.jpg", 3,8,"раз"),
               new Exercise ("Отжимания на брусьях",100,"Training/FullbodyMan/Day2/Отжимания на брусьях.jpg", 3,8,"раз"),
               new Exercise ("Подтягивания обратным хватом",100,"Training/FullbodyMan/Day2/Подтягивания прямым хватом.jpg", 3,8,"раз"),
               new Exercise ("Подъем гантелей через стороны",100,"Training/SlimmingMan/Day1/Разведение рук с гантелями стоя.jpg", 3,8,"раз"),
               new Exercise ("Подъём штанги на бицепс стоя",100,"Training/SlimmingMan/Day1/Подъём штанги на бицепс стоя.jpg",2,15,"раз"),

            };

            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("День 1", day1);
            ex.Add("День 2", day2);
            Trainings.Add(new Training("Фулбоди для мальчиков", des, ex));

        }

        private static void FullbodyGirl()
        {
            var des = @"Глaвными инcтpyмeнтaми coздaния идeaльнoй фигypы дeвyшeк и жeнщин являютcя cилoвыe тpeниpoвки и кapдиoнaгpyзки. Cилoвыe yпpaжнeния пoзвoляют вылeпливaть cвoe тeлo, пoдoбнo cкyльптopy, нapaщивaя в нyжныx мecтax мышeчный oбъeм, a кapдиoнaгpyзки избaвляют oт лишниx жиpoвыx oтлoжeний. Ho paбoтaют эти инcтpyмeнты тoлькo в coвoкyпнocти c пpaвильным питaниeм. ";
           

            List<Exercise> day1 = new List<Exercise>()
            {  new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,10,"минут"),
               new Exercise ("Тяга верхнего блока к груди",100,"Training/Noobgril/Day1/Тяга-блока-к-груди.png",3,20,"раз"),
               new Exercise ("Тяга горизонтального блока",100,"Training/FullbodyGirl/Day1/Тяга горизонтального блока.jpg",4,20,"раз"),
               new Exercise ("Разведение рук на горизонтальной скамье",100,"Training/SlimmingGirl/Day2/Разведение рук с гантелями на горизонтальной скамье.jpg",2,10,"раз"),
               new Exercise ("Жим гантелей сидя",100,"Training/SlimmingGirl/Day3/Жим гантелей сидя.jpg",4,20,"раз"),
               new Exercise ("Французский жим сидя",100,"Training/FullbodyGirl/Day1/Французский жим сидя.jpg",4,20,"раз"),
               new Exercise ("Упражнение молот",100,"Training/FullbodyGirl/Day1/Упражнение молот.jpg",4,25,"раз"),
               new Exercise ("Жим ногами",100,"Training/SlimmingGirl/Day3/Жим ногами (стопы на верхней части платформы, расставлены широко).jpg",4,15,"раз"),
               new Exercise ("Скручивания на пресс на наклоной скамье",100,"Training/FullbodyGirl/Day1/Скручивания наклонной скамье.jpg",3,25,"раз"),
               new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,20,"минут"),
               new Exercise ("Растяжка",100,"Training/FullbodyGirl/Day1/Растяжка.PNG",0,10,"минут")
            };

            List<Exercise> day2 = new List<Exercise>()
            {
              new Exercise ("Разминка – суставная гимнастика",100,"Training/FullbodyGirl/Day1/Разминка.jpg",0,40,"минут"),
              new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,40,"минут"),
              new Exercise ("Растяжка",100,"Training/FullbodyGirl/Day1/Растяжка.PNG",0,10,"минут")
            };

            List<Exercise> day3 = new List<Exercise>()
            {
              new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,40,"минут"),
              new Exercise ("Т-тяга на тренажере",100,"Training/FullbodyGirl/Day2/Т-тяга на тренажере.PNG",0,10,"минут"),
              new Exercise ("Жим в хаммере",100,"Training/FullbodyGirl/Day2/Жим в хаммере.jpg",0,10,"минут"),
              new Exercise ("Разведение с гантелями на дельты",100,"Training/FullbodyGirl/Day2/Разведение с гантелями на дельты.jpg",0,10,"минут"),
              new Exercise ("Разгибания с верхним блоком",100,"Training/SlimmingGirl/Day2/Разгибание рук на блоке.jpg",3,20,"раз"),
              new Exercise ("Сгибания с нижним блоком",100,"Training/FullbodyGirl/Day2/Сгибания с нижним блоком.jpg",0,10,"минут"),
              new Exercise ("Гиперэкстензия",100,"Training/Noobgril/Day3/Гиперэкстензия.jpg",2,20,"раз"),
              new Exercise ("Подьемы ног в висе",100,"Training/FullbodyGirl/Day2/Подьемы ног в висе.jpg",0,10,"минут"),
              new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,20,"минут"),
              new Exercise ("Растяжка",100,"Training/FullbodyGirl/Day1/Растяжка.PNG",0,10,"минут")
            };


            List<Exercise> day4 = new List<Exercise>()
            {
              new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,10,"минут"),
              new Exercise ("Тяга штанги в наклоне",100,"Training/FullbodyGirl/Day3/Тяга штанги в наклоне.jpg",4,20,"раз"),
              new Exercise ("Тяга горизонтального блока",100,"Training/FullbodyGirl/Day1/Тяга горизонтального блока.jpg",4,20,"раз"),
              new Exercise ("Сведения на тренажере рук в бабочка",100,"Training/FullbodyGirl/Day3/Сведения на тренажере рук в бабочка.jpg",4,20,"раз"),
              new Exercise ("Жим гантелей сидя",100,"Training/SlimmingGirl/Day3/Жим гантелей сидя.jpg",3,20,"раз"),
              new Exercise ("Отжимания на брусьях",100,"Training/BodyBuildingGirl/Day1/Отжимания на брусьях.jpg",1,8,"раз"),
              new Exercise ("Упражнение молот",100,"Training/FullbodyGirl/Day1/Упражнение молот.jpg",4,25,"раз"),
              new Exercise ("Скручивания на пресс на наклоной скамье",100,"Training/FullbodyGirl/Day1/Скручивания наклонной скамье.jpg",3,25,"раз"),
              new Exercise ("Кардио",100,"Training/SlimmingGirl/Day1/Кардио.jpg",0,20,"минут"),
              new Exercise ("Растяжка",100,"Training/FullbodyGirl/Day1/Растяжка.PNG",0,10,"минут")
            };

        
            var ex = new Dictionary<string, List<Exercise>>();
            ex.Add("Понедельник", day1);
            ex.Add("Вторник,Четверг,Суббота", day2);
            ex.Add("Среда", day3);
            ex.Add("Пятница", day4);
            Trainings.Add(new Training("Фулбоди для девушек", des, ex));

        }
        #endregion




        public static Training GetTraining(string type)
        {
            var training = Trainings.Where(t => t.Type == type).FirstOrDefault();
            return training;
        }

        public static List<Training> GetTrainings() => Trainings;


    }

}

