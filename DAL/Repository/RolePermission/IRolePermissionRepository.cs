using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRolePermissionRepository: IGenericRepository<RolePermission>
    {
        // تمام مجوزهای یک نقش خاص
        List<RolePermission> GetByRoleId(int roleId);
        Task<List<RolePermission>> GetByRoleIdAsync(int roleId);

        // بررسی اینکه آیا نقش خاصی دسترسی مشخصی دارد یا نه
        bool HasPermission(int roleId, int permissionId);
        Task<bool> HasPermissionAsync(int roleId, int permissionId);
    }
}
