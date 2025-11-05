namespace ApplicationService.DTOs.Person
{
    public class VerifyCodeDto
    {
        // می‌پذیرد نام‌کاربری یا شماره موبایل (مطابق متدهای قبلی شما)
        public string UsernameOrPhone { get; set; } = null!;
        public string Code { get; set; } = null!;
    }

}
