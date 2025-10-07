using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.NotificationRepository
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(GymDbContext gymDbContext):base(gymDbContext)
        {
            
        }

        public List<Notification> GetByDevice(int deviceId) => _dbSet.Where(n=> n.DeviceId == deviceId).ToList();

        public async Task<List<Notification>> GetByDeviceAsync(int deviceId) => await _dbSet.Where(n=> n.DeviceId == deviceId).ToListAsync();

        public List<Notification> GetByStatus(Notification.NotificationStatus status) => _dbSet.Where(n => n.Status == status).ToList();

        public async Task<List<Notification>> GetByStatusAsync(Notification.NotificationStatus status) => await _dbSet.Where(n => n.Status == status).ToListAsync();

        public List<Notification> GetPending() => _dbSet.Where(n => n.Status == Notification.NotificationStatus.Pending).ToList();

        public async Task<List<Notification>> GetPendingAsync() => await _dbSet.Where(n => n.Status == Notification.NotificationStatus.Pending).ToListAsync();

        public List<Notification> GetUnreadByPerson(int personId) => _dbSet.Where(n=> n.PersonId == personId && !n.IsRead).ToList();

        public async Task<List<Notification>> GetUnreadByPersonAsync(int personId) => await _dbSet.Where(n => n.PersonId == personId && !n.IsRead).ToListAsync();

    }
}
