namespace ApplicationService.DTOs.WorkoutLog
{
    public class WorkoutLogDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string PersonFullName { get; set; } = null!;

        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; } = null!;

        public DateTime PerformedAt { get; set; }

        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? DurationMinutes { get; set; }
        public string? Notes { get; set; }
    }


}
