using Fitness.BusinessLogic.Controller;
using System.Windows;
using System.Windows.Controls;

namespace Fitness.Wpf
{
   
    public partial class UserControlEating : UserControl
    {
        readonly FoodDiaryController foodDiaryController;

        public UserControlEating()
        {
            InitializeComponent();
            foodDiaryController = new FoodDiaryController();
            DataContext = foodDiaryController;
        }
        /// <summary>
        /// Добавление тренировки.
        /// </summary>
        private void btnAddFoodOnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var EatingTime  = button.Tag.ToString();
            ChoiceFood choiceFood = new ChoiceFood(EatingTime);
            choiceFood.ShowDialog();
         
            ICUserFoodDiary.ItemsSource = null;
            foodDiaryController.Update();
            ICUserFoodDiary.ItemsSource = foodDiaryController.UserFoodDiary;
        }
        /// <summary>
        /// Выбор рекомендованой тренировки.
        /// </summary>
        private void btnSelectOnClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =
             MessageBox.Show("Вы уверены,созданный дневника приема пищи пользователь будет удален?",
             "Рекомендованой дневника приема пищи", MessageBoxButton.YesNoCancel,
             MessageBoxImage.Question, MessageBoxResult.Yes);

            if(result == MessageBoxResult.Yes)
            {
                foodDiaryController.InitTemplateRecommended();
                foodDiaryController.Update();
                ICUserFoodDiary.Items.Refresh();
            }
        }
    }
}
