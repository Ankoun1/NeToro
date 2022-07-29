using System.Threading.Tasks;
using NeToro.DAL.User;

namespace NeToro.DAL.User.Contracts
{
    public interface IUserManagement
    {
        Task<int> CreateUser(UserDto userDto);        
    }
}
