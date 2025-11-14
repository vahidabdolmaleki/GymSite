namespace Entities
{
    public class Workout : BaseEntity
    {
        // دسته‌بندی (Category / SubCategory)
        public int WorkoutCategoryId { get; set; }         // الزاماً یک دسته‌بندی کلی
        public WorkoutCategory? WorkoutCategory { get; set; }

        public int? WorkoutSubCategoryId { get; set; }     // زیر دسته (اختیاری)
        public WorkoutSubCategory? WorkoutSubCategory { get; set; }

        // هویت و توضیح
        public string Name { get; set; } = null!;          // نام تمرین (عنوان)
        public string? Description { get; set; }           // توضیحات کامل

        // پارامترهای عمومیِ تمرین (اختیاری برای انواع مختلف)
        public int? Reps { get; set; }                     // برای تمرینات مقاومتی
        public int? Sets { get; set; }                     // برای تمرینات مقاومتی
        public int? DurationMinutes { get; set; }          // برای تمرینات هوازی — مدت به دقیقه
        public decimal? WeightKg { get; set; }             // اگر تمرین وزنه‌ای با وزنه مشخص باشد (اختیاری)
        public string? Intensity { get; set; }             // مثال: Low / Medium / High  یا "۳ از ۵"

        // متادیتا و مدیریت
        public int? CreatedByCoachId { get; set; }         // اگر مربی ایجاد کرده (اختیاری)
        public Coach? CreatedByCoach { get; set; }

        public bool IsPublic { get; set; } = true;         // آیا این تمرین عمومی است یا فقط برای باشگاه/مربی؟
        public bool IsActive { get; set; } = true;

        // رسانه‌ها و لاگ‌ها (Navigation)
        public ICollection<WorkoutMedia> Media { get; set; } = new List<WorkoutMedia>();
        public ICollection<WorkoutLog> WorkoutLogs { get; set; } = new List<WorkoutLog>();

        // کمک برای جستجو / فیلتر سریع
        public string? PrimaryMuscleGroup { get; set; }     // مثال: Chest, Back, Legs
        public string? Equipment { get; set; }             // مثال: Barbell, Dumbbell, None

        // (اختیاری) شاخص/رتبه‌بندی یا دید کلی برای UI
        public int PopularityScore { get; set; } = 0;
    }

}






