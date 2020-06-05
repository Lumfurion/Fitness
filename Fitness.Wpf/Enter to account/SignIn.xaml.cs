using Fitness.BusinessLogic.Controller;
using System.Windows;
using System.Linq;
using System.Windows.Input;

namespace Fitness.Wpf
{
    public partial class MainWindow : Window
    {
        private  UserController user { get; set; }
        readonly TrainingController trainingController;

        public MainWindow()
        {
            InitializeComponent();
            trainingController = new TrainingController();
            user = new UserController();

        }

       


        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            user.UpDate();//если есть новый пользователь.
            bool name = user.isExist(tbUsername.Text);

            if (!name)
            {
               tberrorlogin.Text="Нет такого пользователя";
               brError.Visibility = Visibility.Visible;
            }
            else if (user.CurrentUser.Password == tbPassword.Text)
            {
                    brError.Visibility = Visibility.Collapsed;
                    tberrorlogin.Text = "";
                    tberrorpasword.Text = " ";
                   
                    trainingController.Update();
                   
                    if (trainingController.CurrentUserSelectsTraining() == false)
                    {
                        ChoiceTraining training = new ChoiceTraining();
                        training.Show();
                        Close();
                    }
                    else
                    {
                        Home home = new Home();
                        home.Show();
                        Close();
                    }
  
            }
            else
            {
                brError.Visibility = Visibility.Visible;
                tberrorpasword.Text = "Пароль неправильный";
            }

        }

     

        private void btnCloseOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void lbRegistrationOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            Close();
        }
    }
}
