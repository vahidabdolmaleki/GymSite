namespace ApplicationService.DTOs.WorkoutLog
{
    public class WorkoutLogCreateDto
    {
        public int PersonId { get; set; }
        public int WorkoutId { get; set; }

        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Notes { get; set; }
    }


}
