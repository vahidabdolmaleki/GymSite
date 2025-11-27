using ApplicationService.DTOs.UserMemberShip;
using ApplicationService.Interfaces;
using AutoMapper;
using Core;
using DAL.UnitOfWork;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationService.Services
{
    public class UserMembershipService : IUserMembershipService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserMembershipService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        // =======================================================
        // ✔ ایجاد اشتراک
        // =======================================================
        public async Task<ServiceResult<int>> CreateAsync(UserMembershipCreateDto dto)
        {
            var result = new ServiceResult<int>();

            try
            {
                var membership = await _uow.MembershipRepository.FindAsync(dto.MembershipId);
                var person = await _uow.PersonRepository.FindAsync(dto.PersonId);

                if (membership == null)
                {
                    return new ServiceResult<int>
                    { 
                        IsSuccess = false,
                        Message = "اشتراک یافت نشد.",
                        Data = -1
                    };
                }
                if (person == null)
                {
                    return new ServiceResult<int>
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد.",
                        Data = -2
                    };
                }

                var entity = new UserMembership
                {
                    PersonId = dto.PersonId,
                    MembershipId = dto.MembershipId,
                    UserId = dto.UserId,
                    StartDate = dto.StartDate,
                    EndDate = dto.StartDate.AddDays(dto.DurationDays)
                };

                await _uow.UserMembershipRepository.SaveAsync(entity);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Message = "اشتراک با موفقیت ثبت شد.";
                result.Data = entity.Id;

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        // =======================================================
        // ✔ حذف اشتراک
        // =======================================================
        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var result = new ServiceResult<bool>();

            try
            {
                var entity = await _uow.UserMembershipRepository.FindAsync(id);

                if (entity == null)
                {
                    result.IsSuccess = false;
                    result.Message = "اشتراک یافت نشد.";
                    return result;
                }

                _uow.UserMembershipRepository.Remove(entity.Id);
                await _uow.CommitAsync();

                result.IsSuccess = true;
                result.Message = "اشتراک حذف شد.";
                result.Data = true;

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = ex.Message;
                return result;
            }
        }

        // =======================================================
        // ✔ دریافت اشتراک‌های یک شخص
        // =======================================================
        public async Task<ServiceResults<UserMembershipDto>> GetForPersonAsync(int personId)
        {
            var result = new ServiceResults<UserMembershipDto>();

            var list = _uow.UserMembershipRepository
                .GetAllQueryable()
                .Where(x => x.PersonId == personId)
                .Include(x => x.Person)
                .Include(x => x.Membership)
                .Include(x => x.User)
                .ToList();

            var dtoList = list.Select(x => new UserMembershipDto
            {
                Id = x.Id,
                PersonFullName = x.Person.FirstName + " " + x.Person.LastName,
                MembershipTitle = x.Membership.Title,
                CreatedBy = x.User.FullName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsActive = x.EndDate >= DateTime.UtcNow
            });

            result.IsSuccess = true;
            result.Data = dtoList;

            return result;
        }

        // =======================================================
        // ✔ دریافت همه اشتراک‌ها
        // =======================================================
        public async Task<ServiceResults<UserMembershipDto>> GetAllAsync()
        {
            var result = new ServiceResults<UserMembershipDto>();

            var list = _uow.UserMembershipRepository
                .GetAllQueryable()
                .Include(x => x.Person)
                .Include(x => x.Membership)
                .Include(x => x.User)
                .ToList();

            var dtoList = list.Select(x => new UserMembershipDto
            {
                Id = x.Id,
                PersonFullName = x.Person.FirstName + " " + x.Person.LastName,
                MembershipTitle = x.Membership.Title,
                CreatedBy = x.User.FullName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                IsActive = x.EndDate >= DateTime.UtcNow
            });

            result.IsSuccess = true;
            result.Data = dtoList;

            return result;
        }
    }
}
