using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.NotificationRepository
{
    public interface INotificationRepository:IGenericRepository<Notification>
    {
        // همه اعلان های خوانده نشده یک کاربری
        List<Notification> GetUnreadByPerson(int personId);
        Task<List<Notification>> GetUnreadByPersonAsync(int personId);
        //همه‌ی اعلان های یک دستگاه خاص
        List<Notification> GetByDevice(int deviceId);
        Task<List<Notification>> GetByDeviceAsync(int deviceId);
        //بازیابی بر اساس وضعیت
        List<Notification> GetByStatus(Notification.NotificationStatus status);
        Task<List<Notification>> GetByStatusAsync(Notification.NotificationStatus status);
        //اعلان های در وضعیت Pending (هنوز ارسال نشده)
        List<Notification> GetPending();
        Task<List<Notification>> GetPendingAsync();
        //
        Task<List<Notification>> GetForUserAsync(int personId);
        Task<int> GetUnreadCountAsync(int personId);
        Task MarkAsReadAsync(int notificationId);

    }
}

