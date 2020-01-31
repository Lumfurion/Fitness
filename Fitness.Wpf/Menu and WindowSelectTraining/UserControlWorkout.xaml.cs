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
            trainingController.SelectProgram();
            

            //Пвязки
            ICTraining.ItemsSource = trainingController.SelectProgram();
            ICEdit.ItemsSource = trainingController.SelectProgram();
            ICSelectProgram.ItemsSource = trainingController.GetAllPrograms();

        }

        private void Look_Click(object sender, RoutedEventArgs e)
        {
            object tag = (sender as FrameworkElement).Tag;
            string name = tag.ToString();
            AboutExercise aboutExercise = new AboutExercise();
            aboutExercise.SetData(name);
            aboutExercise.ShowDialog();
        }

        private void AddExercise_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string Key = button.Tag.ToString();
            MessageBox.Show(Key);
            ChoiceExercise cex = new ChoiceExercise(Key);
            cex.ShowDialog();
            ICTraining.ItemsSource = null;
            ICEdit.ItemsSource = null;

            trainingController.Update();

            //Пвязки
            ICTraining.ItemsSource = trainingController.SelectProgram();
            ICEdit.ItemsSource = trainingController.SelectProgram();


        }

        private void DeleteExercise_Click(object sender, RoutedEventArgs e)
        {
            
            Button button = (Button)sender;
            string Key = button.Tag.ToString(); 
            string name = button.Uid.ToString();
            MessageBox.Show(name+"\n"+ Key);

            trainingController.Delete(Key, name);

            //Обновление
            ICTraining.Items.Refresh();
            ICEdit.Items.Refresh();
        }

        private void EditExercise_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string Key = button.Tag.ToString();
            string name = button.Uid.ToString();
        
            ChoiceExercise cex = new ChoiceExercise(Key, name, "EditExercise");
            cex.ShowDialog();

            UpDate();

        }

     

        private void ButtonSelectOnClick(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
            string type = button.Tag.ToString();
            trainingController.ChangeProgram(type);  
            UpDate();
        }




        private void AddnewDayOnClick(object sender, RoutedEventArgs e)
        {
            trainingController.AddNewDay();

            UpDate();
        }


        private void btnDeleteDayOnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string day = button.Tag.ToString();
            MessageBox.Show(day);
            trainingController.DeleteDay(day);

            UpDate();

        }

        private void UpDate()
        {
            ICTraining.ItemsSource = null;
            ICEdit.ItemsSource = null;

            trainingController.Update();

            //Пвязки
            ICTraining.ItemsSource = trainingController.SelectProgram();
            ICEdit.ItemsSource = trainingController.SelectProgram();
        }


    }
}
