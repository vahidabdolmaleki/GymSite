namespace Entities
{
    public class Log:BaseEntity
    {
        public int? UserId { get; set; }
        public User? User { get; set; }
        public string Action { get; set; } = null!; // مثل "Login" یا "FailedPassword"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? IpAddress { get; set; }
    }
}






