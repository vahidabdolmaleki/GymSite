using ApplicationService.Interfaces;
using AutoMapper;
using Core;
using DAL.UnitOfWork;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public WorkoutService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ServiceResult<WorkoutDto>> CreateAsync(WorkoutCreateDto dto)
        {
            var result = new ServiceResult<WorkoutDto>();

            try
            {
                var workout = _mapper.Map<Workout>(dto);

                await _uow.WorkoutRepository.SaveAsync(workout);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Message = "تمرین با موفقیت ایجاد شد.";
                result.Data = _mapper.Map<WorkoutDto>(workout);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult<WorkoutDto>> UpdateAsync(WorkoutUpdateDto dto)
        {
            var result = new ServiceResult<WorkoutDto>();

            var workout = await _uow.WorkoutRepository.FindAsync(dto.Id);
            if (workout == null)
            {
                result.IsSuccess = false;
                result.Message = "تمرین یافت نشد.";
                return result;
            }

            _mapper.Map(dto, workout);

            await _uow.WorkoutRepository.UpdateAsync(workout);
            await _uow.CommitAsync();

            result.IsSuccess = true;
            result.Message = "تمرین بروزرسانی شد.";
            result.Data = _mapper.Map<WorkoutDto>(workout);
            return result;
        }

        public async Task<ServiceResults<WorkoutDto>> GetAllAsync()
        {
            var result = new ServiceResults<WorkoutDto>();

            var data = _uow.WorkoutRepository
                .GetAllQueryable()
                .Include(w => w.WorkoutSubCategory)
                .Include(w => w.Media)
                .ToList();

            result.IsSuccess = true;
            result.Data = _mapper.Map<List<WorkoutDto>>(data);
            return result;
        }

        public async Task<ServiceResult<WorkoutDto>> GetByIdAsync(int id)
        {
            var result = new ServiceResult<WorkoutDto>();

            var workout = _uow.WorkoutRepository
                .GetAllQueryable()
                .Include(w => w.WorkoutSubCategory)
                .Include(w => w.Media)
                .FirstOrDefault(w => w.Id == id);

            if (workout == null)
            {
                result.IsSuccess = false;
                result.Message = "تمرین یافت نشد.";
                return result;
            }

            result.IsSuccess = true;
            result.Data = _mapper.Map<WorkoutDto>(workout);
            return result;
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var result = new ServiceResult<bool>();

            var workout = await _uow.WorkoutRepository.FindAsync(id);
            if (workout == null)
            {
                result.IsSuccess = false;
                result.Message = "تمرین یافت نشد.";
                return result;
            }

            _uow.WorkoutRepository.Remove(id);
            await _uow.CommitAsync();

            result.IsSuccess = true;
            result.Data = true;
            return result;
        }
    }

}
