using System;
namespace Fitness.BusinessLogic.Model
{   /// <summary>
    /// Упражнения
    /// </summary>
    [Serializable]
    public class Exercise
    {  /// <summary>
       ///Начало упражнения
       /// </summary>
        public DateTime Start { get; }
        /// <summary>
        /// Конец упражнения
        /// </summary>
        public DateTime Finish { get; }
        /// <summary>
        /// Какое упражнение делал пользователь
        /// </summary>
        public Activity Activity { get; }
        /// <summary>
        /// Какой пользователь
        /// </summary>
        public User User { get; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {   //Проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }


    }
}
