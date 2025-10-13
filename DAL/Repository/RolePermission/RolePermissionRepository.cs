using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class RolePermissionRepository : GenericRepository<RolePermission>, IRolePermissionRepository
    {
        private readonly GymDbContext _gymDbContext;

        public RolePermissionRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<RolePermission> GetByRoleId(int roleId)
        {
            return _gymDbContext.RolePermissions
                .Include(rp => rp.Permission)
                .Where(rp => rp.RoleId == roleId)
                .ToList();
        }

        public async Task<List<RolePermission>> GetByRoleIdAsync(int roleId)
        {
            return await _gymDbContext.RolePermissions
                .Include(rp => rp.Permission)
                .Where(rp => rp.RoleId == roleId)
                .ToListAsync();
        }

        public bool HasPermission(int roleId, int permissionId)
        {
            return _gymDbContext.RolePermissions
                .Any(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }

        public async Task<bool> HasPermissionAsync(int roleId, int permissionId)
        {
            return await _gymDbContext.RolePermissions
                .AnyAsync(rp => rp.RoleId == roleId && rp.PermissionId == permissionId);
        }
    }
}
