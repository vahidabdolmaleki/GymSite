namespace Entities
{
    public class Membership:BaseEntity
    {
        public string Title { get; set; } = null!;
        public int DurationInDays { get; set; }
        public decimal Price { get; set; }
        public ICollection<UserMembership> UserMemberships { get; set; } = new List<UserMembership>();
    }
}






