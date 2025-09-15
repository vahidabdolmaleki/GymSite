namespace Entities
{
    public class Student : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
        public ICollection<ClassEnrollment> Enrollments { get; set; } = new List<ClassEnrollment>();
    }
}






