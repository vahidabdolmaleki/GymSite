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
    public class PermissionRepository : GenericRepository<Permission> , IPermissionRepository
    {
        private readonly GymDbContext _gymDbContext;

        public PermissionRepository(GymDbContext gymDbContext):base(gymDbContext) 
        {
            _gymDbContext = gymDbContext;
        }

        public List<Permission> GetAllWithRoles() =>
            _context.Permissions
                .Include(p => p.RolePermissions)
                    .ThenInclude(rp => rp.Role)
                .ToList();

        public async Task<List<Permission>> GetAllWithRolesAsync() =>
            await _context.Permissions
                .Include(p => p.RolePermissions)
                    .ThenInclude(rp => rp.Role)
                .ToListAsync();

        public Permission? GetWithRoles(int id) =>
            _context.Permissions
                .Include(p => p.RolePermissions)
                    .ThenInclude(rp => rp.Role)
                .FirstOrDefault(p => p.Id == id);

        public async Task<Permission?> GetWithRolesAsync(int id) =>
            await _context.Permissions
                .Include(p => p.RolePermissions)
                    .ThenInclude(rp => rp.Role)
                .FirstOrDefaultAsync(p => p.Id == id);

        public bool IsInUse(int id) =>
            _context.RolePermissions.Any(rp => rp.PermissionId == id);

        public async Task<bool> IsInUseAsync(int id) =>
            await _context.RolePermissions.AnyAsync(rp => rp.PermissionId == id);
        public Permission? GetByActionName(string actionName)=> _context.Permissions
                .FirstOrDefault(p => p.ActionName.ToLower() == actionName.ToLower());

        public async Task<Permission?> GetByActionNameAsync(string actionName)=>await _context.Permissions
                .FirstOrDefaultAsync(p => p.ActionName.ToLower() == actionName.ToLower());
    }
}
