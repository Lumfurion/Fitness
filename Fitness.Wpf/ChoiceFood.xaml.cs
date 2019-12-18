using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Services.Initializers;
using System.Windows;
using System.Windows.Controls;

namespace Fitness.Wpf
{
    public partial class ChoiceFood : Window
    {
        readonly string Etingtime;
        readonly FoodDiaryController foodDiaryController;
        public ChoiceFood(string etingtime)
        {
            InitializeComponent();
            ICEating.ItemsSource = InitializingFoods.Foods;
            
            Etingtime = etingtime;
            foodDiaryController = new FoodDiaryController();
        }

        private void btnAddOnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var name = button.Tag.ToString();
            foodDiaryController.Add(name, Etingtime);
            Close();
        }
    }
}
