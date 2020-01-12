using Fitness.BusinessLogic.Controller;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Fitness.Wpf
{
   
    public partial class UserControlPrint : UserControl
    {
        readonly UserController userController;
        readonly TrainingController trainingController;
        readonly FoodDiaryController foodDiaryController;
        public UserControlPrint()
        {
            InitializeComponent();
            userController = new UserController(UserController.CurrentUserName);
            trainingController = new TrainingController();
            foodDiaryController = new FoodDiaryController();
            BindingControllers();

        }

        private void BindingControllers()
        {   var CurrentTraining= trainingController.SelectProgram();
            var foodDiaries = foodDiaryController.UserFoodDiary;

            ICTraining.ItemsSource = CurrentTraining;
            ICUserFoodDiary.ItemsSource = foodDiaries;
        }

        private void Print(string type)
        {
            PrintDialog printDialog = new PrintDialog();
            if (type == "Training")
            {
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(ICTraining, "Распечатываем тренировку");
                }
            }
            else if(type == "Eating")
            {
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(ICUserFoodDiary, "Распечатываем Дневник приема пищи");
                }
            }
        }

        private void btnPrintOnClick(object sender,RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var name = btn.Name;
            switch(name)
            {
                case "btnPrintTraining":
                Print("Training");
                    break;

                case "btnPrintEating":
                    Print("Eating");
                    break;
            }
            
        }
    }
}
