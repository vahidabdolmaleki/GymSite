using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        // نقش‌های یک کاربر خاص
        List<UserRole> GetRolesByUserId(int personId);
        Task<List<UserRole>> GetRolesByUserIdAsync(int personId);

        // کاربران دارای نقش خاص
        List<UserRole> GetUsersByRoleId(int roleId);
        Task<List<UserRole>> GetUsersByRoleIdAsync(int roleId);

        // بررسی اینکه آیا کاربر نقش خاصی دارد یا نه
        bool HasRole(int personId, int roleId);
        Task<bool> HasRoleAsync(int personId, int roleId);
    }
}
