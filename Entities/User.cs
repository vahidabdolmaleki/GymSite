namespace Entities
{
    public class User:BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<Log> Logs { get; set; } = new List<Log>();
    }
}






