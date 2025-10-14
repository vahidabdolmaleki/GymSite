using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        // بررسی وجود کاربر بر اساس ایمیل
        bool ExistsByEmail(string email);
        Task<bool> ExistsByEmailAsync(string email);

        // دریافت کاربر با ایمیل (برای ورود)
        User? GetByEmail(string email);
        Task<User?> GetByEmailAsync(string email);

        // بررسی رمز عبور (در صورت نیاز به لاجیک ساده در Repository)
        bool ValidatePassword(string email, string password);

        // دریافت نقش‌های کاربر
        List<string> GetUserRoles(int userId);
        Task<List<string>> GetUserRolesAsync(int userId);
    }
}
