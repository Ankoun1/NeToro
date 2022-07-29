using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeToro.Interfaces.Inputs.User;
using NeToro.Validation;

namespace NeToro.UnitTests.Services.User
{
    [TestClass]
    public class UserValidatorTest
    {
        private UserValidator validator;

        [TestInitialize]
        public void InitializePasswordHandlerService()
        {
            validator = new UserValidator();
        }

        [TestMethod]
        [DataRow("Pesho", "Password")]
        [DataRow("Gosho", "Pass")]     
        public void CreateUserValidator(string username, string password)
        {
            var model = new UserInputModel
            {
                Username = username,
                Password = password
            };
            var result = validator.Validate(model);
            Assert.AreEqual(true, result.IsValid);
        }
    }
}
