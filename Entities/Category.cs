namespace Entities
{
    public class Category : BaseEntity
    {
        public string Title { get; set; } = null!; // مثال: "Cardio", "Strength", "Yoga"
        public string? Description { get; set; }
        public ICollection<GymClass> Classes { get; set; } = new List<GymClass>();
    }
}






