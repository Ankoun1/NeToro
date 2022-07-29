using System.Threading.Tasks;
using NeToro.DAL.User;
using NeToro.Interfaces.Inputs.User;

namespace NeToro.BL.Contracts
{
    public interface IUserService
    {
        Task<int> Create(UserInputModel input);        
    }
}
