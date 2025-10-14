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
    public class AddressDetailRepository : GenericRepository<AddressDetail>, IAddressDetailRepository
    {
        private readonly GymDbContext _gymDbContext;

        public AddressDetailRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<AddressDetail> GetByCity(int cityId)
        {
            return _context.AddressDetails
                .Include(a => a.City)
                .Include(a => a.Unit)
                .Where(a => a.CityId == cityId)
                .ToList();
        }

        public async Task<List<AddressDetail>> GetByCityAsync(int cityId)
        {
            return await _context.AddressDetails
                .Include(a => a.City)
                .Include(a => a.Unit)
                .Where(a => a.CityId == cityId)
                .ToListAsync();
        }

        public List<AddressDetail> GetByUnit(int unitId)
        {
            return _context.AddressDetails
                .Include(a => a.City)
                .Include(a => a.Unit)
                .Where(a => a.UnitId == unitId)
                .ToList();
        }

        public async Task<List<AddressDetail>> GetByUnitAsync(int unitId)
        {
            return await _context.AddressDetails
                .Include(a => a.City)
                .Include(a => a.Unit)
                .Where(a => a.UnitId == unitId)
                .ToListAsync();
        }

        public AddressDetail? FindByPostalCode(string postalCode)
        {
            return _context.AddressDetails
                .Include(a => a.City)
                .Include(a => a.Unit)
                .FirstOrDefault(a => a.PostalCode == postalCode);
        }

        public async Task<AddressDetail?> FindByPostalCodeAsync(string postalCode)
        {
            return await _context.AddressDetails
                .Include(a => a.City)
                .Include(a => a.Unit)
                .FirstOrDefaultAsync(a => a.PostalCode == postalCode);
        }
    }
}
