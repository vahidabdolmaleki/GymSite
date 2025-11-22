namespace ApplicationService.DTOs.WorkoutPlan
{
    public class WorkoutPlanItemCreateDto
    {
        public int DayOfWeek { get; set; }    // 1=شنبه
        public int WorkoutId { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? DurationMinutes { get; set; }
    }

}
