﻿using Fitness.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BusinessLogic.Controller
{   /// <summary>
    /// Упражнений Контроллер
    /// </summary>
    public class ExerciseController: ControllerBase
    {  
        private readonly User user;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может  быть  null.", nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }
        /// <summary>
        /// Дабавление физической активности.
        /// </summary>
        /// <param name="activityName"></param>
        /// <param name="beging"></param>
        /// <param name=""></param>
        public void Add(Activity activity, DateTime beging, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(beging, end,activity,user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(beging, end, activity, user);
                Exercises.Add(exercise);
            }
            Save();
        }
        /// <summary>
        ///Сохраняем упражнения.
        /// </summary>
        private void Save()
        {
            Save(Exercises);
            Save(Activities);
        }
    }
}
