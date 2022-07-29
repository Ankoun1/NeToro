using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeToro.BL.Services;

namespace NeToro.UnitTests.Services.User
{
    [TestClass]
    public class PasswordHandlerTests
    {
        private PasswordHandler passwordHandler;

        [TestInitialize]
        public void InitializePasswordHandlerService()
        {
            //Arrange
            passwordHandler = new PasswordHandler();
        }

        [TestMethod]
        [DataRow("salt", "PASSWORD", "saPASSltWORD", "salt")]
        [DataRow("salt1", "PASSWORD", "salPASSt1WORD", "salt1")]
        [DataRow("salt", "PASSWORD1", "saPASSWltORD1", "salt")]
        [DataRow("salt1", "PASSWORD1", "salPASSWt1ORD1", "salt1")]
        public void CreateParametersUserInPasswordHandler(string saltInput, string password, string passwordHashed, string saltOutput)
        {
            // Act
            (string, string) result = passwordHandler.GeneratorPassword(saltInput, password);
           
            // Assert
            Assert.AreEqual((passwordHashed, saltOutput), result);
        }
    }
}
