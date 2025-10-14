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
    public class WorkoutCategoryRepository : GenericRepository<WorkoutCategory>, IWorkoutCategoryRepository
    {
        private readonly GymDbContext _gymDbContext;

        public WorkoutCategoryRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<WorkoutSubCategory> GetSubCategories(int categoryId)
        {
            return _gymDbContext.WorkoutSubCategories
                .Where(sc => sc.WorkoutCategoryId == categoryId)
                .OrderBy(sc => sc.Name)
                .ToList();
        }

        public async Task<List<WorkoutSubCategory>> GetSubCategoriesAsync(int categoryId)
        {
            return await _gymDbContext.WorkoutSubCategories
                .Where(sc => sc.WorkoutCategoryId == categoryId)
                .OrderBy(sc => sc.Name)
                .ToListAsync();
        }

        public WorkoutCategory? GetByName(string name)
        {
            return _gymDbContext.WorkoutCategories
                .Include(c => c.SubCategories)
                .FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task<WorkoutCategory?> GetByNameAsync(string name)
        {
            return await _gymDbContext.WorkoutCategories
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}
