using NeToro.Interfaces.Inputs.PaymentCard;
using System.Threading.Tasks;

namespace NeToro.BL.Contracts
{
    public interface IPaymentCardService
    {
        Task<int> Create(PaymentCardInputModel input, int userId);
    }
}
