using ApplicationService.DTOs.WorkoutPlan;
using ApplicationService.Interfaces;
using AutoMapper;
using Core;
using DAL.UnitOfWork;
using Entities;

namespace ApplicationService.Services
{
    public class WorkoutPlanService : IWorkoutPlanService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public WorkoutPlanService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // ============================================================
        // ✔ ایجاد برنامه تمرینی
        // ============================================================
        public async Task<ServiceResult<int>> CreateWorkoutPlanAsync(WorkoutPlanCreateDto dto)
        {
            var result = new ServiceResult<int>();

            try
            {
                var plan = new WorkoutPlan
                {
                    StudentId = dto.StudentId,
                    CoachId = dto.CoachId,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                    Description = dto.Description,
                    Title = dto.Title                   
                };

                await _uow.WorkoutPlanRepository.SaveAsync(plan);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Data = plan.Id;
                result.Message = "برنامه با موفقیت ایجاد شد.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "خطا در ایجاد برنامه: " + ex.Message;
            }

            return result;
        }

        // ============================================================
        // ✔ اضافه کردن آیتم تمرینی به برنامه
        // ============================================================
        public async Task<ServiceResult<int>> AddItemAsync(WorkoutPlanItemCreateDto dto)
        {
            var result = new ServiceResult<int>();

            try
            {
                var item = new WorkoutPlanItem
                {
                    WorkoutPlanId = dto.WorkoutPlanId,
                    WorkoutId = dto.WorkoutId,
                    Sets = dto.Sets,
                    Reps = dto.Reps,
                    DayNumber = dto.DayOfWeek,
                    Notes = dto.Notes,
                    DurationMinutes = dto.DurationMinutes,
                    Weight = dto.Weight
                };

                await _uow.WorkoutPlanItemRepository.SaveAsync(item);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Data = item.Id;
                result.Message = "آیتم با موفقیت اضافه شد.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "خطا در افزودن آیتم: " + ex.Message;
            }

            return result;
        }

        // ============================================================
        // ✔ حذف آیتم برنامه
        // ============================================================
        public async Task<ServiceResult<bool>> RemoveItemAsync(int itemId)
        {
            var result = new ServiceResult<bool>();

            try
            {
                var item = await _uow.WorkoutPlanItemRepository.FindAsync(itemId);
                if (item == null)
                {
                    result.IsSuccess = false;
                    result.Message = "آیتم یافت نشد.";
                    return result;
                }

                _uow.WorkoutPlanItemRepository.Remove(item.Id);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Data = true;
                result.Message = "آیتم با موفقیت حذف شد.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "خطا در حذف آیتم: " + ex.Message;
            }

            return result;
        }

        // ============================================================
        // ✔ حذف کامل برنامه
        // ============================================================
        public async Task<ServiceResult<bool>> DeleteWorkoutPlanAsync(int planId)
        {
            var result = new ServiceResult<bool>();

            try
            {
                var plan = await _uow.WorkoutPlanRepository.GetFullPlanAsync(planId);
                if (plan == null)
                {
                    result.IsSuccess = false;
                    result.Message = "برنامه یافت نشد.";
                    return result;
                }

                // اول همه آیتم‌ها حذف شوند
                foreach (var item in plan.Items.ToList())
                {
                    _uow.WorkoutPlanItemRepository.Remove(item.Id);
                }

                // حذف خود برنامه
                _uow.WorkoutPlanRepository.Remove(plan.Id);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Data = true;
                result.Message = "برنامه کامل حذف شد.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "خطا در حذف برنامه: " + ex.Message;
            }

            return result;
        }

        // ============================================================
        // ✔ دریافت برنامه‌های یک دانشجو
        // ============================================================
        public async Task<ServiceResults<WorkoutPlanDto>> GetWorkoutPlansByStudentAsync(int studentId)
        {
            var result = new ServiceResults<WorkoutPlanDto>();

            try
            {
                var plans = await _uow.WorkoutPlanRepository.GetByStudentIdAsync(studentId);

                var mapped = _mapper.Map<List<WorkoutPlanDto>>(plans);

                result.IsSuccess = true;
                result.Data = mapped;
                result.Message = "لیست برنامه‌ها با موفقیت دریافت شد.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "خطا در دریافت برنامه‌ها: " + ex.Message;
            }

            return result;
        }

        // ============================================================
        // ✔ دریافت جزئیات کامل یک برنامه
        // ============================================================
        public async Task<ServiceResult<WorkoutPlanDto>> GetByIdAsync(int id)
        {
            var result = new ServiceResult<WorkoutPlanDto>();

            try
            {
                var plan = await _uow.WorkoutPlanRepository.GetFullPlanAsync(id);
                if (plan == null)
                {
                    result.IsSuccess = false;
                    result.Message = "برنامه یافت نشد.";
                    return result;
                }

                var mapped = _mapper.Map<WorkoutPlanDto>(plan);

                result.IsSuccess = true;
                result.Data = mapped;
                result.Message = "برنامه با موفقیت دریافت شد.";
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = "خطا در دریافت برنامه: " + ex.Message;
            }

            return result;
        }
    }
}
