using Fitness.BusinessLogic.Controller;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fitness.Wpf
{
    public partial class Home : Window
    {
        readonly UserController userController;
        readonly TrainingController trainingController;
        UserControl usc = null;

        public Home()
        {
            InitializeComponent();
            userController = new UserController(UserController.CurrentUserName);
            trainingController = new TrainingController();
            Initwindow();
        }

        private void Initwindow()
        {
            lbUser.Content = UserController.CurrentUserName;
            if(userController.Image!=null)
            {
                elpUserAvatar.Fill = new ImageBrush(new BitmapImage(new Uri(userController.Image)));
            }

            recDiet.Visibility = Visibility.Hidden;
            recEating.Visibility = Visibility.Hidden;
            recworkout.Visibility = Visibility.Hidden;

            GridContent.Children.Clear();
            usc = new UserControlHome();
            GridContent.Children.Add(usc);

            #region Привязки кнопок меню
            btnHome.Click += Click_Button;
            btnWorkout.Click += Click_Button;
            btnEating.Click += Click_Button;
            btnDiet.Click += Click_Button;
            #endregion

        }

        /// <summary>
        /// Будет отображать выбранный пункт меню.
        /// </summary>
        /// <param name="vulue"></param>
        private void ShowItemSelected(string vulue)
        {
            switch (vulue)
            {
                case "Home":
                    recHome.Visibility = Visibility.Visible;
                    recEating.Visibility = Visibility.Hidden;
                    recDiet.Visibility = Visibility.Hidden;
                    recworkout.Visibility = Visibility.Hidden;
                    break;

                case "Workout":
                    recHome.Visibility = Visibility.Hidden;
                    recEating.Visibility = Visibility.Hidden;
                    recDiet.Visibility = Visibility.Hidden;
                    recworkout.Visibility = Visibility.Visible;
                    break;

                case "Eating":
                    recHome.Visibility = Visibility.Hidden;
                    recEating.Visibility = Visibility.Visible;
                    recDiet.Visibility = Visibility.Hidden;
                    recworkout.Visibility = Visibility.Hidden;
                    break;
                case "Diet":
                    recHome.Visibility = Visibility.Hidden;
                    recEating.Visibility = Visibility.Hidden;
                    recDiet.Visibility = Visibility.Visible;
                    recworkout.Visibility = Visibility.Hidden;
                    break;

            }

        }

        private void Click_Button(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var namebutton= button.Name;
            GridContent.Children.Clear();

            switch (namebutton)
            {
                case "btnHome":
                    ShowItemSelected("Home");
                    usc = new UserControlHome();
                    GridContent.Children.Add(usc);
                    break;

                case "btnWorkout":
                    ShowItemSelected("Workout");
                    usc = new UserControlWorkout();
                    GridContent.Children.Add(usc);
                    break;

                case "btnEating":
                    ShowItemSelected("Eating");
                    //usc = new UserControlHome();
                    //GridContent.Children.Add(usc);
                    break;
                case "btnDiet":
                    ShowItemSelected("Diet");
                    //usc = new UserControlHome();
                    //GridContent.Children.Add(usc);
                    break;

            }


        }


        private void btnUserAvatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
