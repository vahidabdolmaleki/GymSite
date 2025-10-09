using DAL.Context;
using DAL.Repository.GenericRepository;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.WorkoutRepository
{
    public class WorkoutRepository : GenericRepository<Workout>, IWorkoutRepository
    {
        private readonly GymDbContext _gymDbContext;

        public WorkoutRepository(GymDbContext gymDbContext) : base(gymDbContext) 
        {
            _gymDbContext = gymDbContext;
        }

        public List<Workout> GetBySubCategory(int SubCategoryId) => _dbSet.Where(w=> w.WorkoutSubCategoryId == SubCategoryId).ToList();
        public async Task<List<Workout>> GetBySubcategoryAsync(int subCategoryId) => await _dbSet.Where(w => w.WorkoutSubCategoryId == subCategoryId).ToListAsync();

        public List<Workout> SerachByName(string Keyword) => _dbSet.Where(w => w.Name.Contains(Keyword)).ToList();
        public async Task<List<Workout>> SerachByNameAsync(string Keyword) => await _dbSet.Where(w => w.Name.Contains(Keyword)).ToListAsync();

        public List<Workout> GetByDuration(int minMinutes) => _dbSet.Where(w => w.DurationMinutes >= minMinutes).ToList();
        public async Task<List<Workout>> GetByDurationAsync(int minMinutes) => await _dbSet.Where(w=> w.DurationMinutes >= minMinutes).ToListAsync();

        public Workout? GetWithLog(int workoutId) => _dbSet.Include(w => w.WorkoutLogs).FirstOrDefault(w => w.Id == workoutId);
        public async Task<Workout?> GetWithLogAsync(int workoutId) => await _dbSet.Include(w => w.WorkoutLogs).FirstOrDefaultAsync(w=> w.Id == workoutId);
    }
}
