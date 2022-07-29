using NeToro.DAL.Profile.Dto;
using NeToro.Interfaces.Inputs.Profile;
using System.Threading.Tasks;

namespace NeToro.BL.Mapper
{
    public static class ProfileDtoMappers
    {
        public static ProfileDto MapToProfileDto
                (this ProfileInputModel input)
        {
            return new ProfileDto
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                EGN = input.EGN,
                Nationality = input.Nationality,
                Address = input.Address
            };
        }

        public static ProfileInputModel MapToInputModel
                (this ProfileDto input)
        {
            return new ProfileInputModel
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                EGN = input.EGN,
                Nationality = input.Nationality,
                Address = input.Address
            };
        }
    }
}
