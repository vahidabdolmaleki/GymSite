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
    public class MembershipRepository : GenericRepository<Membership>, IMembershipRepository
    {
        private readonly GymDbContext _gymDbContext;

        public MembershipRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }
        public async Task<bool> ExistsAsync(string title)
        {
            return await _dbSet.AnyAsync(x => x.Title == title);
        }
        
    }
}
