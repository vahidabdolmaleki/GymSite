using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IWorkoutHistoryRepository : IGenericRepository<WorkoutHistory>
    {
        // دریافت تاریخچه تمرینات یک شخص
        List<WorkoutHistory> GetByPersonId(int personId);
        Task<List<WorkoutHistory>> GetByPersonIdAsync(int personId);

        // دریافت تاریخچه تمرینات یک برنامه خاص
        List<WorkoutHistory> GetByWorkoutPlanId(int workoutPlanId);
        Task<List<WorkoutHistory>> GetByWorkoutPlanIdAsync(int workoutPlanId);

        // دریافت آخرین تمرین انجام‌شده
        WorkoutHistory? GetLatestByPersonId(int personId);
        Task<WorkoutHistory?> GetLatestByPersonIdAsync(int personId);
    }
}
