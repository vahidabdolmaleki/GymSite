namespace Entities
{
    public class WorkoutCategory : BaseEntity
    {
        public string? Title { get; set; } // مثلا "گروه عضلانی"
        public string? Description { get; set; }
        public ICollection<WorkoutSubCategory> SubCategories { get; set; }
    }
}






