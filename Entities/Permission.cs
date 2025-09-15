namespace Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string ActionName { get; set; } = null!; // مثل "ViewStudents" یا "EditProfile"
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}






