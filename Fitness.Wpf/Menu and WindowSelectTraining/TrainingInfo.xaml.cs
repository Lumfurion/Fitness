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

            var training = SetupDefaultTraining(type);
            trainingController.SelectTraining(training);
            ICTraining.ItemsSource = trainingController.CurrentTraining;
            DataContext = trainingController;

        }

        private string SetupDefaultTraining(string type)
        {
            string trainingname = " ";
            switch(type)
            {
                case "База для начинающих":
                   trainingname = "Для новичков мужчин";
                    break;

                case "Сбросить вес":
                    trainingname = "Похудение для мальчиков";
                    break;

                case "Бодибилдинг":
                    trainingname = "Бодибилдинг для мужчин";
                    break;

                case "Турник дома":
                    trainingname = "Турник дома";
                    break;

                case "В домашних условиях":
                    trainingname = "В домашних условиях";
                    break;

                case "Фулбоди для начинающих":
                    trainingname = "Фулбоди для мальчиков";
                    break;

            }

            return trainingname;
        }

        /// <summary>
        ///Информация об упражнении.
        /// </summary>
        /// <param name="type"></param>
        private void Look_Click(object sender, RoutedEventArgs e)
        {
            object tag = (sender as FrameworkElement).Tag;
            string name = tag.ToString();
            AboutExercise aboutExercise = new AboutExercise();
            aboutExercise.SetData(name);
            aboutExercise.ShowDialog();
        }

        /// <summary>
        /// Выбор тренировки.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="man"></param>
        /// <param name="girl"></param>
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
                case "База для начинающих":
                    SelectGender(name, "Для новичков мужчин", "Для новичков женщин");
                    break;

                case "Сбросить вес":
                    SelectGender(name, "Похудение для мальчиков", "Похудения для девушек");
                    break;
                case "Бодибилдинг":
                    SelectGender(name, "Бодибилдинг для мужчин", "Бодибилдинг для девушек");
                    break;
                case "Турник дома":
                    lbMessege.Text = "Это тренировка подходит для всех пол не нужно выбирать.";
                    break;
                case "В домашних условиях":
                    lbMessege.Text = "Это тренировка подходит для всех пол не нужно выбирать.";
                    break;
                case "Фулбоди для начинающих":
                    SelectGender(name, "Фулбоди для мальчиков", "Фулбоди для девушек");
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
