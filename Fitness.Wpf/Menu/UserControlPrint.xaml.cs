using Fitness.BusinessLogic.Controller;
using System.Windows;
using System.Windows.Controls;
using Fitness.BusinessLogic.Printing_document;

namespace Fitness.Wpf
{
   
    public partial class UserControlPrint : UserControl
    {
        readonly TrainingController trainingController;
        readonly FoodDiaryController foodDiaryController;
       
        public UserControlPrint()
        {
            InitializeComponent();
  
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


        private void btnPrintOnClick(object sender,RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var name = btn.Name;
            switch(name)
            {
                case "btnPrintTraining":
                    Printing.Workout();
                    break;

                case "btnPrintEating":
                    Printing.FoodDiary();
                    break;
            }
            
        }
    }
}
