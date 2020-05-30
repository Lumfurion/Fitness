using Fitness.BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Программа тренировок.
    /// </summary>
    [Serializable]
    public class Training
    {

        #region Cвойство
        /// <summary>
        /// Имя пользователя который выбрал программу тренировок.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип тренировки.
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///Будет хранить выбрал или пользователь тренировку true-да false-нет
        /// </summary>
        public bool isSelected { get; set; } = false;

        /// <summary>
        ///Сколько за день пользователь должен выполнить упражнений.
        /// </summary>
        public Dictionary<string, List<Exercise>> Exercises { get; set; }
        #endregion

        public Training()
        {
           Exercises = new Dictionary<string, List<Exercise>>();
        }

        public Training(string name, string type, string description, Dictionary<string, List<Exercise>> exercises,bool isSelected)
        {
            Name = name;
            Type = type;
            Description = description;
            Exercises = exercises;
            this.isSelected = isSelected;
        }

        public Training(string type, string description, Dictionary<string, List<Exercise>> exercises)
        {
            Type = type;
            Description = description;
            Exercises = exercises;
        }

        public void Add(string day, List<Exercise> exercises)
        {   
            if(exercises == null)
            {
                throw new ArgumentException("Не выделена память для хранения упражний");
            }
           

            if (!Exercises.ContainsKey(day))
            {
                Exercises.Add(day, exercises);
            }
            else
            {
                foreach (var ex in exercises)
                {
                    Exercises[day].Add(new Exercise(ex.Name, ex.CaloriesPerMinute, ex.Image, ex.Amount, ex.Сount, ex.Designation));
                }
            }
        }


        public void Delete(string key, string name)
        {
            var exercise = Exercises[key].Where(ex => ex.Name == name).FirstOrDefault();
            if (exercise != null)
            {
                Exercises[key].Remove(exercise);
            }
            else
            {
                throw new ArgumentException("Нету такого упражнения для удаления");
            }
            
        }
       
        public void Replacement(string key, string replace, string whatToreplace)
        {
            var idexwhatToreplace = Exercises[key].FindIndex(trainings => trainings.Name == whatToreplace);

            ExerciseController exerciseController = new ExerciseController();
            var exercisereplace = exerciseController.GetExercise(replace);
           
            if(exercisereplace == null)
            {
                throw new ArgumentException("Нету такого упражнения на замену.");
            }

            foreach ( var e in Exercises[key])
            {
                if(e.Name == whatToreplace)//ищем что будем менять 
                {
                    Exercises[key][idexwhatToreplace] = exercisereplace;
                   
                    break;
                }
            }


        }
        

    }
}
