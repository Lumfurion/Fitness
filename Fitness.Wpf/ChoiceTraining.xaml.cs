using Fitness.BusinessLogic.Controller;
using System.Windows;

namespace Fitness.Wpf
{

    public partial class ChoiceTraining : Window
    {
        readonly string name = UserController.CurrentUserName;
        public ChoiceTraining()
        {
            InitializeComponent();
            lbUser.Content = name;
        }

        
       
    }
   
}
