namespace ApplicationService.DTOs.UserMemberShip
{
    public class UserMembershipCreateDto
    {
        public int PersonId { get; set; }
        public int MembershipId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationDays { get; set; }
    }

}
