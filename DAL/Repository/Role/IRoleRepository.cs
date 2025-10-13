using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRoleRepository:IGenericRepository<Role>
    {
        // دریافت همه نقش‌ها همراه با کابران مرتبط
        List<Role> GetAllWithUser();
        Task<List<Role>> GetAllWithUserAsync();

        // دریافت نقش همراه با مجوزها
        Role? GetRoleWithPermissions(int RoleId);
        Task<Role?> GetRoleWithPermissionAsync(int RoleId);

        //افزودن مجوز به نقش
        void AddPermissionToRole(int roleId, int PermissionId);
        Task AddPersmissionToRoleAsync(int roleId, int PermissionId);

        //ذف مجوز از نقش
        void RemovePermissionFromRole(int roleId, int PermissionId);
        Task RemovePermissionFromRoleAsync(int roleId, int PermissionId);

        //بررسی اینکه آیا نقش خاصی، یا دسترسی مشخی دارد
        bool HasPermission(int roleId, string actionName);
        Task<bool> HasPermissionAsync(int roleId, string actionName);
    }
}
