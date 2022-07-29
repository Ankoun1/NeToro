using Microsoft.AspNetCore.Mvc;
using NeToro.BL.Contracts;
using NeToro.Interfaces.Inputs.PaymentCard;
using System.Threading.Tasks;

namespace NeToro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCardController : ControllerBase
    {
        private readonly IPaymentCardService cardService;

        public PaymentCardController(IPaymentCardService cardService)
        {
            this.cardService = cardService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreatePaymentCard(PaymentCardInputModel input)
        {
            var userId = 3;
            var cardId = await cardService.Create(input, userId);
            return Ok(cardId);
        }
    }
}
