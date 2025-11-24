namespace Entities
{
    // 🔹 تمرینات انجام شده
    public class WorkoutLog : BaseEntity
    {
        public int PersonId { get; set; }          // شاگردی که تمرین را انجام داده
        public Person Person { get; set; } = null!;

        public int WorkoutId { get; set; }         // تمرینی که انجام شده
        public Workout Workout { get; set; } = null!;

        public DateTime PerformedAt { get; set; } = DateTime.UtcNow;

        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
        public int? DurationMinutes { get; set; }
        public bool IsCompleted { get; set; } = false;
        public string? Notes { get; set; }         // توضیحات مربی/شاگرد
    }

}






