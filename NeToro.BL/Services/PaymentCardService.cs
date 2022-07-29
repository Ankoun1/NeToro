using NeToro.BL.Contracts;
using NeToro.BL.Mappers;
using NeToro.DAL.PaymentCard.Contracts;
using NeToro.Interfaces.Inputs.PaymentCard;
using System.Threading.Tasks;

namespace NeToro.BL.Services
{
    public class PaymentCardService : IPaymentCardService
    {
        private readonly IPaymentCardManagment paymentCardManagement;

        public PaymentCardService(IPaymentCardManagment paymentCardManagement)
        {
            this.paymentCardManagement = paymentCardManagement;
        }
        public Task<int> Create(PaymentCardInputModel input, int userId)
        {
            return paymentCardManagement.ExecuteCreatePaymentCardSP(input.MapToPaymentCardDto(), userId);
        }
    }
}