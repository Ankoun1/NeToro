
using NeToro.DAL.PaymentCard.Dto;
using NeToro.Interfaces.Inputs.PaymentCard;

namespace NeToro.BL.Mappers
{
    public static class PaymentCardDtoMappers
    {
        public static PaymentCardDto MapToPaymentCardDto(this PaymentCardInputModel input)
        {
            return new PaymentCardDto
            {
                BankName = input.BankName,
                CardHolder = input.CardHolder,
                CardNumber = input.CardNumber,
                CVC = input.CVC,
                ExpirationDate = input.ExpirationDate,
                TypeId = input.TypeId
            };
        }
    }
}
