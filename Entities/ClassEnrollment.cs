namespace Entities
{
    public class ClassEnrollment : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;
        public int GymClassId { get; set; }
        public GymClass GymClass { get; set; } = null!;
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public bool IsPaid { get; set; } = false;
    }
}






