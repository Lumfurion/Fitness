using Fitness.BusinessLogic.Controller;
using System;

namespace Fitness.BusinessLogic.Model
{
    public class SelectedWorkout
    {
        string Name { get; set; } 
        string Type { get; set; } 
        bool   isSelected { get; set; } = false;
        DateTime When { get; set; } 

        public void Select (bool vulue)
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
