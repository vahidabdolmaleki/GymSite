namespace Entities
{
    public class WorkoutPlan : BaseEntity
    {
        public int PersonId { get; set; } // برای چه نفریه (معمولا Student)
        public Person Person { get; set; } = null!;
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Sets { get; set; }
        public int? Reps { get; set; }
        public decimal? Weight { get; set; }
    }
}






