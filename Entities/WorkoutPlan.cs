namespace Entities
{
    
    public class WorkoutPlan : BaseEntity
    {
        public int? StudentId { get; set; }         // شاگرد
        public Student Student { get; set; } = null!;

        public int? CoachId { get; set; }           // مربی ایجاد‌کننده
        public Coach Coach { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public ICollection<WorkoutPlanItem> Items { get; set; } = new List<WorkoutPlanItem>();
    }

}






