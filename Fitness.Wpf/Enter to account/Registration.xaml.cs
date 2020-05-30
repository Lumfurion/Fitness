using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Services;
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
        {
            var login = Verification.Login(tbUsername.Text);
            if(login)
            {
                user = new UserController(tbUsername.Text);
            }
            else
            {
                MessageBox.Show("Имя пользователя пустое или меньше 5 символов или больше 15 символов");
                return;
            }

            if (!user.isNewUser)
            {
                MessageBox.Show("Такой пользователь уже есть");
            }
            else if (user.isNewUser == true)
            {
                var password = tbPassword.Text;
                var gender = Gender;
                var date = tbdateday.Text + "." + tbdatemonth.Text + "." + tbdateyear.Text;
                DateTime birtdayDate;
                var weight = Convert.ToInt32(tbweight.Text);
                var height = Convert.ToInt32(tbheight.Text);

                if (!Verification.Password(password))
                {
                    MessageBox.Show("Пароль пустой или меньше 10 символов или больше 20 символов");
                    return;
                }

                if (!Verification.Date(date))
                {
                    MessageBox.Show("Некорректно введена дата");
                    return;
                }
                else
                {
                    birtdayDate = Convert.ToDateTime(date);
                }
                user.SetNewUserData(gender, password, birtdayDate, weight, height);

                signIn.Show();
                Close();
            }

        }

       
    }
}
