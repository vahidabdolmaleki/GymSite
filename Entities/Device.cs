namespace Entities
{
    public class Device : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public string? IP { get; set; }
        public string? DeviceType { get; set; } // "Android","iOS","Web"
        public string? PushNotificationId { get; set; } // token
        public DateTime LastSeenAt { get; set; } = DateTime.UtcNow;
    }
}






