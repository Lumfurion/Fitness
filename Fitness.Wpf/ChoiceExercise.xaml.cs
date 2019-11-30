using Fitness.BusinessLogic.Controller;
using System.Windows;

namespace Fitness.Wpf
{
    
    public partial class ChoiceExercise : Window
    {
        private readonly ExerciseController excerseController;
        private readonly TrainingController trainingController;
        readonly string Day;
        private string excerse;

        public ChoiceExercise()
        {
            InitializeComponent();
            excerseController = new ExerciseController();
            trainingController = new TrainingController();
            ICTraining.ItemsSource = excerseController.Exercises;
        }


        public ChoiceExercise(string day)
        {
            InitializeComponent();
            excerseController = new ExerciseController();
            trainingController = new TrainingController();
            Day = day;
            ICTraining.ItemsSource = excerseController.Exercises;
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            object tag = (sender as FrameworkElement).Tag;
            string name = tag.ToString();
            MessageBox.Show(name + "\n" + Day);
            excerse = name;
            if(!string.IsNullOrEmpty(Day))
            {
                trainingController.AddExerciseinProgram(Day, name);
            }
            Close();
        }

        public string GetExercise() => excerse;

    }
}
