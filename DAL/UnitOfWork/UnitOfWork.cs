using DAL.Context;
using DAL.Repository;
using DAL.Repository.GenericRepository;
using DAL.Repository.WorkoutRepository;
using Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IConfiguration _configuration;
        private readonly GymDbContext _gymDbContext;

        public UnitOfWork(GymDbContext gymDbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _gymDbContext = gymDbContext;
        }

        // --- Repositoryها ---
        public IPersonRepository PersonRepository => new PersonRepository(_gymDbContext);
        public IWorkoutRepository WorkoutRepository => new WorkoutRepository(_gymDbContext);
        public IOrderRepository OrderRepository => new OrderRepository(_gymDbContext);
        public IpaymentRepository PaymentRepository => new PaymentRepostiory(_gymDbContext);

        // --- Generic Repository's
        public IGenericRepository<AddressDetail> AddressDetailRepository => new GenericRepository<AddressDetail>(_gymDbContext);
        public IGenericRepository<Product> ProductRepository => new GenericRepository<Product>(_gymDbContext);
        public IGenericRepository<Address> AddressRepository =>   new GenericRepository<Address>(_gymDbContext);

        public IGenericRepository<Category> CategoryRepository =>   new GenericRepository<Category>(_gymDbContext);

        public IGenericRepository<ClassEnrollment> ClassEnrollmentRepository =>   new GenericRepository<ClassEnrollment>(_gymDbContext);

        public IGenericRepository<Coach> CoachRepository =>   new GenericRepository<Coach>(_gymDbContext);

        public IGenericRepository<DietPlan> DietPlanRepository =>   new GenericRepository<DietPlan>(_gymDbContext);

        public IGenericRepository<GymClass> GymClassRepository =>   new GenericRepository<GymClass>(_gymDbContext);

        public IGenericRepository<HealthRecord> HealthRecordRepository =>   new GenericRepository<HealthRecord>(_gymDbContext);

        public IGenericRepository<OrderItem> OrderItemRepository => new GenericRepository<OrderItem>(_gymDbContext);

        public IGenericRepository<Permission> PermissionRepository =>   new GenericRepository<Permission>(_gymDbContext);

        public IGenericRepository<PersonPicture> PersonPictureRepository =>   new GenericRepository<PersonPicture>(_gymDbContext);

        public IGenericRepository<PersonRole> PersonRoleRepository =>   new GenericRepository<PersonRole>(_gymDbContext);

        public IGenericRepository<Role> RoleRepository =>   new GenericRepository<Role>(_gymDbContext);

        public IGenericRepository<RolePermission> RolePermissionRepository =>   new GenericRepository<RolePermission>(_gymDbContext);

        public IGenericRepository<Student> StudentRepository =>   new GenericRepository<Student>(_gymDbContext);

        public IGenericRepository<Supplement> SupplementRepository =>   new GenericRepository<Supplement>(_gymDbContext);

        public IGenericRepository<UnitCity> UnitCityRepository =>   new GenericRepository<UnitCity>(_gymDbContext);

        public IGenericRepository<User> UserRepository =>   new GenericRepository<User>(_gymDbContext);

        public IGenericRepository<UserMembership> UserMembershipRepository =>   new GenericRepository<UserMembership>(_gymDbContext);

        public IGenericRepository<UserRole> UserRoleRepository =>   new GenericRepository<UserRole>(_gymDbContext);

        public IGenericRepository<WorkoutCategory> WorkoutCategoryRepository =>   new GenericRepository<WorkoutCategory>(_gymDbContext);

        public IGenericRepository<WorkoutHistory> WorkoutHistoryRepository =>   new GenericRepository<WorkoutHistory>(_gymDbContext);

        public IGenericRepository<WorkoutLog> WorkoutLogRepository =>   new GenericRepository<WorkoutLog>(_gymDbContext);

        public IGenericRepository<WorkoutPlan> WorkoutPlanRepository =>   new GenericRepository<WorkoutPlan>(_gymDbContext);

        public IGenericRepository<WorkoutSubCategory> WorkoutSubCategoryRepository =>   new GenericRepository<WorkoutSubCategory>(_gymDbContext);


        public void Commit()
        {
            _gymDbContext.SaveChanges();
        }

        public void Dispose()
        {
            _gymDbContext.Dispose();
        }
    }
}
