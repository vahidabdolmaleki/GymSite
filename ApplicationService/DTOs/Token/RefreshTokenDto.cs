namespace ApplicationService.DTOs.Token
{
    public class RefreshTokenDto
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }

}
