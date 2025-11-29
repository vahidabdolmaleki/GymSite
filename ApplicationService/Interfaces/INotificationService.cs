using ApplicationService.DTOs;
using Core;

namespace ApplicationService.Interfaces
{
    public interface INotificationService
    {
        Task<ServiceResult<bool>> SendAsync(NotificationCreateDto dto);
        Task<ServiceResults<NotificationDto>> GetForUserAsync(int personId);
        Task<ServiceResult<bool>> MarkAsReadAsync(int id);
        Task<ServiceResult<int>> GetUnreadCountAsync(int personId);
    }

}
