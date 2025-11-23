namespace Entities
{
    public class WorkoutPlanItem : BaseEntity
    {
        public int WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; } = null!;

        public int WorkoutId { get; set; }
        public Workout Workout { get; set; } = null!;

        public int DayNumber { get; set; }       // شماره روز برنامه (روز ۱، روز ۲، ...)
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Notes { get; set; }
    }

}






