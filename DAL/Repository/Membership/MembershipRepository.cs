using DAL.Context;
using DAL.Repository.GenericRepository;
using DAL.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class MembershipRepository : GenericRepository<UserMembership>, IMembershipRepository
    {
        private readonly GymDbContext _gymDbContext;

        public MembershipRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public bool HasActiveMembership(int userId)
        {
            return _dbSet.Any(m => m.UserId == userId && m.EndDate >= DateTime.UtcNow);
        }

        public async Task<bool> HasActiveMembershipAsync(int userId)
        {
            return await _dbSet.AnyAsync(m => m.UserId == userId && m.EndDate >= DateTime.UtcNow);
        }

        public void ExtendMembership(int userId, int extraDays)
        {
            var membership = _dbSet.FirstOrDefault(m => m.UserId == userId && m.EndDate >= DateTime.UtcNow);
            if (membership != null)
            {
                membership.EndDate = membership.EndDate.AddDays(extraDays);
                _dbSet.Update(membership);
            }
        }

        public async Task ExtendMembershipAsync(int userId, int extraDays)
        {
            var membership = await _dbSet.FirstOrDefaultAsync(m => m.UserId == userId && m.EndDate >= DateTime.UtcNow);
            if (membership != null)
            {
                membership.EndDate = membership.EndDate.AddDays(extraDays);
                _dbSet.Update(membership);
            }
        }

        public List<UserMembership> GetExpiredMemberships()
        {
            return _dbSet
                .Include(m => m.User)
                .Include(m => m.Membership)
                .Where(m => m.EndDate < DateTime.UtcNow)
                .ToList();
        }

        public async Task<List<UserMembership>> GetExpiredMembershipsAsync()
        {
            return await _dbSet
                .Include(m => m.User)
                .Include(m => m.Membership)
                .Where(m => m.EndDate < DateTime.UtcNow)
                .ToListAsync();
        }

        public List<UserMembership> GetActiveMemberships()
        {
            return _dbSet
                .Include(m => m.User)
                .Include(m => m.Membership)
                .Where(m => m.EndDate >= DateTime.UtcNow)
                .ToList();
        }

        public async Task<List<UserMembership>> GetActiveMembershipsAsync()
        {
            return await _dbSet
                .Include(m => m.User)
                .Include(m => m.Membership)
                .Where(m => m.EndDate >= DateTime.UtcNow)
                .ToListAsync();
        }
    }
}
