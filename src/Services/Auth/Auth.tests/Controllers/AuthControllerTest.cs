using Auth.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Auth.tests.Controllers
{
    public class AuthControllerTest
    {
        private readonly IOptions<Audience> _settings;

        public AuthControllerTest(IOptions<Audience> settings)
        {
            _settings = settings;
        }
        [TestInitialize]
        public void TestInit()
        {
           
        }

        [TestMethod]
        public void Login_ValidCredentials_LoginSucessfully()
        {
            // Arrange
            //var controller = new AuthController(_settings);

            // Act
            

            // Assert
        }

        [TestMethod]
        public void Login_InvalidCredentials_LoginFail()
        {
            // Arrange
            //var controller = new AuthController(_settings);

            // Act


            // Assert
        }

    }
}
