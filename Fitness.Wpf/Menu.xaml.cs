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
       
        UserControl usc = null;

        public Home()
        {
            InitializeComponent();
            userController = new UserController(UserController.CurrentUserName);
            
            Initwindow();
        }

        private void Initwindow()
        {
            lbUser.Content = UserController.CurrentUserName;
            if (userController.Image != null)
            {
                elpUserAvatar.Fill = new ImageBrush(new BitmapImage(new Uri(userController.Image)));
            }

            recStatistic.Visibility = Visibility.Hidden;
            recEating.Visibility = Visibility.Hidden;
            recworkout.Visibility = Visibility.Hidden;
            recPrint.Visibility = Visibility.Hidden;


            GridContent.Children.Clear();
            usc = new UserControlHome();
            GridContent.Children.Add(usc);

            #region Привязки кнопок меню
            btnHome.Click += Click_Button;
            btnWorkout.Click += Click_Button;
            btnEating.Click += Click_Button;
            btnStatistic.Click += Click_Button;
            btnPrint.Click += Click_Button;
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
                    recStatistic.Visibility = Visibility.Hidden;
                    recworkout.Visibility = Visibility.Hidden;
                    recPrint.Visibility = Visibility.Hidden;
                    break;

                case "Workout":
                    recHome.Visibility = Visibility.Hidden;
                    recEating.Visibility = Visibility.Hidden;
                    recStatistic.Visibility = Visibility.Hidden;
                    recworkout.Visibility = Visibility.Visible;
                    recPrint.Visibility = Visibility.Hidden;
                    break;

                case "Eating":
                    recHome.Visibility = Visibility.Hidden;
                    recEating.Visibility = Visibility.Visible;
                    recStatistic.Visibility = Visibility.Hidden;
                    recworkout.Visibility = Visibility.Hidden;
                    recPrint.Visibility = Visibility.Hidden;
                    break;
                case "Statistic":
                    recHome.Visibility = Visibility.Hidden;
                    recEating.Visibility = Visibility.Hidden;
                    recStatistic.Visibility = Visibility.Visible;
                    recworkout.Visibility = Visibility.Hidden;
                    recPrint.Visibility = Visibility.Hidden;
                    break;

                case "Print":
                    recHome.Visibility = Visibility.Hidden;
                    recEating.Visibility = Visibility.Hidden;
                    recStatistic.Visibility = Visibility.Hidden;
                    recworkout.Visibility = Visibility.Hidden;
                    recPrint.Visibility = Visibility.Visible;
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
                    usc = new UserControlEating();
                    GridContent.Children.Add(usc);
                    break;
                case "btnStatistic":
                    ShowItemSelected("Statistic");
                    usc = new UserControlStatistic();
                    GridContent.Children.Add(usc);
                    break;
                case "btnPrint":
                    ShowItemSelected("Print");
                    usc = new UserControlPrint();
                    GridContent.Children.Add(usc);
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
