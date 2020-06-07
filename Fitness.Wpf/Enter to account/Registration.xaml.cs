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
            #region Сбор данных с окна
            var login = tbUsername.Text;
            var password = tbPassword.Password;
            var gender = Gender;
            var date = tbdateday.Text + "." + tbdatemonth.Text + "." + tbdateyear.Text;
            var weight = tbweight.Text;
            var height = tbheight.Text;
            #endregion

            var vrlogin = Verification.Login(login);
            var vrpassword = Verification.Password(password);
            var vrgender = Verification.Gender(gender);
            var vrdate = Verification.Date(date);
            var vrweight = Verification.Weight(weight);
            var vrheight = Verification.Height(height);
            #region Проверки 
            if (vrlogin)
            {
                user = new UserController(login);
                tberrorlogin.Text = " ";
            }
            else
            {
                tberrorlogin.Text="Имя пользователя пустое или меньше 5 символов или больше 15 символов";
            }

            if (!vrpassword)
            {
                tberrorpasword.Text="Пароль пустой или меньше 10 символов или больше 20 символов";
            }
            else
            {
                tberrorpasword.Text= " ";
            }

            if (!vrgender)
            {
               tberrorgender.Text="Не выбран пол";
            }
            else
            {
                tberrorgender.Text = " ";
            }

            if (!vrdate)
            {
               tberrordate.Text="Некорректно введена дата";

            }
            else
            {
                tberrordate.Text = " ";
            }

            if (!vrweight)
            {
                tberrorweight.Text="Вес пустой или меньше 10 кг или больше 250 кг ";
            }
            else
            {
                tberrorweight.Text = " ";
            }

            if (!vrheight)
            {
                tberrorheight.Text="Рост пустой или меньше 50 cм или больше 250 см ";
            }
            else
            {
                tberrorheight.Text = " ";
            }
            if (!vrlogin || !vrpassword || !vrgender || !vrdate || !vrweight || !vrheight)
            {
                brError.Visibility = Visibility.Visible;
                return;
            }

            if (!vrlogin && !vrpassword && !vrgender && !vrdate && !vrweight && !vrheight)
            {
                brError.Visibility = Visibility.Visible;
                return;
            }
            #endregion

            var birtdayDate = Convert.ToDateTime(date);
            var conweight = Convert.ToInt32(weight);
            var conheight = Convert.ToInt32(height);
            if (!user.isNewUser)
            {
                MessageBox.Show("Такой пользователь уже есть!");
                return;
            }
            else if (user.isNewUser == true)
            {
                user.SetNewUserData(password,gender,birtdayDate, conweight, conheight);
                signIn.Show();
                Close();
            }

        }

       
    }
}
