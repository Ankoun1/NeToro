using System.Threading.Tasks;
using NeToro.DAL.Profile.Dto;

namespace NeToro.DAL.Profile.Contracts
{
    public interface IProfileManagment
    {
        Task<int> ExecuteProfile(ProfileDto profileDto, int userId);
    }
}
