
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



        //---- GenericRepository
        IGenericRepository<Address> AddressRepository { get; }
        IGenericRepository<AddressDetail> AddressDetailRepository { get; }
        IGenericRepository<Category> CategoryRepository { get; }
        IGenericRepository<ClassEnrollment> ClassEnrollmentRepository { get; }
        IGenericRepository<Coach> CoachRepository { get; }
        IGenericRepository<DietPlan> DietPlanRepository { get; }
        IGenericRepository<GymClass> GymClassRepository { get; }
        IGenericRepository<HealthRecord> HealthRecordRepository { get; }
        IGenericRepository<OrderItem> OrderItemRepository { get; }
        IGenericRepository<Permission> PermissionRepository { get; }
        IGenericRepository<PersonPicture> PersonPictureRepository { get; }
        IGenericRepository<PersonRole> PersonRoleRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Role> RoleRepository { get; }
        IGenericRepository<RolePermission> RolePermissionRepository { get; }
        IGenericRepository<Student> StudentRepository { get; }
        IGenericRepository<UnitCity> UnitCityRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<UserMembership> UserMembershipRepository { get; }
        IGenericRepository<UserRole> UserRoleRepository { get; }
        IGenericRepository<WorkoutCategory> WorkoutCategoryRepository { get; }
        IGenericRepository<WorkoutHistory> WorkoutHistoryRepository { get; }
        IGenericRepository<WorkoutLog> WorkoutLogRepository { get; }
        IGenericRepository<WorkoutPlan> WorkoutPlanRepository { get; }
        IGenericRepository<WorkoutSubCategory> WorkoutSubCategoryRepository { get; }        

        void Commit();
    }
}
