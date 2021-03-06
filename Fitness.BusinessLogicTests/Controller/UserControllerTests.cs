﻿using System;
using Fitness.BusinessLogic.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//Зачем нужны тесты автоматизация 1 раз код который будет проверять роботу прожениения,логики.
//Visual Studio-есть Live Unit Testing позволяет  в реальном времени выполнять тесты
//прямо во время тогда пишут код не нужно запускать тесты то есть при написания кода постояно идут проверки.
namespace UserControllerTests
{   [TestClass()]
    public class UserControllerTests //если класс будет приватним тестирование будет не правильно работать.
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {  //Arrange
            var userName = Guid.NewGuid().ToString();
            var password = "13223dss23232ds232";
            var birtdayDate = DateTime.Now.AddDays(-18);
            var gender = "Man";
            var weight = 90;
            var height = 190;
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender,password, birtdayDate, weight, height);
            var getData = new UserController(userName);
             
            //Assert
            Assert.AreEqual(userName, getData.CurrentUser.Name);
            Assert.AreEqual(birtdayDate, getData.CurrentUser.BirthdayDate);
            Assert.AreEqual(gender, getData.CurrentUser.Gender.Name);
            Assert.AreEqual(weight, getData.CurrentUser.Weight);
            Assert.AreEqual(height, getData.CurrentUser.Height);
            

        }

        [TestMethod()]
        public void SaveTest()
        {   //Создание модульный тестов по провилу 3-х а.

            //Arrange(объявление)-задаем данные которые подаются на вход.
            
            //NewGuid()-создает 128 битный псевдо уникальный идентификатор.
            //Случайный набор бит тоесть рендомное имя.
            var userName = Guid.NewGuid().ToString();//Уникальное имя пользователя.
            //Act(действе) - когда мы вызываем что-то.
            var controller = new UserController(userName);
            //Assert-Проверка что получилось и что ожидалось.
            //Класс Assert содержит набор проверок.
            Assert.AreEqual(userName,controller.CurrentUser.Name);

            //Проверяет указанные значения на неравенство и создает исключение, если два значения равны. 
            //Различные числовые типы считаются неравными, даже если логические значения равны. 
            //Например, 42L не равно 42.
            //Assert.AreNotEqual(userName, controller.CurrentUser.Name);

            //Будет сравнивать по адресам.
            //Assert.AreSame(userName, controller.CurrentUser.Name);
        }

    }
}
