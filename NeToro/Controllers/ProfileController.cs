using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeToro.BL.Contracts;
using NeToro.Interfaces.Inputs.Profile;

namespace NeToro.Api.Controllers
{
    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private IProfileService profileService;
        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(ProfileInputModel profile)
        {
            var userId = 1;
            var profileId = await profileService.Create(profile, userId);
            return Created(nameof(Create), profileId);
        }
    }
}
