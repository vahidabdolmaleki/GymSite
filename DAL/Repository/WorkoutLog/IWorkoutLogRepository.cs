using DAL.Repository.GenericRepository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IWorkoutLogRepository : IGenericRepository<WorkoutLog>
    {
        // دریافت لاگ‌های تمرینی یک کاربر
        List<WorkoutLog> GetByPersonId(int personId);
        Task<List<WorkoutLog>> GetByPersonIdAsync(int personId);

        // دریافت لاگ‌های مربوط به یک تمرین خاص
        List<WorkoutLog> GetByWorkoutId(int workoutId);
        Task<List<WorkoutLog>> GetByWorkoutIdAsync(int workoutId);

        // بررسی اینکه آیا شخص تمرین خاصی را در یک تاریخ انجام داده است
        bool HasCompletedWorkout(int personId, int workoutId, DateTime date);
        Task<bool> HasCompletedWorkoutAsync(int personId, int workoutId, DateTime date);
        Task<List<WorkoutLog>> GetByPersonAsync(int personId);

    }
}
