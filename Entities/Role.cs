namespace Entities
{
    public class Role:BaseEntity
    {
        public string RoleName { get; set; } = string.Empty;

        // Navigation
        public ICollection<PersonRole> PersonRoles { get; set; } = new List<PersonRole>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();


    }
}






