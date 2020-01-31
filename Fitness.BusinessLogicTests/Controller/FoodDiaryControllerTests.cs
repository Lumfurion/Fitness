using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Fitness.BusinessLogicTests.Controller
{
    [TestClass]
    public class FoodDiaryControllerTests
    {   [TestMethod]
        public void AddTest()
        {
            //Arrange
            UserController.CurrentUserName = "sd";
            var trainingController = new TrainingController();
            
            trainingController.SelectTraining("Похудение для мальчиков");
            trainingController.Saver();
            trainingController.Update();
            var foodDiaryController = new FoodDiaryController();

            //Act
            var eatingTime = foodDiaryController.UserFoodDiary[0].Eatings[0].EatingTime;
            foodDiaryController.Add("Чай зеленый с молоком без сахара", eatingTime);
            var food = foodDiaryController.UserFoodDiary[0].Eatings[0].Foods.Where(t => t.Key.Name == "Чай зеленый с молоком без сахара").FirstOrDefault().Key.Name;
            //Assert
            Assert.AreEqual(food, "Чай зеленый с молоком без сахара");
        }

        [TestMethod]
        public void ReplacementTest()
        {
            //Arrange
            UserController.CurrentUserName = "sd";
            var trainingController = new TrainingController();
           
            var foodDiaryController = new FoodDiaryController();

            //Act
           
            var eatingTime = foodDiaryController.UserFoodDiary[0].Eatings[0].EatingTime;
            foodDiaryController.Add("Чай зеленый с молоком без сахара", eatingTime);
            foodDiaryController.Replacement("Чай зеленый с молоком без сахара", "Апельсин", eatingTime);
            var food = foodDiaryController.UserFoodDiary[0].Eatings[0].Foods.Where(t => t.Key.Name == "Апельсин").FirstOrDefault();

            //Assert
            Assert.AreEqual(food.Key.Name, "Апельсин");
        }



        [TestMethod]
        public void DeleteTest()
        {
            //Arrange
            UserController.CurrentUserName = "sd";
            var trainingController = new TrainingController();
            var foodDiaryController = new FoodDiaryController();

            //Act
            
            var eatingTime = foodDiaryController.UserFoodDiary[0].Eatings[0].EatingTime;
            foodDiaryController.Delete("Чай зеленый с молоком без сахара", eatingTime);
            var food = foodDiaryController.UserFoodDiary[0].Eatings[0].Foods.Where(t => t.Key.Name == "Чай зеленый с молоком без сахара").FirstOrDefault();

            //Assert
            Assert.AreEqual(food.Key, null);
        }


    }
}
