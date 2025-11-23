using ApplicationService.DTOs.WorkoutPlan;
using Core;

namespace ApplicationService.Interfaces
{
    public interface IWorkoutPlanService
    {
        // ✔ ایجاد برنامه‌ی تمرینی جدید
        Task<ServiceResult<int>> CreateWorkoutPlanAsync(WorkoutPlanCreateDto dto);

        // ✔ اضافه کردن آیتم (تمرین) به برنامه
        Task<ServiceResult<int>> AddItemAsync(WorkoutPlanItemCreateDto dto);

        // ✔ حذف آیتم از برنامه
        Task<ServiceResult<bool>> RemoveItemAsync(int itemId);

        // ✔ حذف کامل یک برنامه تمرینی
        Task<ServiceResult<bool>> DeleteWorkoutPlanAsync(int planId);

        // ✔ دریافت لیست برنامه‌های یک دانشجو
        Task<ServiceResults<WorkoutPlanDto>> GetWorkoutPlansByStudentAsync(int studentId);

        // ✔ دریافت جزئیات کامل یک برنامه (با آیتم‌ها)
        Task<ServiceResult<WorkoutPlanDto>> GetByIdAsync(int id);
    }
}
