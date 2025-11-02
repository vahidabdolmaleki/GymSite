namespace ApplicationService.DTOs.Person
{
    public class ResetPasswordDto
    {
        public string UsernameOrPhone { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }

}
