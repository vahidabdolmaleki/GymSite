using Entities;

namespace ApplicationService.DTOs
{
    public class NotificationCreateDto
    {
        public int PersonId { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public Notification.NotificationType Type { get; set; }
        public string? MetaData { get; set; }
    }

}
