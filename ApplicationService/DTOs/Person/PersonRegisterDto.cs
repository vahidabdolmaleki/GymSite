namespace ApplicationService.DTOs.Person
{
    public class PersonRegisterDto
        {
            // 👤 اطلاعات هویتی
            public string FirstName { get; set; } = null!;
            public string LastName { get; set; } = null!;
            public string? FatherName { get; set; }
            public string? NationalCode { get; set; }
            public DateTime? BirthDate { get; set; }

            // 🔐 اطلاعات حساب کاربری
            public string Username { get; set; } = null!;
            public string Password { get; set; } = null!;
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }

            // 🎓 اطلاعات تکمیلی
            public string? Education { get; set; }
            public string? Bio { get; set; }

            // 📱 اطلاعات دستگاه (برای Push Notification)
            public string? PushNotificationId { get; set; }
            public string? DeviceType { get; set; }

            // 💻 آی‌پی کاربر (اختیاری)
            public string? IP { get; set; }
            public int PersonTypeId { get; set; } = 3; // پیش‌فرض Athlete
    }




}
