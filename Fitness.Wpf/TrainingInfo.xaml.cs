using Fitness.BusinessLogic.Controller;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Fitness.Wpf
{

    public partial class TrainingInfo : Window
    {
        readonly UserController userController;
        readonly TrainingController trainingController;
        string type { get; }

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


        private void SelectGender(string name,string man, string girl)
        {
            if (name == btnMan.Name)
            {
                trainingController.SelectTraining(man);

            }
            else if (name == btnWomen.Name)
            {
                trainingController.SelectTraining(girl);

            }

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
                    SelectGender(name, "NoobMan", "NoobGirl");
                    break;

                case "Slimming":
                    SelectGender(name, "SlimmingMan", "SlimmingGirl");
                    break;
                case "BodyBuilding":
                    SelectGender(name, "BodyBuildingMan", "BodyBuildingGirl");
                    break;
                case "AthomeHorizontalbar":
                    lbMessege.Text = "Это тренировка подходит для всех пол не нужно выбирать.";
                    break;

            }
            
            ICTraining.ItemsSource = trainingController.CurrentTraining;
            DataContext = trainingController;
            
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if(trainingController.CurrentUserSelectsTraining() != true)
            {
                trainingController.Saver();
                Close();
            }
 

        }
    }
}
