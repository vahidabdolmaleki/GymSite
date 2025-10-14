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
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly GymDbContext _gymDbContext;

        public AddressRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<Address> GetByPerson(int personId)
        {
            return _gymDbContext.Addresses
                .Include(a => a.AddressDetail)
                .Where(a => a.PersonId == personId)
                .OrderByDescending(a => a.CreatedDate)
                .ToList();
        }

        public async Task<List<Address>> GetByPersonAsync(int personId)
        {
            return await _gymDbContext.Addresses
                .Include(a => a.AddressDetail)
                .Where(a => a.PersonId == personId)
                .OrderByDescending(a => a.CreatedDate)
                .ToListAsync();
        }

        public Address? GetPrimaryAddress(int personId)
        {
            return _gymDbContext.Addresses
                .Include(a => a.AddressDetail)
                .FirstOrDefault(a => a.PersonId == personId && a.IsPrimary);
        }

        public async Task<Address?> GetPrimaryAddressAsync(int personId)
        {
            return await _gymDbContext.Addresses
                .Include(a => a.AddressDetail)
                .FirstOrDefaultAsync(a => a.PersonId == personId && a.IsPrimary);
        }

        public List<Address> GetByCity(int cityId)
        {
            return _gymDbContext.Addresses
                .Include(a => a.AddressDetail)
                .Where(a => a.AddressDetail.CityId == cityId)
                .ToList();
        }

        public async Task<List<Address>> GetByCityAsync(int cityId)
        {
            return await _gymDbContext.Addresses
                .Include(a => a.AddressDetail)
                .Where(a => a.AddressDetail.CityId == cityId)
                .ToListAsync();
        }
    }
}
