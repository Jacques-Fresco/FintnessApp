﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            string userName = Guid.NewGuid().ToString();
            DateTime birthdate = DateTime.Now.AddYears(-18);
            double weight = 90;
            double height = 190;
            string gender = "man";
            UserController controller = new UserController(userName);

            // Act
            controller.SetNewUserData(gender, birthdate, weight, height); // сохраняем
            UserController controller2 = new UserController(userName); // читаем сохраненного

            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            string userName = Guid.NewGuid().ToString(); // Random

            // Act
            UserController controller = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}