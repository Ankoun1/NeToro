using System;
using System.Linq;
using FluentValidation;
using NeToro.Interfaces.Inputs.PaymentCard;
using static NeToro.Validation.Constants.DataImportConstants.PaymentCardConst;

namespace NeToro.Validation
{
    public class PaymentCardValidator : AbstractValidator<PaymentCardInputModel>
    {
        public PaymentCardValidator()
        {           
            RuleFor(x => x.TypeId)
                .NotNull()
                .Must(x => x > 0);

            RuleFor(x => x.CVC)               
               .Matches(ValidatePaternCVC)
               .WithMessage("stop 1");                           

            RuleFor(o => o)
                .Must(o => PropertiesCheckMethod(o.CVC, o.CardNumber))
                .WithMessage("stop 21");

            RuleFor(x => x.BankName)
                .NotEmpty()
                .Length(MinLengthBankName, MaxLengthBankName)
                .WithMessage("stop 2");

            RuleFor(x => x.CardHolder)
                .NotEmpty()
                .Length(MinLengthCardHolder, MaxLengthCardHolder)
                .WithMessage("stop 3");

            RuleFor(x => x.CardNumber)
                .NotEmpty()
                .Length(MinLengthCardNumber, MaxLengthCardNumber)
                .When(x => x.CardNumber.Any(y => Char.IsLetter(y)))
                .WithMessage("stop 14")
                .Must(CheckLuhn)
                .WithMessage("stop 4");

            RuleFor(o => o).Must(o => CheckIsLetter(o.CardNumber))
                .WithMessage("stop 22")
                .Must(o => CheckLuhn(o.CardNumber))
                .WithMessage("Invalid Card number!"); ;

            RuleFor(x => x.ExpirationDate)
                .Must(date => date != default(DateTime))
                .WithMessage("stop 5");            
        }

        private bool CheckIsLetter(string cardNumber)
        {
            return cardNumber.Any(y => Char.IsDigit(y));
        }

        private bool PropertiesCheckMethod(string cVC, string cardNumber)
        {
            return cVC == cardNumber.Substring(cardNumber.Length - 3);
        }

        static bool CheckLuhn(String cardNumber)
        {
            int nDigits = cardNumber.Length;

            int nSum = 0;
            bool isSecond = false;
            for (int i = nDigits - 1; i >= 0; i--)
            {
                var nextDigit = cardNumber[i].ToString();

                int d = int.Parse(nextDigit);

                if (isSecond == true)
                    d = d * 2;
                
                nSum += d / 10;
                nSum += d % 10;
                isSecond = !isSecond;
            }
            return (nSum % 10 == 0);
        }
    } 
}
