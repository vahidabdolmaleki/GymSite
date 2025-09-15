namespace Entities
{
    public class UserMembership
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int MembershipId { get; set; }
        public Membership Membership { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}






