using Entities;
using Microsoft.EntityFrameworkCore;


namespace DAL.Context
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            string LocalConnection = "Server=.;Database=GymDb;User Id=GymUser;Password=Aa123456;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=True;";
            string ProductionConnection = "Server=SQL_SERVER_IP;Database=GymDb;User Id=sa;Password=RealPass123;Encrypt=True;TrustServerCertificate=True;";

            base.OnConfiguring(OptionsBuilder);
            // For Upload                
            //2017
            //OptionsBuilder.UseSqlServer(ProductionConnection);
            ////For Develop
            OptionsBuilder.UseSqlServer(LocalConnection);
        }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressDetail> AddressDetails { get; set; }
        public DbSet<UnitCity> UnitCities { get; set; }
        public DbSet<PersonPicture> PersonPictures { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<WorkoutCategory> WorkoutCategories { get; set; }
        public DbSet<WorkoutSubCategory> WorkoutSubCategories { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutLog> WorkoutLogs { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // کلید مرکب برای جدول واسط
            modelBuilder.Entity<PersonRole>()
                .HasKey(pr => new { pr.PersonId, pr.RoleId });

            // ارتباط Person ↔ PersonRole
            modelBuilder.Entity<PersonRole>()
                .HasOne(pr => pr.Person)
                .WithMany(p => p.PersonRoles)
                .HasForeignKey(pr => pr.PersonId);

            // ارتباط Role ↔ PersonRole
            modelBuilder.Entity<PersonRole>()
                .HasOne(pr => pr.Role)
                .WithMany(r => r.PersonRoles)
                .HasForeignKey(pr => pr.RoleId);
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });


            //رابطه های جدول UserRole
            modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Person)
            .WithMany(p => p.UserRoles)
            .HasForeignKey(ur => ur.PersonId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // جلوگیری از رکورد تکراری (یک کاربر یک نقش تکراری نداشته باشد)
            modelBuilder.Entity<UserRole>()
                .HasIndex(ur => new { ur.PersonId, ur.RoleId })
                .IsUnique();

        }

    }
}
