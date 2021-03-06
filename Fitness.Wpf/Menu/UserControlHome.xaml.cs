﻿using Fitness.BusinessLogic.Controller;
using System.Linq;
using System.Windows.Controls;

namespace Fitness.Wpf
{
    public partial class UserControlHome : UserControl
    {
        readonly UserController userController;
        readonly TrainingController trainingController;
        public UserControlHome()
        {
            InitializeComponent();
            userController = new UserController(UserController.CurrentUserName);
            trainingController = new TrainingController();
            DataContext = userController.CurrentUser;
            lbSelected.Text = trainingController.GetTypeSelectTraining();
        }
    }
}
