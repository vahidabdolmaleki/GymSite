using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IPermissionRepository: IGenericRepository<Permission>
    {
        // دریافت همه مجوزها با نقش‌های مرتبط
        List<Permission> GetAllWithRoles();
        Task<List<Permission>> GetAllWithRolesAsync();

        // دریافت مجوز خاص با نقش‌های مرتبط
        Permission? GetWithRoles(int id);
        Task<Permission?> GetWithRolesAsync(int id);

        // بررسی اینکه آیا این مجوز توسط هیچ نقشی استفاده می‌شود یا نه
        bool IsInUse(int id);
        Task<bool> IsInUseAsync(int id);
    }
}
