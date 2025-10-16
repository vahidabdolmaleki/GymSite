namespace ApplicationService.DTOs.Person
{
    public class PersonLoginDto
    {
        public string Identifier { get; set; } = null!; // username or email or phone
        public string Password { get; set; } = null!;
    }
}
