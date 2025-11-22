namespace ApplicationService.DTOs.WorkoutPlan
{
    public class WorkoutPlanCreateDto
    {
        public int PersonId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<WorkoutPlanItemCreateDto> Items { get; set; } = new();
    }

    public class WorkoutPlanDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public List<WorkoutPlanItemDto> Items { get; set; } = new();
    }
    public class WorkoutPlanItemDto
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; } = null!;
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? DurationMinutes { get; set; }
    }


}
