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
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly GymDbContext _gymDbContext;

        public PersonRepository(GymDbContext gymDbContext) : base(gymDbContext) {
            _gymDbContext = gymDbContext;
        }

        public Person? FindByUsername(string username) =>
            _dbSet.FirstOrDefault(p => p.Username == username);

        public async Task<Person?> FindByUsernameAsync(string username) =>
            await _dbSet.FirstOrDefaultAsync(p => p.Username == username);

        public Person? FindByNationalCode(string nationalCode) =>
            _dbSet.FirstOrDefault(p => p.NationalCode == nationalCode);

        public async Task<Person?> FindByNationalCodeAsync(string nationalCode) =>
            await _dbSet.FirstOrDefaultAsync(p => p.NationalCode == nationalCode);

        public async Task<Person?> FindByIdAsync(int Id) => await _dbSet.FirstOrDefaultAsync(p => p.Id == Id);
        public async Task<Person?> FindByUsernameOrPhoneAsync(string usernameOrPhone)=>
            await _dbSet.FirstOrDefaultAsync(p =>p.Username == usernameOrPhone ||p.PhoneNumber == usernameOrPhone);

        public IQueryable<Person> GetAllWithDevices() => _context.People.Include(p => p.Devices);
    }

}
