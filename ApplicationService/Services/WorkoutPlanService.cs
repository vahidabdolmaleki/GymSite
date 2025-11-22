using ApplicationService.DTOs.WorkoutPlan;
using ApplicationService.Interfaces;
using AutoMapper;
using Core;
using DAL.UnitOfWork;
using Entities;
using Microsoft.EntityFrameworkCore;

public class WorkoutPlanService : IWorkoutPlanService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public WorkoutPlanService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    // =============== Create ===================
    public async Task<ServiceResult<int>> CreateAsync(WorkoutPlanCreateDto dto)
    {
        var result = new ServiceResult<int>();

        try
        {
            var plan = new WorkoutPlan
            {
                PersonId = dto.PersonId,
                Title = dto.Title,
                Description = dto.Description
            };

            await _uow.WorkoutPlanRepository.SaveAsync(plan);
            await _uow.CommitAsync();

            // افزودن آیتم‌ها
            foreach (var item in dto.Items)
            {
                var entity = new WorkoutPlanItem
                {
                    WorkoutPlanId = plan.Id,
                    DayNumber = item.DayOfWeek,
                    WorkoutId = item.WorkoutId,
                    Sets = item.Sets,
                    Reps = item.Reps,
                    Weight = item.Weight,
                    DurationMinutes = item.DurationMinutes
                };

                await _uow.WorkoutPlanItemRepository.SaveAsync(entity);
            }

            await _uow.CommitAsync();

            result.IsSuccess = true;
            result.Data = plan.Id;
            result.Message = "برنامه تمرینی با موفقیت ساخته شد.";
            return result;
        }
        catch (Exception ex)
        {
            result.IsSuccess = false;
            result.Message = "خطا در ساخت برنامه: " + ex.Message;
            return result;
        }
    }

    // =============== GetById ===================
    public async Task<ServiceResult<WorkoutPlanDto>> GetByIdAsync(int id)
    {
        var result = new ServiceResult<WorkoutPlanDto>();

        var plan = await _uow.WorkoutPlanRepository.GetPlanWithItemsAsync(id);

        if (plan == null)
        {
            result.IsSuccess = false;
            result.Message = "برنامه پیدا نشد.";
            return result;
        }

        var dto = _mapper.Map<WorkoutPlanDto>(plan);

        result.IsSuccess = true;
        result.Data = dto;
        return result;
    }

    // =============== GetForPerson ===================
    public async Task<ServiceResults<WorkoutPlanDto>> GetForPersonAsync(int personId)
    {
        var result = new ServiceResults<WorkoutPlanDto>();

        var list = await _uow.WorkoutPlanRepository
            .GetPlansForPerson(personId)
            .ToListAsync();

        result.Data = _mapper.Map<List<WorkoutPlanDto>>(list);
        result.IsSuccess = true;

        return result;
    }

    // =============== Update ===================
    public async Task<ServiceResult<bool>> UpdateAsync(int id, WorkoutPlanCreateDto dto)
    {
        var result = new ServiceResult<bool>();

        var plan = await _uow.WorkoutPlanRepository.GetPlanWithItemsAsync(id);

        if (plan == null)
        {
            result.IsSuccess = false;
            result.Message = "برنامه یافت نشد.";
            return result;
        }

        // بروزرسانی اطلاعات اصلی
        plan.Title = dto.Title;
        plan.Description = dto.Description;

        // حذف آیتم‌های قبلی
        foreach (var old in plan.Items.ToList())
        {
            await _uow.WorkoutPlanItemRepository.RemoveAsync(old.Id);
        }

        // افزودن آیتم‌های جدید
        foreach (var item in dto.Items)
        {
            await _uow.WorkoutPlanItemRepository.SaveAsync(new WorkoutPlanItem
            {
                WorkoutPlanId = plan.Id,
                DayNumber = item.DayOfWeek,
                WorkoutId = item.WorkoutId,
                Sets = item.Sets,
                Reps = item.Reps,
                Weight = item.Weight,
                DurationMinutes = item.DurationMinutes
            });
        }

        await _uow.CommitAsync();

        result.IsSuccess = true;
        result.Data = true;
        result.Message = "بروزرسانی با موفقیت انجام شد.";
        return result;
    }

    // =============== Delete ===================
    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {
        var result = new ServiceResult<bool>();

        var plan = await _uow.WorkoutPlanRepository.FindAsync(id);

        if (plan == null)
        {
            result.IsSuccess = false;
            result.Message = "برنامه یافت نشد.";
            return result;
        }

        await _uow.WorkoutPlanRepository.RemoveAsync(plan.Id);
        await _uow.CommitAsync();

        result.IsSuccess = true;
        result.Data = true;
        result.Message = "برنامه حذف شد.";
        return result;
    }
}