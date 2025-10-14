using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IWorkoutCategoryRepository : IGenericRepository<WorkoutCategory>
    {
        // دریافت همه زیر‌دسته‌های مربوط به یک دسته
        List<WorkoutSubCategory> GetSubCategories(int categoryId);
        Task<List<WorkoutSubCategory>> GetSubCategoriesAsync(int categoryId);

        // جستجو بر اساس نام دسته
        WorkoutCategory? GetByName(string name);
        Task<WorkoutCategory?> GetByNameAsync(string name);
    }
}
