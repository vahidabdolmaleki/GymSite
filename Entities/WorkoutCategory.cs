namespace Entities
{
    public class WorkoutCategory : BaseEntity
    {
        public string Name { get; set; } // مثلا "گروه عضلانی"
        public ICollection<WorkoutSubCategory> SubCategories { get; set; }
    }
}






