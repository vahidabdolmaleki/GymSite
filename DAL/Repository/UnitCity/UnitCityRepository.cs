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
    public class UnitCityRepository : GenericRepository<UnitCity>, IUnitCityRepository
    {
        private readonly GymDbContext _gymDbContext;

        public UnitCityRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<UnitCity> GetAllProvinces()
        {
            return _gymDbContext.UnitCities
                .Where(u => u.ParentUnitId == null)
                .OrderBy(u => u.Name)
                .ToList();
        }

        public async Task<List<UnitCity>> GetAllProvincesAsync()
        {
            return await _gymDbContext.UnitCities
                .Where(u => u.ParentUnitId == null)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public List<UnitCity> GetCitiesByProvince(int provinceId)
        {
            return _gymDbContext.UnitCities
                .Where(u => u.ParentUnitId == provinceId)
                .OrderBy(u => u.Name)
                .ToList();
        }

        public async Task<List<UnitCity>> GetCitiesByProvinceAsync(int provinceId)
        {
            return await _gymDbContext.UnitCities
                .Where(u => u.ParentUnitId == provinceId)
                .OrderBy(u => u.Name)
                .ToListAsync();
        }

        public string? GetNameById(int id)
        {
            return _gymDbContext.UnitCities
                .Where(u => u.Id == id)
                .Select(u => u.Name)
                .FirstOrDefault();
        }

        public async Task<string?> GetNameByIdAsync(int id)
        {
            return await _gymDbContext.UnitCities
                .Where(u => u.Id == id)
                .Select(u => u.Name)
                .FirstOrDefaultAsync();
        }
    }
}
