using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeToro.BL.Contracts;
using NeToro.DAL.User;
using NeToro.Interfaces.Inputs.User;

namespace NeToro.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("create")]
        [HttpPost]
        public async Task <ActionResult<int>> Register(UserInputModel user)
        {
            return  await userService.Create(user);            
        }
    }
}
