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
        // 📅 بررسی اینکه شخص اشتراک فعال دارد یا نه
        bool HasActiveMembership(int personId);
        Task<bool> HasActiveMembershipAsync(int personId);
        // 🔄 تمدید اشتراک کاربر (افزایش روزهای اشتراک فعلی)
        Task ExtendMembershipAsync(int personId, int extraDays);
        void ExtendMembership(int personId, int extraDays);
        // 📋 دریافت لیست اشتراک‌های منقضی شده
        List<UserMembership> GetExpiredMemberships();
        Task<List<UserMembership>> GetExpiredMembershipsAsync();
        // 📆 دریافت لیست اشتراک‌های فعال
        List<UserMembership> GetActiveMemberships();
        Task<List<UserMembership>> GetActiveMembershipsAsync();
    }

}
