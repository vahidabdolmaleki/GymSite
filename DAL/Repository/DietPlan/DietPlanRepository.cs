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
    public class DietPlanRepository : GenericRepository<DietPlan>, IDietPlanRepository
    {
        private readonly GymDbContext _gymDbContext;

        public DietPlanRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<DietPlan> GetDailyPlan(int personId, DateTime date) =>
            _context.DietPlans
                .Where(p => p.PersonId == personId && p.Date.HasValue && p.Date.Value.Date == date.Date)
                .ToList();

        public async Task<List<DietPlan>> GetDailyPlanAsync(int personId, DateTime date) =>
            await _context.DietPlans
                .Where(p => p.PersonId == personId && p.Date.HasValue && p.Date.Value.Date == date.Date)
                .ToListAsync();

        public List<DietPlan> GetPlansByDateRange(int personId, DateTime startDate, DateTime endDate) =>
            _context.DietPlans
                .Where(p => p.PersonId == personId && p.Date >= startDate && p.Date <= endDate)
                .OrderBy(p => p.Date)
                .ToList();

        public async Task<List<DietPlan>> GetPlansByDateRangeAsync(int personId, DateTime startDate, DateTime endDate) =>
            await _context.DietPlans
                .Where(p => p.PersonId == personId && p.Date >= startDate && p.Date <= endDate)
                .OrderBy(p => p.Date)
                .ToListAsync();

        public List<DietPlan> GetByMealType(int personId, string mealType) =>
            _context.DietPlans
                .Where(p => p.PersonId == personId && p.MealType.ToLower() == mealType.ToLower())
                .ToList();

        public async Task<List<DietPlan>> GetByMealTypeAsync(int personId, string mealType) =>
            await _context.DietPlans
                .Where(p => p.PersonId == personId && p.MealType.ToLower() == mealType.ToLower())
                .ToListAsync();

        public int GetTotalCaloriesForDate(int personId, DateTime date) =>
            _context.DietPlans
                .Where(p => p.PersonId == personId && p.Date.HasValue && p.Date.Value.Date == date.Date)
                .Sum(p => p.Calories ?? 0);

        public async Task<int> GetTotalCaloriesForDateAsync(int personId, DateTime date) =>
            await _context.DietPlans
                .Where(p => p.PersonId == personId && p.Date.HasValue && p.Date.Value.Date == date.Date)
                .SumAsync(p => p.Calories ?? 0);
    }
}
