using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IMembershipRepository:IGenericRepository<UserMembership>
    {
        // 📅 بررسی اینکه کاربر اشتراک فعال دارد یا نه
        bool HasActiveMembership(int userId);
        Task<bool> HasActiveMembershipAsync(int userId);

        // 🔄 تمدید اشتراک کاربر (افزودن روزهای جدید)
        void ExtendMembership(int userId, int extraDays);
        Task ExtendMembershipAsync(int userId, int extraDays);

        // 📋 دریافت لیست اشتراک‌های منقضی شده
        List<UserMembership> GetExpiredMemberships();
        Task<List<UserMembership>> GetExpiredMembershipsAsync();

        // 📆 دریافت اشتراک‌های فعال
        List<UserMembership> GetActiveMemberships();
        Task<List<UserMembership>> GetActiveMembershipsAsync();
    }
}
