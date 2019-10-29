using Fitness.BusinessLogic.Controller;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Fitness.Wpf
{  

    public partial class ChoiceTraining : Window
    {
        readonly string  name = UserController.CurrentUserName;
        readonly UserController userController;
        public TrainingController trainingController;
        TrainingInfo trainingInfo { get; set; }
        DispatcherTimer timer = new DispatcherTimer();
  
        public ChoiceTraining()
        {
            InitializeComponent();
            userController = new UserController(name);
            trainingController = new TrainingController();
            Initwindow();
        
        }

        #region Масштабирование интерфейса 

        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(MainWindow), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));

        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            ChoiceTraining mainWindow = o as ChoiceTraining;
            if (mainWindow != null)
                return mainWindow.OnCoerceScaleValue((double)value);
            else
                return value;
        }

        private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ChoiceTraining mainWindow = o as ChoiceTraining;
            if (mainWindow != null)
                mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }

        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
                return 1.0f;

            value = Math.Max(0.1, value);
            return value;
        }

        protected virtual void OnScaleValueChanged(double oldValue, double newValue)
        {

        }

        public double ScaleValue
        {
            get
            {
                return (double)GetValue(ScaleValueProperty);
            }
            set
            {
                SetValue(ScaleValueProperty, value);
            }
        }


        private void MainGrid_SizeChanged(object sender, EventArgs e)
        {
            CalculateScale();
        }

        private void CalculateScale()
        {
            double yScale = ActualHeight / 520f;//Height
            double xScale = ActualWidth / 920f;//Width
            double value = Math.Min(xScale, yScale);
            ScaleValue = (double)OnCoerceScaleValue(window, value);
        }
        #endregion


        private void Initwindow()
        {   try
            {
                if (userController.Image != null)//если пользователя нет картинки.
                {
                    elpUserAvatar.Fill = new ImageBrush(new BitmapImage(new Uri(userController.Image)));
                }
            }
            catch
            {

            }
            lbUser.Content = name;

            #region Служебные кнопки
            //Кнопки
            btnClose.MouseLeftButtonUp += btnSystemButton_MouseLeftButtonUp;
            btnExpend.MouseLeftButtonUp += btnSystemButton_MouseLeftButtonUp;
            btnСollapse.MouseLeftButtonUp += btnSystemButton_MouseLeftButtonUp;

            //Подсветка при наведении
            btnClose.MouseEnter += ButtunsLight_MouseEnter;
            btnExpend.MouseEnter += ButtunsLight_MouseEnter;
            btnСollapse.MouseEnter += ButtunsLight_MouseEnter;

            //Подсветка при покидание зоны наведения
            btnClose.MouseLeave += ButtunsLight_MouseLeave;
            btnExpend.MouseLeave += ButtunsLight_MouseLeave;
            btnСollapse.MouseLeave += ButtunsLight_MouseLeave;
            #endregion

            #region Просмотр и выбор тренировки.
            btnNoob.Click += Click_LookTraining;
            btnBodyBuilding.Click += Click_LookTraining;
            btnslimming.Click += Click_LookTraining;
            btnAthome.Click += Click_LookTraining;
            btnAthomeHorizontalbar.Click += Click_LookTraining;
            btnFullbody.Click += Click_LookTraining;
            btnExperienced.Click += Click_LookTraining;
            btnExtreme.Click += Click_LookTraining;
            #endregion

            

            //Вызваем обробочик каждих 0.1 секунду timer_tick.
            //Интервал устанавливается в 0.1 секунду с помощью TimeSpan объекта, и запускается таймер.
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_tick;
            timer.Start();

        }

        private void timer_tick(object sender, EventArgs e)
        {
            trainingController.Update();
            if (trainingController.CurrentUserSelectsTraining() == true)
            {  
               timer.Stop();
               Home home=new Home();
               home.Show();
               Close();
            }
        }

        private void Click_LookTraining(object sender, RoutedEventArgs e)
        {
            Button button = null;

            if (sender is Button)
            {
                button = (Button)sender;
            }
          
            var name = button.Name;

            switch (name)
            {
                case "btnNoob":
                    trainingInfo = new TrainingInfo("Noob");
                    break;
                case "btnslimming":
                    trainingInfo = new TrainingInfo("Slimming");
                    break;
                case "btnBodyBuilding":
                    trainingInfo = new TrainingInfo("BodyBuilding");
                    break;
                case "btnAthomeHorizontalbar":
                    trainingInfo = new TrainingInfo("AthomeHorizontalbar");
                    break;
                case "btnAthome":
                    trainingInfo = new TrainingInfo("AtHomeConditions");
                    break;

                case "btnFullbody":
                    trainingInfo = new TrainingInfo("Fullbody");
                    break;
            }

            trainingInfo.ShowDialog();
      
        }

       


        /// <summary>
        /// Перемещение интерфейса
        /// </summary>
        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #region Cлужебные кнопки
        private void btnSystemButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            string name = border.Name;
         
            switch (name)
            {
                case "btnClose":
                    Close();
                    break;
                case "btnExpend":
                    if (WindowState == WindowState.Normal)
                    {
                        window.WindowState = WindowState.Maximized;  
                    }
                    else
                    {
                        window.WindowState = WindowState.Normal;
                    }
                    break;
                case "btnСollapse":
                    window.WindowState = WindowState.Minimized;
                    break;
            }
           
           
        }
        private void ButtunsLight_MouseEnter(object sender, MouseEventArgs e)
        {

            Border button = (Border)sender;
            if (button.Name == "btnClose")
            {
                btnClose.Background = Brushes.Red;
            }
            else if (button.Name == "btnExpend")
            {
                btnExpend.Background = Brushes.White;
                btnExpend.Opacity = 0.8; 
            }
            else
            {
                btnСollapse.Background = Brushes.White;
                btnСollapse.Opacity = 0.8;
            }

        }
        private void ButtunsLight_MouseLeave(object sender, MouseEventArgs e)
        {

            Border button = (Border)sender;
            if (button.Name == "btnClose")
            {
                btnClose.Background = Brushes.White;
            }
            else if (button.Name == "btnExpend")
            {
                btnExpend.Background = Brushes.White;
                btnExpend.Opacity = 1;
            }
            else
            {
                btnСollapse.Background = Brushes.White;
                btnСollapse.Opacity =1;
            }
        }
        #endregion



        private void btnUserAvatar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (ofd.ShowDialog()==true)
            {
              
                elpUserAvatar.Fill = new ImageBrush(new BitmapImage(new Uri(ofd.FileName)));
                userController.Image = ofd.FileName;
            }
        }

        
    }
   
}
