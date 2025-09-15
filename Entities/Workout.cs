namespace Entities
{
    public class Workout : BaseEntity
    {
        public int WorkoutSubCategoryId { get; set; }
        public WorkoutSubCategory WorkoutSubCategory { get; set; }

        public string Name { get; set; }         // نام تمرین
        public string Description { get; set; }  // توضیحات
        public int? Reps { get; set; }           // تکرار
        public int? Sets { get; set; }           // ست‌ها
        public int? DurationMinutes { get; set; } // مدت (برای هوازی‌ها)

        public ICollection<WorkoutLog> WorkoutLogs { get; set; }
    }
}






