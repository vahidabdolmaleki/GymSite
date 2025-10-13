using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUserMembershipRepository : IGenericRepository<UserMembership>
    {
        // تمام اشتراک‌های فعال کاربر
        List<UserMembership> GetActiveMemberships(int userId);
        Task<List<UserMembership>> GetActiveMembershipsAsync(int userId);

        // آخرین اشتراک کاربر
        UserMembership? GetLatestMembership(int userId);
        Task<UserMembership?> GetLatestMembershipAsync(int userId);

        // بررسی اینکه آیا اشتراک فعالی دارد یا نه
        bool HasActiveMembership(int userId);
        Task<bool> HasActiveMembershipAsync(int userId);
    }
}
