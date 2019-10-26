using Fitness.BusinessLogic.Controller;
using System;

namespace Fitness.BusinessLogic.Model
{
    [Serializable]
    public class SelectedWorkout
    {
      
        /// <summary>
        ///Имя пользователя для которого выбрана тренировка.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///Тип тренировки.
        /// </summary>
        public string Type { get; set; }
        public bool isSelected { get; set; } = false;
        public DateTime When { get; set; }

        public SelectedWorkout(bool vulue)
        {
            isSelected = vulue;
            if (isSelected != false)
            {
                Name = UserController.CurrentUserName;
                Type = TrainingController.Type;
                When = DateTime.Now;
            }
        }
    }
}
