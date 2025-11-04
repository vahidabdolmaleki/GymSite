namespace Entities
{
    public class Device : BaseEntity
    {
        public string PushNotificationId { get; set; } // token
        public string DeviceType { get; set; }// "Android","iOS","Web"
        public string IP { get; set; }
        public DateTime LastSeenAt { get; set; }// LastActiveDate برای آخرین بازدید و آخرین دستگاه کاربرد داره

        // 🔑 توکن‌ها
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }

        // 👤 ارتباط با کاربر
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }

}






