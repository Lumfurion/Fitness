﻿using Fitness.BusinessLogic.Controller;
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
            if(foodDiaryController.Recommended.Count == 0)
            {
                btnSelect.Visibility = Visibility.Hidden;
            }
            else
            {
                brNotFoodDiary.Visibility = Visibility.Hidden;
            }
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

        private void DeleteFood_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var eatingTime = button.Tag.ToString();
            var name = button.Uid.ToString();

            foodDiaryController.Delete(name, eatingTime);
            ICUserFoodDiary.ItemsSource = null;
            ICUserFoodDiary.ItemsSource = foodDiaryController.UserFoodDiary;

        }

        private void EditFood_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var eatingTime = button.Tag.ToString();
            var name = button.Uid.ToString();

            ChoiceFood choiceFood = new ChoiceFood(eatingTime,name);
            choiceFood.ShowDialog();
            
            foodDiaryController.Update();
            ICUserFoodDiary.ItemsSource = null;
            ICUserFoodDiary.ItemsSource = foodDiaryController.UserFoodDiary;


        }
    }
}
