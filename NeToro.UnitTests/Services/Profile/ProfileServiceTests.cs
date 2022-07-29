using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NeToro.BL.Services;
using NeToro.DAL.Profile.Contracts;
using NeToro.DAL.Profile.Dto;
using NeToro.Interfaces.Inputs.Profile;

namespace NeToro.UnitTests.Services.Profile
{
    [TestClass]
    public class ProfileServiceTests
    {
        private Mock<IProfileManagment> profileManagmentMock;

        [TestInitialize]
        public void Initialize()
        {
            profileManagmentMock = new Mock<IProfileManagment>();
        }


        [TestMethod]
        public async Task CreateProfile_Verify_CountMethodCalls()
        {
            //Arrange
            ProfileInputModel profileinputModel = GetProfileModel("Adam","Lamber", "9002042211", "Bulgaria", "Druma44");
            var userId = 1;
            profileManagmentMock.Setup(p => p.ExecuteProfile(It.IsAny<ProfileDto>(), It.IsAny<int>()))
                .Returns(Task.FromResult(123));

            //Act
            var sut = new ProfileService(profileManagmentMock.Object);

            var result = await sut.Create(profileinputModel, userId);

            //Asset
            profileManagmentMock.Verify(p => p.ExecuteProfile(It.IsAny<ProfileDto>(), 1), Times.Once);
            profileManagmentMock.Verify(p => p.ExecuteProfile(It.IsAny<ProfileDto>(), 2), Times.Never);
        }

        private static ProfileInputModel GetProfileModel(string firstName,
            string lastName, string egn, string nationality, string address)
        {
            return new ProfileInputModel
            {
                FirstName = firstName,
                LastName = lastName,
                EGN = egn,
                Nationality = nationality,
                Address = address,
            };
        }

        [TestMethod]
        public async Task CreateProfile_NullInputModel_ThrowException()
        {
            //Arrange
            var sut = new ProfileService(profileManagmentMock.Object);
            //Act
            //Assert
            var exception = await Assert.ThrowsExceptionAsync<ArgumentNullException>(
                () => sut.Create(null, 1));

            Assert.IsTrue(exception.Message.Contains("Parameter 'Profile input model is null."));
        }
    }
}
