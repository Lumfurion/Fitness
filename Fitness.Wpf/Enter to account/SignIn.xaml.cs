﻿using Fitness.BusinessLogic.Controller;
using System.Windows;
using System.Linq;

namespace Fitness.Wpf
{
    public partial class MainWindow : Window
    {
        UserController user { get; set; }
        TrainingController trainingController { get; }

        public MainWindow()
        {
            InitializeComponent();
           
            trainingController = new TrainingController();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            user = new UserController();
            

            bool  name = user.Users.Any(u => u.Name == tbUsername.Text);

            if (name == false)
            {
                MessageBox.Show("Нет такого пользователя");    
            }
            else
            {
                user = new UserController(tbUsername.Text);
                trainingController.Update();

                if(user.CurrentUser.Password == tbPassword.Password)
                {
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
                    MessageBox.Show("Пароль неправильный");
                }

            }       

        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            reg.Show();
            Close();
        }
    }
}