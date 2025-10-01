namespace Entities
{
    public class PersonRole:BaseEntity
    {
        public int PersonId { get; set; }
        public int RoleId { get; set; }

        public DateTime AssignedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        // Navigation
        public Person Person { get; set; }
        public Role Role { get; set; }

    }
}






