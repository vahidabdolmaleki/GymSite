namespace Entities
{
    public class UserRole : BaseEntity
    {
        public int PersonId { get; set; }
        public int RoleId { get; set; }

        public int? AssignedById { get; set; } // اختیاری: کاربری که این نقش رو داد

        // Navigation
        public Person Person { get; set; } = null!;
        public Role Role { get; set; } = null!;
        public Person? AssignedBy { get; set; } // در صورت نیاز

    }
}






