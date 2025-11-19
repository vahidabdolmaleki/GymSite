namespace Entities
{
    public class WorkoutSubCategory : BaseEntity
    {
        public int WorkoutCategoryId { get; set; }
        public WorkoutCategory WorkoutCategory { get; set; }

        public string Title { get; set; } // مثلا "سینه"
        public ICollection<Workout> Workouts { get; set; }
        public string? Description { get; set; }

    }
}






