namespace Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;

        // Navigation
        public ICollection<PersonRole> PersonRoles { get; set; } = new List<PersonRole>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    }
}






