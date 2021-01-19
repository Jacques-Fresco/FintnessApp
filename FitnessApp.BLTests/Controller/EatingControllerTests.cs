using Microsoft.VisualStudio.TestTools.UnitTesting;
using FitnessApp.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
         public void AddTest()
         {
            // Arrange
            string userName = Guid.NewGuid().ToString();
            string foodName = Guid.NewGuid().ToString();
            Random rnd = new Random();
            UserController userController = new UserController(userName); // контроллер пользователя
            EatingController eatingController = new EatingController(userController.CurrentUser); // контроллер еды
            Food food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingController.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.Last().Key.Name);
         }
    }
}