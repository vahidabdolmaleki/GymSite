namespace Entities
{
    // 🔹 شاخص‌های سلامت (مثلا BMI)
    public class HealthRecord : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public float Height { get; set; }
        public float Weight { get; set; }
        public float BMI { get; set; }
        public DateTime RecordDate { get; set; } = DateTime.UtcNow;
    }
}






