using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Services.Initializers;
using System.Windows;
using System.Windows.Controls;

namespace Fitness.Wpf
{
    public partial class ChoiceFood : Window
    {
        readonly string Etingtime;
        readonly string Whatr;
        readonly FoodDiaryController foodDiaryController;

        public ChoiceFood(string etingtime, string whatr = " ")
        {
            InitializeComponent();
            ICEating.ItemsSource = InitializingFoods.Foods;
            
            Etingtime = etingtime;
            Whatr = whatr;
            foodDiaryController = new FoodDiaryController();
        }

        private void btnAddOnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var name = button.Tag.ToString();
           
            if(Whatr == " " )
            {
                foodDiaryController.Add(name, Etingtime);
            }
            else if(!string.IsNullOrEmpty(Whatr))
            {
                foodDiaryController.Replacement(Whatr, name, Etingtime);
            }
            Close();
        }
    }
}
