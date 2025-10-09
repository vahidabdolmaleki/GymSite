using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IDietPlanRepository : IGenericRepository<DietPlan>
    {
        // 📅 دریافت برنامه غذایی روزانه برای یک شخص خاص
        List<DietPlan> GetDailyPlan(int personId, DateTime date);
        Task<List<DietPlan>> GetDailyPlanAsync(int personId, DateTime date);

        // 📆 دریافت برنامه غذایی در بازه تاریخی خاص
        List<DietPlan> GetPlansByDateRange(int personId, DateTime startDate, DateTime endDate);
        Task<List<DietPlan>> GetPlansByDateRangeAsync(int personId, DateTime startDate, DateTime endDate);

        // 🍽 دریافت برنامه غذایی بر اساس نوع وعده (مثلاً صبحانه، ناهار، شام)
        List<DietPlan> GetByMealType(int personId, string mealType);
        Task<List<DietPlan>> GetByMealTypeAsync(int personId, string mealType);

        // 🔥 محاسبه مجموع کالری مصرفی کاربر در روز خاص
        int GetTotalCaloriesForDate(int personId, DateTime date);
        Task<int> GetTotalCaloriesForDateAsync(int personId, DateTime date);
    }
}
