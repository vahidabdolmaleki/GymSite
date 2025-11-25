using ApplicationService.DTOs.WorkoutLog;
using ApplicationService.Interfaces;
using AutoMapper;
using Core;
using DAL.UnitOfWork;
using Entities;

public class WorkoutLogService : IWorkoutLogService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public WorkoutLogService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<ServiceResult<int>> CreateAsync(WorkoutLogCreateDto dto)
    {
        var result = new ServiceResult<int>();

        try
        {
            // 1. بررسی وجود شاگرد
            var person = await _uow.PersonRepository.FindByIdAsync(dto.PersonId);
            if (person == null)
            {
                result.Message = "کاربر یافت نشد.";
                result.Data = -1;
                result.IsSuccess = false;
                return result;
            }
            // 2. بررسی وجود تمرین
            var workout = await _uow.WorkoutRepository.FindAsync(dto.WorkoutId);
            if (workout == null)
            {
                result.Message = "تمرین یافت نشد.";
                result.Data = -2;
                result.IsSuccess = false;
                return new ServiceResult<int>()
                {
                    Message = "تمرین یافت نشد.",
                    Data = -2,
                    IsSuccess = false
                };
            }

            // 3. ایجاد لاگ
            var log = new WorkoutLog
            {
                PersonId = dto.PersonId,
                WorkoutId = dto.WorkoutId,
                Sets = dto.Sets,
                Reps = dto.Reps,
                Weight = dto.Weight,
                DurationMinutes = dto.DurationMinutes,
                Notes = dto.Notes,
                PerformedAt = DateTime.UtcNow
            };

            await _uow.WorkoutLogRepository.SaveAsync(log);
            await _uow.CommitAsync();

            return new ServiceResult<int>()
            {
                Message = log.Id + "لاگ تمرین ثبت شد   ",
                Data = log.Id,
                IsSuccess = true
            };
        }
        catch (Exception ex)
        {
            return new ServiceResult<int>()
            {
                Data = -3,
                IsSuccess = false,
                Message = $"خطا در ثبت لاگ: {ex.Message}"
            };
        }
    }

    public async Task<ServiceResult<List<WorkoutLogDto>>> GetLogsForPersonAsync(int personId)
    {
        var result = new ServiceResult<List<WorkoutLogDto>>();

        try
        {
            var logs = await _uow.WorkoutLogRepository.GetByPersonAsync(personId);

            var mapped = logs.Select(x => new WorkoutLogDto
            {
                Id = x.Id,
                PersonId = x.PersonId,
                PersonFullName = $"{x.Person.FirstName} {x.Person.LastName}",
                WorkoutId = x.WorkoutId,
                WorkoutName = x.Workout.Name,
                PerformedAt = x.PerformedAt,
                Sets = x.Sets,
                Reps = x.Reps,
                Weight = x.Weight,
                DurationMinutes = x.DurationMinutes,
                Notes = x.Notes
            }).ToList();
            return new ServiceResult<List<WorkoutLogDto>>()
            {
                Data = mapped,
                IsSuccess = true,
                Message = ExceptionMessage.GetWorkoutLogAsyncSuccess
            };
        }
        catch (Exception ex)
        {
            return new ServiceResult<List<WorkoutLogDto>>
            {
                IsSuccess = false,
                Message = $"خطا در دریافت لیست: {ex.Message}",
                Data = null
            };

        }
    }

    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {
        var result = new ServiceResult<bool>();

        try
        {
            var log = await _uow.WorkoutLogRepository.FindAsync(id);
            if (log == null)
            {
                return new ServiceResult<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = "آیتم یافت نشد."
                };
            }

            _uow.WorkoutLogRepository.Remove(log.Id);
            await _uow.CommitAsync();

            return new ServiceResult<bool>()
            {
                IsSuccess = true,
                Data = true,
                Message = "حذف شد."
            };

        }
        catch (Exception ex)
        {
            return new ServiceResult<bool>
            {
                Data = false,
                IsSuccess = false,
                Message = $"خطا در حذف: {ex.Message}"
            };
        }
    }
}
