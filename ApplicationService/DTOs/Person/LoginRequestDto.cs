namespace ApplicationService.DTOs.Person
{
    public class LoginRequestDto
    {
        public string UsernameOrIdentifier { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? PushNotificationId { get; set; }
        public string? DeviceType { get; set; }
    }
}
