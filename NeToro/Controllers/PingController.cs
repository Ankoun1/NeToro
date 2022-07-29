using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NeToro.Api.Controllers
{
    [ApiController]
    [Route("api/ping")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> PingAsync()
        {
            return await Task.FromResult(Ok("NeToro Api"));
        }
    }
}
