using System.Threading.Tasks;
using NeToro.DAL.PaymentCard.Dto;

namespace NeToro.DAL.PaymentCard.Contracts
{
    public interface IPaymentCardManagment
    {
        Task<int> ExecuteCreatePaymentCardSP(PaymentCardDto dto, int userId);
    }
}
