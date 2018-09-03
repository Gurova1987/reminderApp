using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using User.API.Controllers;
using User.API.Infrastructure;

namespace User.tests.Controllers
{
    public class UserControllerTest
    {

        [TestInitialize]
        public void TestInit()
        {

        }

        //[TestMethod]
        //public async void GetById_ExistingUser_ReturnSuccess()
        //{
        //    // Arrange
        //    var controller = new UserController(GetContextWithData());

        //    // Act
        //    var result = await controller.GetById(1);

        //    // Assert
        //    Assert.AreEqual("Test", result.ToString());
        //}

        //[TestMethod]
        //public void GetById_NotExistingUser_ReturnNotFound()
        //{
        //    // Arrange
        //    var controller = new UserController(GetContextWithData());

        //    // Act
        //    var result = controller.GetById(1);

        //    // Assert
        //    Assert.AreEqual("Test", result.ToString());
        //}

        //[TestMethod]
        //public void CreateUser_ValidParameters_ReminderCreated()
        //{
        //    // Arrange
        //    var controller = new UserController(GetContextWithData());

        //    // Act
        //    var result = controller.GetById(1);

        //    // Assert
        //    Assert.AreEqual("Test", result.ToString());
        //}

        //[TestMethod]
        //public void GetUsers_ExistingUsers_ReturnListSuccessfully()
        //{
        //    // Arrange
        //    var controller = new UserController(GetContextWithData());

        //    // Act
        //    var result = controller.GetById(1);

        //    // Assert
        //    Assert.AreEqual("Test", result.ToString());
        //}

        //private UserContext GetContextWithData()
        //{
        //    var options = new DbContextOptionsBuilder<UserContext>()
        //        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //        .Options;
        //    var context = new UserContext(options);

        //    var user = new API.Models.User { Id = 1, Username = "Test", Email = "Test@email.com" };
        //    context.Users.Add(User);
        //    context.SaveChanges();

        //    return context;
        //}
    }
}
