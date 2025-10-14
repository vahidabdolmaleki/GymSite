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
    public class WorkoutSubCategoryRepository : GenericRepository<WorkoutSubCategory>, IWorkoutSubCategoryRepository
    {
        private readonly GymDbContext _gymDbContext;

        public WorkoutSubCategoryRepository(GymDbContext gymDbContext) : base(gymDbContext)
        {
            _gymDbContext = gymDbContext;
        }

        public List<Workout> GetWorkouts(int subCategoryId)
        {
            return _gymDbContext.Workouts
                .Where(w => w.WorkoutSubCategoryId == subCategoryId)
                .OrderBy(w => w.Name)
                .ToList();
        }

        public async Task<List<Workout>> GetWorkoutsAsync(int subCategoryId)
        {
            return await _gymDbContext.Workouts
                .Where(w => w.WorkoutSubCategoryId == subCategoryId)
                .OrderBy(w => w.Name)
                .ToListAsync();
        }

        public List<WorkoutSubCategory> GetByCategoryId(int categoryId)
        {
            return _gymDbContext.WorkoutSubCategories
                .Include(sc => sc.Workouts)
                .Where(sc => sc.WorkoutCategoryId == categoryId)
                .OrderBy(sc => sc.Name)
                .ToList();
        }

        public async Task<List<WorkoutSubCategory>> GetByCategoryIdAsync(int categoryId)
        {
            return await _gymDbContext.WorkoutSubCategories
                .Include(sc => sc.Workouts)
                .Where(sc => sc.WorkoutCategoryId == categoryId)
                .OrderBy(sc => sc.Name)
                .ToListAsync();
        }

        public WorkoutSubCategory? GetByName(string name)
        {
            return _gymDbContext.WorkoutSubCategories
                .Include(sc => sc.Workouts)
                .FirstOrDefault(sc => sc.Name.ToLower() == name.ToLower());
        }

        public async Task<WorkoutSubCategory?> GetByNameAsync(string name)
        {
            return await _gymDbContext.WorkoutSubCategories
                .Include(sc => sc.Workouts)
                .FirstOrDefaultAsync(sc => sc.Name.ToLower() == name.ToLower());
        }
    }
}
