namespace Entities
{
    public class DietPlan : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public string MealType { get; set; } = null!; // Breakfast, Lunch, Dinner, Snack
        public string Description { get; set; } = null!;
        public int? Calories { get; set; }
        public DateTime? Date { get; set; } // برای چه روزی
    }
}






