using NeToro.DAL.User;
using NeToro.Interfaces.Inputs.User;

namespace NeToro.BL.Mappers
{
    public static class UserDtoMappers
    {
        public static UserDto MapToUserDto(this UserInputModel input, string hashedPassword, string salt)
        {
            return new UserDto
            {
                Username = input.Username,
                HashedPassword = hashedPassword,
                Salt = salt
            };
        }
    }
}
