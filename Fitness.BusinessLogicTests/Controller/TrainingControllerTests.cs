﻿using Fitness.BusinessLogic.Controller;
using Fitness.BusinessLogic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Fitness.BusinessLogicTests.Controller
{   [TestClass]
    public  class TrainingControllerTests
    {
        #region Удаление,добавление,замена тренировок
        [TestMethod()]
        public void AddTrainingTest()
        {
            //Arrange
            var noob = "Похудения для девушек";
            var name = "sd";
            UserController userController = new UserController(name);
            TrainingController trainingController = new TrainingController();
            var exercise = new Exercise("Молот", 100, "Training/Noobman/Day3/Молот.jpg", 2, 10, "раз");

            //Act

            trainingController.SelectTraining(noob);
            trainingController.Saver();
            trainingController.Update();
            var firstday = trainingController.SelectProgram().Keys.FirstOrDefault();
            trainingController.AddTraining(firstday, exercise);
            trainingController.Update();

            var training = trainingController.SelectProgram();
            var e = training[firstday].Where(c => c.Name == "Молот").FirstOrDefault();

            //Assert
            Assert.AreEqual(e.Name, "Молот");

        }

        [TestMethod()]
        public void DeleteTrainingTest()
        {
            //Arrange
            var name = "sd";
            UserController userController = new UserController(name);
            TrainingController trainingController = new TrainingController();
            var exercise = new Exercise("Молот", 100, "Training/Noobman/Day3/Молот.jpg", 2, 10, "раз");

            //Act
            var training = trainingController.SelectProgram();
            var firstday = training.Keys.FirstOrDefault();
            trainingController.AddTraining(firstday, exercise);
            trainingController.Delete(firstday, "Молот");
            trainingController.Update();
            var result = training[firstday].Where(c => c.Name == "Молот").FirstOrDefault();

            //Assert
            Assert.AreEqual(result, null);

        }


        [TestMethod()]
        public void ReplacementExerciseinProgramTest()
        {
            //Arrange
            var name = "sd";
            UserController userController = new UserController(name);
            TrainingController trainingController = new TrainingController();


            //Act
            var training = trainingController.SelectProgram();
            var firstday = training.Keys.FirstOrDefault();

            trainingController.ReplacementExerciseinProgram(firstday, "Молот", training[firstday][0].Name);
            trainingController.Update();

            //Assert
            Assert.AreEqual("Молот", trainingController.SelectProgram()[firstday][0].Name);

        }
        #endregion

        #region Удаление добавление дней 
        [TestMethod()]
        public void AddNewDayTest()
        {   //Arrange
            var name = "sd";
            UserController userController = new UserController(name);
            TrainingController trainingController = new TrainingController();

            //Act
            var training = trainingController.SelectProgram();
            var daynew = trainingController.AddNewDay();
            var day = $"День {daynew}";
            trainingController.Update();
            var result = training.Keys.Where(k => k == day).FirstOrDefault();

            //Assert
            Assert.AreEqual(day, result);
        }



        [TestMethod()]
        public void DeleteDayTest()
        {   //Arrange
            var name = "sd";
            UserController userController = new UserController(name);
            TrainingController trainingController = new TrainingController();

            //Act
            var training = trainingController.SelectProgram();
            var daylastidex = training.Keys.Count();
            var daylast = $"День {daylastidex}";

            trainingController.DeleteDay(daylast);
            trainingController.Update();
            var result = training.Keys.Where(k => k == daylast).FirstOrDefault();

            //Assert
            Assert.AreNotEqual(daylast, result);
        }
        #endregion
        
        [TestMethod()]
        public void ChangeProgramTest()
        {
            //Arrange
            var name = "sd";
            UserController userController = new UserController(name);
            TrainingController trainingController = new TrainingController();

            //Act
         
            var training = trainingController.SelectProgram();
            trainingController.ChangeProgram("Похудения для девушек");
            trainingController.Update();
            

            //Assert
            Assert.AreEqual("Похудения для девушек", trainingController.GetTypeSelectTraining());
        }


      






    }
}
