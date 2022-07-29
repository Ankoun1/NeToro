using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NeToro.BL.Contracts;
using NeToro.BL.Services;
using NeToro.DAL.User;
using NeToro.DAL.User.Contracts;
using NeToro.Interfaces.Inputs.User;

namespace NeToro.UnitTests.Services.User
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserManagement> userManegmentMock;
        private Mock<IPasswordHandler> passwordHandlerMock;

        [TestInitialize]
        public void Initialize()
        {
            userManegmentMock = new Mock<IUserManagement>();
            passwordHandlerMock = new Mock<IPasswordHandler>();
        }

        [TestMethod]
        public async Task Create_InvokeUserManegment_Once()
        {           
            userManegmentMock.Setup(x => x.CreateUser(It.IsAny<UserDto>())).ReturnsAsync(5);          

            var sut = new UserService(userManegmentMock.Object, passwordHandlerMock.Object);

            var user = GetProfileModel("Pesho", "123456");           
            
            var result = await sut.Create(user);
            userManegmentMock.Verify(x => x.CreateUser(It.IsAny<UserDto>()), Times.Once);
            passwordHandlerMock.Verify(x => x.GeneratorPassword(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            //Assert.AreEqual(5, result);            
        }

        private static UserInputModel GetProfileModel(string username, string password)
        { 
           return new UserInputModel { Username = username, Password = password };
        }
    }
}
