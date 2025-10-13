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
    public class PersonRoleRepository : GenericRepository<PersonRole>, IPersonRoleRepostiory
    {
        private readonly GymDbContext _gymDbContext;

        public PersonRoleRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<PersonRole> GetRolesByPersonId(int personId)
        {
            return _gymDbContext.PersonRoles
                .Include(pr => pr.Role)
                .Where(pr => pr.PersonId == personId)
                .ToList();
        }

        public async Task<List<PersonRole>> GetRolesByPersonIdAsync(int personId)
        {
            return await _gymDbContext.PersonRoles
                .Include(pr => pr.Role)
                .Where(pr => pr.PersonId == personId)
                .ToListAsync();
        }

        public List<PersonRole> GetPersonsByRoleId(int roleId)
        {
            return _gymDbContext.PersonRoles
                .Include(pr => pr.Person)
                .Where(pr => pr.RoleId == roleId)
                .ToList();
        }

        public async Task<List<PersonRole>> GetPersonsByRoleIdAsync(int roleId)
        {
            return await _gymDbContext.PersonRoles
                .Include(pr => pr.Person)
                .Where(pr => pr.RoleId == roleId)
                .ToListAsync();
        }

        public bool HasRole(int personId, int roleId)
        {
            return _gymDbContext.PersonRoles.Any(pr => pr.PersonId == personId && pr.RoleId == roleId);
        }

        public async Task<bool> HasRoleAsync(int personId, int roleId)
        {
            return await _gymDbContext.PersonRoles.AnyAsync(pr => pr.PersonId == personId && pr.RoleId == roleId);
        }
    }
}
