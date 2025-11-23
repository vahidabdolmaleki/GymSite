namespace Entities
{
    public class WorkoutPlan : BaseEntity
    {
        public int PersonId { get; set; }   // شاگرد
        public Person Person { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<WorkoutPlanItem> Items { get; set; } = new List<WorkoutPlanItem>();
    }
}






