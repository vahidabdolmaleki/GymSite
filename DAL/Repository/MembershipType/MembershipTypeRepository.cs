using DAL.Context;
using DAL.Repositories.Interfaces;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.MembershipType
{
    public class MembershipTypeRepository : GenericRepository<Membership>, IMembershipTypeRepository
    {
        public MembershipTypeRepository(GymDbContext context) : base(context)
        {
        }

        public Membership? GetByTitle(string title)
        {
            return _dbSet.FirstOrDefault(m => m.Title == title);
        }

        public async Task<Membership?> GetByTitleAsync(string title)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Title == title);
        }

        public List<Membership> GetAvailableMemberships()
        {
            return _dbSet.ToList(); // اگر بعداً خواستی Active فیلد اضافه کن، اینجا فیلترش کن
        }

        public async Task<List<Membership>> GetAvailableMembershipsAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
