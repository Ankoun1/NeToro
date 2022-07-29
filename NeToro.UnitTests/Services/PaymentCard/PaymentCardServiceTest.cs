using System;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NeToro.BL.Services;
using NeToro.DAL.PaymentCard.Contracts;
using NeToro.DAL.PaymentCard.Dto;
using NeToro.Interfaces.Inputs.PaymentCard;

namespace NeToro.UnitTests.Services.PaymentCard
{  
    [TestClass]
    public class PaymentCardServiceTest
    {
        private Mock<IPaymentCardManagment> paymentCardManagmentMock;

        [TestInitialize]
        public void Initialize()
        {
            paymentCardManagmentMock = new Mock<IPaymentCardManagment>();
        }

        [TestMethod]          
        public async Task Create_InvokePaymentCard_Once()           
        {
            paymentCardManagmentMock.Setup(x => x.ExecuteCreatePaymentCardSP(It.IsAny<PaymentCardDto>(), It.IsAny<int>())).ReturnsAsync(5);

            var sut = new PaymentCardService(paymentCardManagmentMock.Object);

            var paymentCard = GetPaymentCardModel(3, "123", "bankName", "cardHolder", "cardNumber", DateTime.Now);        

            var result = await sut.Create(paymentCard, 3);
            paymentCardManagmentMock.Verify(x => x.ExecuteCreatePaymentCardSP(It.IsAny<PaymentCardDto>(), It.IsAny<int>()), Times.Once);           
           // Assert.AreEqual(5, result);
        }

        private static PaymentCardInputModel GetPaymentCardModel  (int typeId ,string cVC , string bankName , string cardHolder , string cardNumber , DateTime expirationDate)            
        {
            return new PaymentCardInputModel 
            {
                TypeId = typeId
                ,CVC = cVC
                , BankName = bankName
                ,CardHolder = cardHolder
                ,CardNumber = cardNumber
                ,ExpirationDate = expirationDate
            };
        }
    }
}
