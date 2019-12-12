using Fitness.BusinessLogic.Controller;
using System.Windows.Controls;


namespace Fitness.Wpf
{
   
    public partial class UserControlEating : UserControl
    {
        readonly UserController userController;
        readonly TrainingController trainingController;
        readonly FoodDiaryController foodDiaryController;

        public UserControlEating()
        {
            trainingController = new TrainingController();
            InitializeComponent();
            userController = new UserController(UserController.CurrentUserName);
            trainingController = new TrainingController();
            foodDiaryController = new FoodDiaryController();
            DataContext = foodDiaryController.SetRecommended();
        }
    }
}
