using Fitness.BusinessLogic.Controller;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Fitness.Wpf
{
   
    public partial class TrainingInfo : Window
    {
        UserController userController { get; }
        TrainingController trainingController { get; }
        string type { get;  }

        public TrainingInfo(string type)
        {
            InitializeComponent();
            this.type = type;
            userController = new UserController(UserController.CurrentUserName);
            trainingController = new TrainingController();
            btnMan.Click += Gender;
            btnWomen.Click += Gender;

            trainingController.SelectTraining($"{type}Man");
            ICTraining.ItemsSource = trainingController.CurrentTraining;
            DataContext = trainingController;

        }

        private void Gender(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var name = button.Name;

            ICTraining.ItemsSource = null;
            DataContext = null;
            
            switch (type)
            {
                case "Noob":
                    if (name == btnMan.Name)
                    {
                        trainingController.SelectTraining("NoobMan");
                        
                    }
                    else if (name == btnWomen.Name)
                    {
                        trainingController.SelectTraining("NoobGirl");
                        
                    }
                    break;

                case "Slimming":
                    if (name == btnMan.Name)
                    {
                        trainingController.SelectTraining("SlimmingMan");

                    }
                    else if (name == btnWomen.Name)
                    {
                        trainingController.SelectTraining("SlimmingGirl");

                    }
                    break;

            }
            
            ICTraining.ItemsSource = trainingController.CurrentTraining;
            DataContext = trainingController;
            
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
           
            trainingController.Saver();
            if (trainingController.Select == true)
            {
                Close();
            }
        }
    }
}
