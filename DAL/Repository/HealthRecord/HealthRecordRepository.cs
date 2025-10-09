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
    public class HealthRecordRepository : GenericRepository<HealthRecord>,IHealthRecordRepository
    {
        private readonly GymDbContext _gymDbContext;

        public HealthRecordRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public HealthRecord? GetLatestByPersonId(int personId) =>
            _context.HealthRecords
                .Where(h => h.PersonId == personId)
                .OrderByDescending(h => h.RecordDate)
                .FirstOrDefault();

        public async Task<HealthRecord?> GetLatestByPersonIdAsync(int personId) =>
            await _context.HealthRecords
                .Where(h => h.PersonId == personId)
                .OrderByDescending(h => h.RecordDate)
                .FirstOrDefaultAsync();

        public List<HealthRecord> GetByPersonId(int personId) =>
            _context.HealthRecords
                .Where(h => h.PersonId == personId)
                .OrderByDescending(h => h.RecordDate)
                .ToList();

        public async Task<List<HealthRecord>> GetByPersonIdAsync(int personId) =>
            await _context.HealthRecords
                .Where(h => h.PersonId == personId)
                .OrderByDescending(h => h.RecordDate)
                .ToListAsync();

        public double GetAverageBmi(int personId, DateTime startDate, DateTime endDate) =>
            _context.HealthRecords
                .Where(h => h.PersonId == personId && h.RecordDate >= startDate && h.RecordDate <= endDate)
                .Average(h => (double?)h.BMI) ?? 0;

        public async Task<double> GetAverageBmiAsync(int personId, DateTime startDate, DateTime endDate) =>
            await _context.HealthRecords
                .Where(h => h.PersonId == personId && h.RecordDate >= startDate && h.RecordDate <= endDate)
                .AverageAsync(h => (double?)h.BMI) ?? 0;
    }
}
