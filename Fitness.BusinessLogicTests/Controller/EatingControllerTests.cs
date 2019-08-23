using System;
using Fitness.BusinessLogic.Model;
using Fitness.BusinessLogic.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Fitness.BusinessLogicTests.Controller
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
          
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingConroller = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingConroller.Add(food, 100);

            //Assert
            //eatingConroller.Eating.Foods.First().Key.Name-будем сравнивать Last именем.
            Assert.AreEqual(food.Name, eatingConroller.Eating.Foods.Last().Key.Name);


        }

    }
}
