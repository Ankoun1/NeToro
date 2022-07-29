using System.Threading.Tasks;
using NeToro.Interfaces.Inputs.Profile;

namespace NeToro.BL.Contracts
{
    public interface IProfileService
    {
        Task<int> Create(ProfileInputModel input, int userId);
    }
}
