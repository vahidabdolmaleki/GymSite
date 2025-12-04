namespace Entities
{
    public class GymClass : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public int? CoachId { get; set; }
        public Coach? Coach { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int Capacity { get; set; } = 20;
        public int CategoryId { get; set; } // FK به Category (دسته‌بندی تمرین)
        public Category? Category { get; set; }
        public ICollection<ClassEnrollment> Enrollments { get; set; } = new List<ClassEnrollment>();
    }

}






