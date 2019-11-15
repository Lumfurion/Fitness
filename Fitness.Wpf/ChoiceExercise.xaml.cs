using Fitness.BusinessLogic.Controller;
using System.Windows;

namespace Fitness.Wpf
{
    
    public partial class ChoiceExercise : Window
    {
        private readonly ExerciseController excerseController;
        public ChoiceExercise()
        {
            InitializeComponent();
            excerseController = new ExerciseController();

            ICTraining.ItemsSource = excerseController.Exercises;
        }
    }
}
