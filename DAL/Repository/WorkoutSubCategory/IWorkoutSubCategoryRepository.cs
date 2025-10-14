using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IWorkoutSubCategoryRepository : IGenericRepository<WorkoutSubCategory>
    {
        // دریافت همه تمرینات مربوط به یک زیر‌دسته
        List<Workout> GetWorkouts(int subCategoryId);
        Task<List<Workout>> GetWorkoutsAsync(int subCategoryId);

        // دریافت زیر‌دسته‌ها بر اساس دسته والد
        List<WorkoutSubCategory> GetByCategoryId(int categoryId);
        Task<List<WorkoutSubCategory>> GetByCategoryIdAsync(int categoryId);

        // جستجو بر اساس نام زیر‌دسته
        WorkoutSubCategory? GetByName(string name);
        Task<WorkoutSubCategory?> GetByNameAsync(string name);
    }
}
