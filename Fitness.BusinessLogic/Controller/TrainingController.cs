using Fitness.BusinessLogic.Model;
using Fitness.BusinessLogic.Services.Initializers;
using System.Collections.Generic;
using System.Linq;


namespace Fitness.BusinessLogic.Controller
{
    public class TrainingController : ControllerBase
    {
        #region Поля
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///Описание программы тренировок.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Тип тренировки.
        /// </summary>
        internal static string Type { get; set; }


        /// <summary>
        /// Хранит всех пользователей тренировки.
        /// </summary>
        private List<Training> Trainings { get; set; }

        /// <summary>
        /// Будет хранить тренировку текущего пользователя.
        /// </summary>
        public Dictionary<string, List<Exercise>> CurrentTraining { get; set; }
        #endregion

        public TrainingController()
        {   
            Name = UserController.CurrentUserName;
            CurrentTraining = new Dictionary<string, List<Exercise>>();
            Trainings = GetTraining();

        }


        #region Выбор тренировки.


        public void SelectTraining(string type)
        {    
            //CurrentTraining.Clear();
            var training = InitializingTraining.GetTraining(type);
            Type = type;
            Description = training.Description;
            CurrentTraining = training.Exercises;
        }
        #endregion



        /// <summary>
        /// Проверка выбрана тренировка.
        /// </summary>
        public bool CurrentUserSelectsTraining()
        {
            var rezalt = Trainings.Any(s => s.Name == Name && s.isSelected == true);
            return rezalt;
        }

        /// <summary>
        /// Получение всех програм.
        /// </summary>
        public List<Training> GetAllPrograms()
        {
            var programs = InitializingTraining.GetTrainings();
            return programs;
        }

     

        /// <summary>
        ///Получения типа выбранной программы.
        /// </summary>
        public string GetTypeSelectTraining()
        {
            var rezalt = Trainings.Where(t => t.Name == Name).FirstOrDefault();
            var type = rezalt.Type;
            return type;
        }




        #region Дабавление,Удаление,Измение,Получение программы
        /// <summary>
        /// Добавление программы.
        /// </summary>
        public void AddProgram(string name, string type, string description, Dictionary<string, List<Exercise>> exercises, bool selectedWorkouts)
        {
            Trainings.Add(new Training(name, type, description, exercises, selectedWorkouts));
            Save();
        }

        /// <summary>
        /// Удаление программы.
        /// </summary>
        private void DeleteProgram()
        {
            int index = Trainings.FindIndex(trainings => trainings.Name == Name && trainings.Type == Type);
            Trainings.RemoveAt(index);
            Save();
        }

        /// <summary>
        /// Изменить программу
        /// </summary>
        public void ChangeProgram(string name)
        {
            DeleteProgram();
            SelectTraining(name);
            Saver();
        }

        /// <summary>
        /// Получение программы.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Exercise>> SelectProgram()
        {
            Type = GetTypeSelectTraining();
            var rezalt = Trainings.Where(t => t.Name == Name && t.Type == Type).FirstOrDefault();
            var program = rezalt.Exercises;
            return program;
        }

        #endregion


        #region Удаление добавление дней 
        /// <summary>
        /// Добавить  день.
        /// </summary>
        public int AddNewDay()
        {
            var Count = SelectProgram().Keys.Count();//Получение количество деней.
            
            var day = $"День {++Count}";

            if (SelectProgram().Keys.Contains(day))
            {
                day = $"День {++Count}";
            }
            
            int index = Trainings.FindIndex(trainings => trainings.Name == Name && trainings.Type == Type);//Получения идекса.
            Trainings[index].Add(day, new List<Exercise>());
            Save();
            return Count;
        }
       
        /// <summary>
        /// Удалить день.
        /// </summary>
        public void DeleteDay(string day)
        {
            int index = Trainings.FindIndex(trainings => trainings.Name == Name && trainings.Type == Type);//Получения идекса.
            Trainings[index].Exercises.Remove(day);//удаление деня.
            Save();
        }
        #endregion

        #region Удаление,добавление,замена тренировок

        /// <summary>
        /// Использование функции для добавления тренировки.
        /// </summary>
        public void AddExerciseinProgram(string day, string name)
        {
            ExerciseController exerciseController = new ExerciseController();
            var exercise = exerciseController.GetExercise(name);//получение упражнения
            AddTraining(day, exercise);
        }

        /// <summary>
        /// Добавление тренировки.
        /// </summary>
        public void AddTraining(string day, Exercise exercise)
        {
            List<Exercise> temp = new List<Exercise>();
            int index = Trainings.FindIndex(trainings => trainings.Name == Name && trainings.Type == Type);//Получения идекса.
            temp.Add(exercise);
            Trainings[index].Add(day, temp);
            Save();
        }
        /// <summary>
        /// Удалить тренировку.
        /// </summary>
        public void Delete(string key, string name)
        {
            int index = Trainings.FindIndex(trainings => trainings.Name == Name && trainings.Type == Type);
            Trainings[index].Delete(key, name);
            Save();
        }

        /// <summary>
        /// Замена упражнения(тренировки)
        /// </summary>
        /// <param name="replace">На что нужно заменить</param>
        /// <param name="whatToreplace">Что хотят заменить</param>
        public void ReplacementExerciseinProgram(string key, string replace, string whatToreplace)
        {
            var training = Trainings.Where(t => t.Name == Name && t.Type == Type).FirstOrDefault();
            training.Replacement(key, replace, whatToreplace);
            Save();
        }

        #endregion



        /// <summary>
        /// Обновления данных.
        /// </summary>
        public void Update()
        {
            Name = UserController.CurrentUserName;
            Trainings = GetTraining();
        }

        private List<Training> GetTraining()
        {
           return Load<Training>() ?? new List<Training>();
        }

        /// <summary>
        /// Сохраняет  если пользователь не выбрал программу тренировок.
        /// </summary>
        public void Saver()
        {
            var isSuch = Trainings.Any(trainings => trainings.Name == Name && trainings.Type == Type);

            if (isSuch == false)//если пользователь не выбирал тренировку.
            {
                AddProgram(Name, Type, Description, CurrentTraining, true);
                Save();
            }

        }
        /// <summary>
        /// Сохранение программ тренировок в файл.
        /// </summary>
        private void Save()
        {
            Save(Trainings);
        }


    }
}
