namespace Entities
{
    public class WorkoutHistory : BaseEntity
    {
        public int WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; } = null!;
        public DateTime DoneAt { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
        public bool Completed { get; set; } = true;
    }
}






