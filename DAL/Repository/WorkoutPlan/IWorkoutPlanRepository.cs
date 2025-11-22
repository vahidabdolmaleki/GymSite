using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IWorkoutPlanRepository : IGenericRepository<WorkoutPlan>
    {
        // دریافت همه برنامه‌های تمرینی یک شخص
        List<WorkoutPlan> GetByPersonId(int personId);
        Task<List<WorkoutPlan>> GetByPersonIdAsync(int personId);

        // دریافت برنامه‌های فعال (تاریخ پایان هنوز نرسیده)
        List<WorkoutPlan> GetActivePlans(int personId);
        Task<List<WorkoutPlan>> GetActivePlansAsync(int personId);

        // دریافت آخرین برنامه تمرینی یک شخص
        WorkoutPlan? GetLatestPlan(int personId);
        Task<WorkoutPlan?> GetLatestPlanAsync(int personId);

        Task<WorkoutPlan?> GetPlanWithItemsAsync(int id);
        IQueryable<WorkoutPlan> GetPlansForPerson(int personId);
    }
}
