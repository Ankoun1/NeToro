using System;
using System.Threading.Tasks;
using NeToro.BL.Contracts;
using NeToro.BL.Mappers;
using NeToro.DAL.User;
using NeToro.DAL.User.Contracts;
using NeToro.Interfaces.Inputs.User;

namespace NeToro.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserManagement userManagement;
        private readonly IPasswordHandler passwordHandler;

        public UserService(IUserManagement userManagement, IPasswordHandler passwordHandler)
        {
            this.userManagement = userManagement;
            this.passwordHandler = passwordHandler;
        }

        public Task<int> Create(UserInputModel input)
        {
            var salt = Guid.NewGuid().ToString();
            var hashedParams = passwordHandler.GeneratorPassword(salt, input.Password);
            return  userManagement.CreateUser(input.MapToUserDto(hashedParams.password, hashedParams.salt));
        }
    }
}
