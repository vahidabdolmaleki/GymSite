
using DAL.Repository.GenericRepository;
using DAL.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository.WorkoutRepository;
using DAL.Repository.NotificationRepository;
using DAL.Repositories.Interfaces;
using DAL.Repository.SupplementRepository;
using DAL.Repository.LogRepository;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IDeviceRepository DeviceRepository { get; }
        IMembershipRepository MembershipRepository { get; }
        IMembershipTypeRepository MembershipTypeRepository { get; }
        INotificationRepository NotificationRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPersonRepository PersonRepository { get; }
        IpaymentRepository PaymentRepository { get; }
        ISupplementRepository SupplementRepository { get; }
        IWorkoutRepository WorkoutRepository { get; }
        ILogRepository LogRepository { get; }
        IProductRepository ProductRepository { get; }
        IHealthRecordRepository HealthRecordRepository { get; }
        IDietPlanRepository DietPlanRepository { get; }
        ICoachRepository CoachRepository { get; }
        IClassEnrollmentRepository ClassEnrollmentRepository { get; }
        IGymClassRepository GymClassRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IStudentRepository StudentRepository { get; }
        IRoleRepository RoleRepository { get; }
        IPermissionRepository PermissionRepository { get; }
        IRolePermissionRepository RolePermissionRepository { get; }
        IPersonRoleRepostiory PersonRoleRepostiory { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IUserMembershipRepository UserMembershipRepository { get; }
        IWorkoutPlanRepository WorkoutPlanRepository { get; }
        IWorkoutLogRepository WorkoutLogRepository { get; }
        IWorkoutHistoryRepository WorkoutHistoryRepository { get; }
        IWorkoutCategoryRepository WorkoutCategoryRepository { get; }
        IWorkoutSubCategoryRepository WorkoutSubCategoryRepository { get; }
        IWorkoutMediaRepository WorkoutMediaRepository { get; }
        IAddressRepository AddressRepository { get; }
        IAddressDetailRepository AddressDetailRepository { get; }                      
        IOrderItemRepository OrderItemRepository { get; }
        //---- GenericRepository
        IGenericRepository<PersonPicture> PersonPictureRepository { get; }
        IGenericRepository<UnitCity> UnitCityRepository { get; }
        IGenericRepository<User> UserRepository { get; }        

        void Commit();
    }
}
