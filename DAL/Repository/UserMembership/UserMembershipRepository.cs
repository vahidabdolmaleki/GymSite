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
    public class UserMembershipRepository : GenericRepository<UserMembership>, IUserMembershipRepository
    {
        private readonly GymDbContext _gymDbContext;

        public UserMembershipRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<UserMembership> GetActiveMemberships(int userId)
        {
            return _gymDbContext.UserMemberships
                .Include(um => um.Membership)
                .Where(um => um.UserId == userId && um.EndDate > DateTime.UtcNow)
                .ToList();
        }

        public async Task<List<UserMembership>> GetActiveMembershipsAsync(int userId)
        {
            return await _gymDbContext.UserMemberships
                .Include(um => um.Membership)
                .Where(um => um.UserId == userId && um.EndDate > DateTime.UtcNow)
                .ToListAsync();
        }

        public UserMembership? GetLatestMembership(int userId)
        {
            return _gymDbContext.UserMemberships
                .Include(um => um.Membership)
                .Where(um => um.UserId == userId)
                .OrderByDescending(um => um.EndDate)
                .FirstOrDefault();
        }

        public async Task<UserMembership?> GetLatestMembershipAsync(int userId)
        {
            return await _gymDbContext.UserMemberships
                .Include(um => um.Membership)
                .Where(um => um.UserId == userId)
                .OrderByDescending(um => um.EndDate)
                .FirstOrDefaultAsync();
        }

        public bool HasActiveMembership(int userId)
        {
            return _gymDbContext.UserMemberships
                .Any(um => um.UserId == userId && um.EndDate > DateTime.UtcNow);
        }

        public async Task<bool> HasActiveMembershipAsync(int userId)
        {
            return await _gymDbContext.UserMemberships
                .AnyAsync(um => um.UserId == userId && um.EndDate > DateTime.UtcNow);
        }
    }
}
