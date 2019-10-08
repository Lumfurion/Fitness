using Fitness.BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fitness.Wpf
{

    public partial class Registration : Window
    {
        UserController user { get; set; }
        MainWindow signIn { get; set; }
        public Registration()
        {
            InitializeComponent();
            signIn = new MainWindow();
            reg.Closed += Reg_Closed;    
        }

        private void Reg_Closed(object sender, EventArgs e)
        {
            signIn.Show();
        }

        private void TbSave_Click(object sender, RoutedEventArgs e)
        {   //Проверка.
           
            user = new UserController(tbUsername.Text);
            if (!user.isNewUser)
            {
                MessageBox.Show("Такой пользователь уже есть");
            }
            else if (user.isNewUser == true)
            {
                var password = tbPassword.Password;
                var gender = tbGender.Text;
                var birtdayDate = Convert.ToDateTime(tbbirthdayDate.Text);
                var weight = Convert.ToInt32(tbweight.Text);
                var height = Convert.ToInt32(tbheight.Text);
                user.SetNewUserData(gender,password,birtdayDate,weight,height);

                signIn.Show();
                Close();
            }


        }
    }
}
