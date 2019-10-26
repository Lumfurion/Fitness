using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Model
{
    [Serializable]
    public class Training
    {
 
        #region Cвойство
        /// <summary>
        ///День и cколько пользователь дожен сделать упражений.
        /// </summary>
        public Dictionary<string, List<Exercise>> Exercises { get; set; }

        /// <summary>
        /// Описание закрепляем за типом тренировки.
        /// </summary>
        public Dictionary<string,string> DescriptionSet { get; }
       
        /// <summary>
        /// Будет хранить пользователя тип тренировки когда выбрал.
        /// </summary>
        public List<SelectedWorkout> selectedWorkouts { get; }
        #endregion

        public Training()
        {
            Exercises = new Dictionary<string, List<Exercise>>();
            DescriptionSet = new Dictionary<string, string>();
            selectedWorkouts = new List<SelectedWorkout>();
            
        }


       
        public void AddTraining(string day, List<Exercise> exercises)
        {
            if (!Exercises.ContainsKey(day))
            {
                Exercises.Add(day, exercises);
            }
            else
            {
                foreach (var ex in exercises)
                {
                    Exercises[day].Add(new Exercise(ex.Name, ex.CaloriesPerMinute, ex.Start, ex.Finish,ex.Image,ex.Amount,ex.Сount,ex.Designation,ex.Description));
                }
            }


        }


    }
}
