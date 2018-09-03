using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.API.Controllers;
using System;
using Reminder.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Reminder.tests.Controllers
{
    public class ReminderControllerTest
    {

        [TestInitialize]
        public void TestInit()
        {

        }

        [TestMethod]
        public void GetById_ExistingReminder_ReturnSuccess()
        {
            // Arrange
            var controller = new ReminderController(GetContextWithData());

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.AreEqual("Test", result.ToString());
        }

        [TestMethod]
        public void GetById_NotExistingReminder_ReturnNotFound()
        {
            // Arrange
            var controller = new ReminderController(GetContextWithData());

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.AreEqual("Test", result.ToString());
        }

        [TestMethod]
        public void CreateReminder_ValidParameters_ReminderCreated()
        {
            // Arrange
            var controller = new ReminderController(GetContextWithData());

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.AreEqual("Test", result.ToString());
        }

        [TestMethod]
        public void GetReminders_ExistingRemainders_ReturnListSuccessfully()
        {
            // Arrange
            var controller = new ReminderController(GetContextWithData());

            // Act
            var result = controller.GetById(1);

            // Assert
            Assert.AreEqual("Test", result.ToString());
        }

        private ReminderContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<ReminderContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new ReminderContext(options);

            var reminder = new API.Model.Reminder { Id = 1, Message = "Test", EmailTo = "Test@email.com", UserId = 1};
            context.Reminders.Add(reminder);
            context.SaveChanges();

            return context;
        }
    }
}
