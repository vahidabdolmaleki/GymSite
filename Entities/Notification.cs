namespace Entities
{
    public class Notification : BaseEntity
    {
        // 🔹 به چه کسی مربوطه؟
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;

        // 🔹 پیام
        public string Title { get; set; } = null!;   // عنوان نوتیفیکیشن
        public string Message { get; set; } = null!; // متن نوتیفیکیشن

        // 🔹 وضعیت خواندن
        public bool IsRead { get; set; } = false;

        // 🔹 زمان‌ها
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? SentAt { get; set; }  // زمان ارسال واقعی (ممکنه بعدا باشه)

        // 🔹 نوع ارسال (Push, Email, SMS)
        public NotificationType Type { get; set; } = NotificationType.Push;

        // 🔹 وضعیت ارسال (Pending, Sent, Failed)
        public NotificationStatus Status { get; set; } = NotificationStatus.Pending;

        // 🔹 برای ارسال به یک Device خاص (اختیاری)
        public int? DeviceId { get; set; }
        public Device? Device { get; set; }

        // 🔹 اولویت (برای صف‌بندی)
        public int Priority { get; set; } = 1; // 1 = Normal, 2 = High, 3 = Critical

        // 🔹 پیوست (اختیاری: مثلا لینک عکس یا ویدیو)
        public string? AttachmentUrl { get; set; }

        // Enums
        public enum NotificationType
        {
            Push = 0,
            Email = 1,
            SMS = 2
        }

        public enum NotificationStatus
        {
            Pending = 0,
            Sent = 1,
            Failed = 2
        }
    }

}






