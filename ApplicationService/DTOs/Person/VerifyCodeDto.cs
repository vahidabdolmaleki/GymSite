namespace ApplicationService.DTOs.Person
{
    public class VerifyCodeDto
    {
        public string UsernameOrPhone { get; set; } = null!;
        public string Code { get; set; } = null!;
    }


}
