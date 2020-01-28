using Fitness.BusinessLogic.Controller;
using System.Windows.Controls;

namespace Fitness.Wpf
{
   
    public partial class UserControlStatistic : UserControl
    {
        readonly StatisticController statisticController;
        public UserControlStatistic()
        {
            InitializeComponent();
            statisticController = new StatisticController();
            DataContext= statisticController.StatisticObject();

        }
    }
}
