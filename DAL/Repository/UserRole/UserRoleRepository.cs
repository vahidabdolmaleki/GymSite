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
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly GymDbContext _gymDbContext;

        public UserRoleRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<UserRole> GetRolesByUserId(int personId)
        {
            return _context.UserRoles
                .Include(ur => ur.Role)
                .Where(ur => ur.PersonId == personId)
                .ToList();
        }

        public async Task<List<UserRole>> GetRolesByUserIdAsync(int personId)
        {
            return await _context.UserRoles
                .Include(ur => ur.Role)
                .Where(ur => ur.PersonId == personId)
                .ToListAsync();
        }

        public List<UserRole> GetUsersByRoleId(int roleId)
        {
            return _context.UserRoles
                .Include(ur => ur.Person)
                .Where(ur => ur.RoleId == roleId)
                .ToList();
        }

        public async Task<List<UserRole>> GetUsersByRoleIdAsync(int roleId)
        {
            return await _context.UserRoles
                .Include(ur => ur.Person)
                .Where(ur => ur.RoleId == roleId)
                .ToListAsync();
        }

        public bool HasRole(int personId, int roleId)
        {
            return _context.UserRoles.Any(ur => ur.PersonId == personId && ur.RoleId == roleId);
        }

        public async Task<bool> HasRoleAsync(int personId, int roleId)
        {
            return await _context.UserRoles.AnyAsync(ur => ur.PersonId == personId && ur.RoleId == roleId);
        }
    }
}
