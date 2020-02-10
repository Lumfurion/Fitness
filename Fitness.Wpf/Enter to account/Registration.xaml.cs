using Fitness.BusinessLogic.Controller;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Fitness.Wpf
{

    public partial class Registration : Window
    {
        private string Gender { get; set; }
        private UserController user { get; set; }
        readonly MainWindow signIn;

        public Registration()
        {
            InitializeComponent();
            signIn = new MainWindow();
            reg.Closed += Reg_Closed;

            rbМan.Checked += RadioButton_Checked;
            rbWoman.Checked += RadioButton_Checked;
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            Gender = pressed.Content.ToString();
        }

        private void Reg_Closed(object sender, EventArgs e)
        {
            signIn.Show();
        }

        private void btnCloseOnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void tbSaveOnClick(object sender, RoutedEventArgs e)
        {   //Проверка.

            user = new UserController(tbUsername.Text);
            if (!user.isNewUser)
            {
                MessageBox.Show("Такой пользователь уже есть");
            }
            else if (user.isNewUser == true)
            {
                var password = tbPassword.Text;
                var gender = Gender;
                var date = tbdateday.Text + "." + tbdatemonth.Text + "." + tbdateyear.Text;
                var birtdayDate = Convert.ToDateTime(date);
                var weight = Convert.ToInt32(tbweight.Text);
                var height = Convert.ToInt32(tbheight.Text);
                user.SetNewUserData(gender, password, birtdayDate, weight, height);

                signIn.Show();
                Close();
            }

        }

       
    }
}
