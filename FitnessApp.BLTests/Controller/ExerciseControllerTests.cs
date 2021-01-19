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
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            string userName = Guid.NewGuid().ToString();
            string activityName = Guid.NewGuid().ToString();
            Random rnd = new Random();
            UserController userController = new UserController(userName); // контроллер пользователя
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser); // контроллер еды
            Activity activity = new Activity(activityName, rnd.Next(10, 50));

            // Act
            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.Last().Name);
        }
    }
}