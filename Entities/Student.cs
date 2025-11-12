namespace Entities
{
    public class Student : BaseEntity
    {
        public int PersonId { get; set; }
        public int? CoachId { get; set; } // شاگرد ممکنه هنوز مربی نداشته باشه
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public string? Level { get; set; } // سطح: مبتدی، متوسط، حرفه‌ای
        public string? Goal { get; set; } // هدف تمرینی (مثلاً افزایش وزن، فیتنس)
        // Navigation
        public Person Person { get; set; } = null!;
        public Coach? Coach { get; set; }
        public ICollection<UserMembership> Memberships { get; set; } = new List<UserMembership>();
        public ICollection<WorkoutPlan> WorkoutPlans { get; set; } = new List<WorkoutPlan>();
        public ICollection<ClassEnrollment> Enrollments { get; set; } = new List<ClassEnrollment>();
    }
}






