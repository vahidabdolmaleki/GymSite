namespace Entities
{
    public class ClassCategory : BaseEntity
    {
        public string Name { get; set; } = null!;
        public ICollection<GymClass> Classes { get; set; } = new List<GymClass>();
    }

}






