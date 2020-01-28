using Fitness.BusinessLogic.Controller;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Fitness.Wpf
{

    public partial class AboutExercise : Window
    {
        readonly ExerciseController exerciseController;
        public AboutExercise()
        {
            InitializeComponent();
            exerciseController = new ExerciseController();
            InitializeElement();
        }

        private void InitializeElement()
        {
            btnPlay.MouseLeftButtonDown += ClickButtonGirl;
            btnPause.MouseLeftButtonDown += ClickButtonGirl;
            btnStop.MouseLeftButtonDown += ClickButtonGirl;

            btnPlay2.MouseLeftButtonDown += ClickButtonMan;
            btnPause2.MouseLeftButtonDown += ClickButtonMan;
            btnStop2.MouseLeftButtonDown += ClickButtonMan;
        }

        private void ClickButtonGirl(object sender, MouseButtonEventArgs e)
        {
            var ellipse = (Ellipse)sender;
            var name = ellipse.Tag;
            switch (name)
            {
                case "Play":
                    PlayerGirl.Play();
                    break;
                case "Pause":
                    PlayerGirl.Pause();
                    break;
                case "Stop":
                    PlayerGirl.Stop();
                    PlayerGirl.Position = TimeSpan.Zero;
                    PlayerGirl.Play();
                    break;
            }
        }


        private void ClickButtonMan(object sender, MouseButtonEventArgs e)
        {
            var ellipse = (Ellipse)sender;
            var name = ellipse.Tag;
            switch (name)
            {
                case "Play":
                    PlayerMan.Play();
                    break;
                case "Pause":
                    PlayerMan.Pause();
                    break;
                case "Stop":
                    PlayerMan.Stop();
                    PlayerMan.Position = TimeSpan.Zero;
                    PlayerMan.Play();
                    break;
            }
        }

        public void SetData(string name)
        {
            DataContext = exerciseController.GetCurrentExerciseInfo(name);
        }


    }
}