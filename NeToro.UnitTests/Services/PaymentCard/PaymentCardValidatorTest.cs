using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeToro.Interfaces.Inputs.PaymentCard;
using NeToro.Validation;

namespace NeToro.UnitTests.Services.PaymentCard
{
    [TestClass]
    public class PaymentCardValidatorTest
    {
        private PaymentCardValidator validator;

        [TestInitialize]
        public void InitializePasswordHandlerService()
        {         
            validator = new PaymentCardValidator();
        }

        [TestMethod]
        [DataRow(1, "713", "BankName", "Pesho", "79927398713")]
        [DataRow(1, "503", "BankName", "Gosho", "4556781048048503")]
        [DataRow(1, "345", "BankName", "Dany", "4716843981059345")]
        public void CreatePaymentCardValidator(int typeId, string cVC, string bankName, string cardHolder, string cardNumber)
        {
            var model = new PaymentCardInputModel 
            { 
                TypeId = typeId,
                CVC = cVC,
                BankName = bankName,
                CardHolder = cardHolder,
                CardNumber = cardNumber,
                ExpirationDate = DateTime.Now 
            };
            var result = validator.Validate(model);
            Assert.AreEqual(true, result.IsValid);
        }
    }
}
