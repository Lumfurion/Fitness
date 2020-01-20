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
            object tag = (sender as FrameworkElement).Tag;
            string day = tag.ToString();
            MessageBox.Show(day);
            ChoiceExercise cex = new ChoiceExercise(day);
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

            //Обновление
            ICTraining.ItemsSource = null;
            ICEdit.ItemsSource = null;

            trainingController.Update();

            //Пвязки
            ICTraining.ItemsSource = trainingController.SelectProgram();
            ICEdit.ItemsSource = trainingController.SelectProgram();

        }
        
        private void ButtonSelectOnClick(object sender, RoutedEventArgs e)
        {

            Button button = (Button)sender;
       
            string type = button.Tag.ToString();
            switch (type)
            {
                case "Для новичков Мужчин":
                    trainingController.ChangeProgram("NoobMan");
                    break;

                case "Для новичков Женщин":
                    trainingController.ChangeProgram("NoobGirl");
                    break;
            }

            ICTraining.ItemsSource = null;
            ICEdit.ItemsSource = null;

            trainingController.Update();

            //Пвязки
            ICTraining.ItemsSource = trainingController.SelectProgram();
            ICEdit.ItemsSource = trainingController.SelectProgram();

        }

        private void AddnewDayOnClick(object sender, RoutedEventArgs e)
        {
            var choice= new ChoiceExercise();
            choice.ShowDialog();
            var ex=choice.GetExercise();
            MessageBox.Show(ex);
            trainingController.AddNewDay(ex);

            ICTraining.ItemsSource = null;
            ICEdit.ItemsSource = null;

            trainingController.Update();

            //Пвязки
            ICTraining.ItemsSource = trainingController.SelectProgram();
            ICEdit.ItemsSource = trainingController.SelectProgram();
        }
    }
}
