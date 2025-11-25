using ApplicationService.DTOs.UserMemberShip;
using Core;

namespace ApplicationService.Interfaces
{
    public interface IUserMembershipService
    {
        Task<ServiceResult<int>> CreateAsync(UserMembershipCreateDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
        Task<ServiceResults<UserMembershipDto>> GetForPersonAsync(int personId);
        Task<ServiceResults<UserMembershipDto>> GetAllAsync();
    }

}
