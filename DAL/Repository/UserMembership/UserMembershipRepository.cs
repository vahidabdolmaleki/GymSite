using DAL.Repository.GenericRepository;
using DAL.Repository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using DAL.Context;
public class UserMembershipRepository
    : GenericRepository<UserMembership>, IUserMembershipRepository
{
    public UserMembershipRepository(GymDbContext context) : base(context) { }

    // 📅 بررسی اشتراک فعال
    public bool HasActiveMembership(int personId)
    {
        return _dbSet.Any(x =>
            x.PersonId == personId &&
            x.EndDate >= DateTime.UtcNow);
    }

    public async Task<bool> HasActiveMembershipAsync(int personId)
    {
        return await _dbSet.AnyAsync(x =>
            x.PersonId == personId &&
            x.EndDate >= DateTime.UtcNow);
    }

    // 🔄 تمدید اشتراک
    public void ExtendMembership(int personId, int extraDays)
    {
        var sub = _dbSet
            .Where(x => x.PersonId == personId)
            .OrderByDescending(x => x.EndDate)
            .FirstOrDefault();

        if (sub != null)
        {
            sub.EndDate = sub.EndDate.AddDays(extraDays);
        }
    }

    public async Task ExtendMembershipAsync(int personId, int extraDays)
    {
        var sub = await _dbSet
            .Where(x => x.PersonId == personId)
            .OrderByDescending(x => x.EndDate)
            .FirstOrDefaultAsync();

        if (sub != null)
        {
            sub.EndDate = sub.EndDate.AddDays(extraDays);
        }
    }

    // 📋 اشتراک‌های منقضی‌شده
    public List<UserMembership> GetExpiredMemberships()
    {
        return _dbSet
            .Where(x => x.EndDate < DateTime.UtcNow)
            .ToList();
    }

    public async Task<List<UserMembership>> GetExpiredMembershipsAsync()
    {
        return await _dbSet
            .Where(x => x.EndDate < DateTime.UtcNow)
            .ToListAsync();
    }

    // 📆 اشتراک‌های فعال
    public List<UserMembership> GetActiveMemberships()
    {
        return _dbSet
            .Where(x => x.EndDate >= DateTime.UtcNow)
            .ToList();
    }

    public async Task<List<UserMembership>> GetActiveMembershipsAsync()
    {
        return await _dbSet
            .Where(x => x.EndDate >= DateTime.UtcNow)
            .ToListAsync();
    }
}
