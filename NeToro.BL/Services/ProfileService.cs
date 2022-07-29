using System.Threading.Tasks;
using NeToro.BL.Mapper;
using NeToro.BL.Contracts;
using NeToro.DAL.Profile.Contracts;
using NeToro.Interfaces.Inputs.Profile;
using System;

namespace NeToro.BL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileManagment profileManagment;
        public ProfileService(IProfileManagment profileManagment)
        {
            this.profileManagment = profileManagment;
        }

        public Task<int> Create(ProfileInputModel input,
                                      int userId)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Profile input model is null.");
            }

            return  profileManagment.ExecuteProfile
                     (
                         input.MapToProfileDto(),
                         userId
                     );
        }
    }
}
