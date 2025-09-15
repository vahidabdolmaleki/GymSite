namespace Entities
{
    public class Coach : BaseEntity
    {
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public string? Specialty { get; set; }
        public ICollection<GymClass> Classes { get; set; } = new List<GymClass>();
    }
}






