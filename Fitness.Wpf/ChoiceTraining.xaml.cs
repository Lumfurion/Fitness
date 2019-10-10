using Fitness.BusinessLogic.Controller;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fitness.Wpf
{  

    public partial class ChoiceTraining : Window
    {
        readonly string name = UserController.CurrentUserName;
        enum Status
        {
            Expend, Normal
        }
        Status status = Status.Expend;
        public ChoiceTraining()
        {
            InitializeComponent();
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
         {
            lbUser.Content = name;
            
            //Кнопки
            btnClose.MouseLeftButtonUp += btnSystemButton_MouseLeftButtonUp;
            btnExpend.MouseLeftButtonUp += btnSystemButton_MouseLeftButtonUp;
            btnСollapse.MouseLeftButtonUp += btnSystemButton_MouseLeftButtonUp;

        }

        private void titleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

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
                    if (status == Status.Expend)
                    {
                        status = Status.Normal;
                        window.WindowState = WindowState.Maximized;  
                    }
                    else
                    {
                        status = Status.Expend;
                        window.WindowState = WindowState.Normal;
                    }
                    break;
                case "btnСollapse":
                    window.WindowState = WindowState.Minimized;
                    break;
            }
           
           
        }

       
    }
   
}
