using System;
using System.Linq;
using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Fitness.BusinessLogicTests.Controller
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();

            var userController = new UserController(userName);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(activityName,  rnd.Next(10, 50));

            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            //Assert
            Assert.AreEqual(activityName, exerciseController.Activities.Last().Name);
        }
    }
}
