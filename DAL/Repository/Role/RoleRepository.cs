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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly GymDbContext _gymDbContext;

        public RoleRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }
        

        public async Task<List<Role>> GetAllWithUserAsync() =>
            await _gymDbContext.Roles
                .Include(r => r.PersonRoles) 
                    .ThenInclude(pr => pr.Person)
                .Include(r => r.UserRoles)
                    .ThenInclude(ur => ur.Person)
                .ToListAsync();

        public Role? GetRoleWithPermissions(int roleId) =>
            _context.Roles
                .Include(r => r.PersonRoles)
                .Include(r => r.UserRoles)               
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefault(r => r.Id == roleId);

        

        public void AddPermissionToRole(int roleId, int permissionId)
        {
            var rolePermission = new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            };
            _context.RolePermissions.Add(rolePermission);
        }

        

        public void RemovePermissionFromRole(int roleId, int permissionId)
        {
            var rp = _context.RolePermissions
                .FirstOrDefault(r => r.RoleId == roleId && r.PermissionId == permissionId);

            if (rp != null)
                _context.RolePermissions.Remove(rp);
        }

        public async Task RemovePermissionFromRoleAsync(int roleId, int permissionId)
        {
            var rp = await _context.RolePermissions
                .FirstOrDefaultAsync(r => r.RoleId == roleId && r.PermissionId == permissionId);

            if (rp != null)
                _context.RolePermissions.Remove(rp);
        }

        public bool HasPermission(int roleId, string actionName) =>
            _context.RolePermissions
                .Include(rp => rp.Permission)
                .Any(rp => rp.RoleId == roleId && rp.Permission.ActionName == actionName);

        public async Task<bool> HasPermissionAsync(int roleId, string actionName) =>
            await _context.RolePermissions
                .Include(rp => rp.Permission)
                .AnyAsync(rp => rp.RoleId == roleId && rp.Permission.ActionName == actionName);

        public List<Role> GetAllWithUser() =>
            _gymDbContext.Roles
            .Include(r => r.PersonRoles)
                .ThenInclude(pr => pr.Person)
            .Include(r => r.UserRoles)
                .ThenInclude(ur => ur.Person)
            .ToList();

        public async Task<Role?> GetRoleWithPermissionAsync(int RoleId) =>
            await _context.Roles
                .Include(r => r.RolePermissions)
                    .ThenInclude(rp => rp.Permission)
                .FirstOrDefaultAsync(r => r.Id == RoleId);

        public async Task AddPersmissionToRoleAsync(int roleId, int permissionId)
        {
            var rolePermission = new RolePermission
            {
                RoleId = roleId,
                PermissionId = permissionId
            };
            await _context.RolePermissions.AddAsync(rolePermission);
        }
    }
}
