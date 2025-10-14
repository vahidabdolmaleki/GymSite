using DAL.Context;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using DAL.Repository;
using DAL.Repository.GenericRepository;
using DAL.Repository.LogRepository;
using DAL.Repository.MembershipType;
using DAL.Repository.NotificationRepository;
using DAL.Repository.SupplementRepository;
using DAL.Repository.WorkoutRepository;
using Entities;
using Microsoft.Extensions.Configuration;


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
        public INotificationRepository NotificationRepository => new NotificationRepository(_gymDbContext);
        public IDeviceRepository DeviceRepository => new DeviceRepository(_gymDbContext);
        public IMembershipRepository MembershipRepository => new MembershipRepository(_gymDbContext);
        public IMembershipTypeRepository MembershipTypeRepository => new MembershipTypeRepository(_gymDbContext);
        public ISupplementRepository SupplementRepository => new SupplementRepository(_gymDbContext);
        public ILogRepository LogRepository => new LogRepository(_gymDbContext);
        public IHealthRecordRepository HealthRecordRepository => new HealthRecordRepository(_gymDbContext);
        public IDietPlanRepository DietPlanRepository => new DietPlanRepository(_gymDbContext);
        public ICoachRepository CoachRepository => new CoachRepository(_gymDbContext);
        public IClassEnrollmentRepository ClassEnrollmentRepository => new ClassEnrollmentRepository(_gymDbContext);
        public IGymClassRepository GymClassRepository => new GymClassRepository(_gymDbContext);
        public ICategoryRepository CategoryRepository => new CategoryRepository(_gymDbContext);
        public IStudentRepository StudentRepository => new StudentRepository(_gymDbContext);
        public IRoleRepository RoleRepository => new RoleRepository(_gymDbContext);
        public IPermissionRepository PermissionRepository => new PermissionRepository(_gymDbContext);
        public IRolePermissionRepository RolePermissionRepository => new RolePermissionRepository(_gymDbContext);
        public IPersonRoleRepostiory PersonRoleRepostiory => new PersonRoleRepository(_gymDbContext);
        public IUserRoleRepository UserRoleRepository => new UserRoleRepository(_gymDbContext);
        public IUserMembershipRepository UserMembershipRepository => new UserMembershipRepository(_gymDbContext);
        public IWorkoutPlanRepository WorkoutPlanRepository => new WorkoutPlanRepository(_gymDbContext);
        public IWorkoutLogRepository WorkoutLogRepository => new WorkoutLogRepository(_gymDbContext);
        public IWorkoutHistoryRepository WorkoutHistoryRepository =>  new  WorkoutHistoryRepository(_gymDbContext);
        public IWorkoutCategoryRepository WorkoutCategoryRepository => new WorkoutCategoryRepository(_gymDbContext);
        public IWorkoutSubCategoryRepository WorkoutSubCategoryRepository => new WorkoutSubCategoryRepository(_gymDbContext);
        public IWorkoutMediaRepository WorkoutMediaRepository => new WorkoutMediaRepository(_gymDbContext);
        public IAddressRepository AddressRepository => new AddressRepository(_gymDbContext);
        public IAddressDetailRepository AddressDetailRepository => new AddressDetailRepository(_gymDbContext);
        public IOrderItemRepository OrderItemRepository => new OrderItemRepository(_gymDbContext);
        
        private IProductRepository? _productRepository;

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository ??= new ProductRepository(_gymDbContext);
            }
        }

        // --- Generic Repository's
        public IGenericRepository<PersonPicture> PersonPictureRepository =>   new GenericRepository<PersonPicture>(_gymDbContext);
        public IGenericRepository<UnitCity> UnitCityRepository =>   new GenericRepository<UnitCity>(_gymDbContext);
        public IGenericRepository<User> UserRepository =>   new GenericRepository<User>(_gymDbContext);        

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
