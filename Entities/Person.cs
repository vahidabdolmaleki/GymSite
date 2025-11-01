namespace Entities
{
    public class Person : BaseEntity
    {
        // هویت
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? FatherName { get; set; }
        public string? NationalCode { get; set; } // پیشنهاد: UNIQUE اگر اجباریه
        public DateTime? BirthDate { get; set; }

        // احراز هویت / دسترسی
        public string? Username { get; set; }   // اختیاری اگر با ایمیل لاگین کنین
        public string PasswordHash { get; set; } = null!; // هش‌شده (BCrypt / Identity)
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        // جزئیات پروفایل
        public string? Education { get; set; }
        public string? Bio { get; set; }

        // Navigation
        public ICollection<PersonRole> PersonRoles { get; set; } = new List<PersonRole>();
        public ICollection<PersonPicture> Pictures { get; set; } = new List<PersonPicture>();
        public ICollection<Device> Devices { get; set; } = new List<Device>();
        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public ICollection<Log> Logs { get; set; } = new List<Log>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public ICollection<UserMembership> Memberships { get; set; } = new List<UserMembership>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        // ارتباط با نوع شخص
        public int PersonTypeId { get; set; }     // کلید خارجی
        public PersonType? PersonType { get; set; } // ناوبری به نوع شخص


        // اگر بخوای جدای Coach/Student داشته باشی:
        public Coach? CoachProfile { get; set; }
        public Student? StudentProfile { get; set; }
    }
    public class PersonType : BaseEntity
    {
        public string Title { get; set; } // مثلا "مربی"، "شاگرد"، "ادمین"
        public string? Description { get; set; }
        public ICollection<Person> People { get; set; }
    }


}






