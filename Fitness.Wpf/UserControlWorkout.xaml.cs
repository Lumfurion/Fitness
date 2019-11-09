using Fitness.BusinessLogic.Controller;
using System.Windows;
using System.Windows.Controls;

namespace Fitness.Wpf
{
    public partial class UserControlWorkout : UserControl
    {
        readonly UserController userController;
        readonly TrainingController trainingController;

        public UserControlWorkout()
        {
            InitializeComponent();
            userController = new UserController(UserController.CurrentUserName);
            trainingController = new TrainingController();
            trainingController.GetCurrentTraining();
            ICTraining.ItemsSource = trainingController.CurrentTraining;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Button button = (Button)sender;
            object tag = (sender as FrameworkElement).Tag;
            string name = tag.ToString();
            MessageBox.Show(name);
            AboutExercise aboutExercise = new AboutExercise();
            aboutExercise.SetData(name);
            aboutExercise.ShowDialog();
        }

    }
}
