namespace ApplicationService.DTOs.UserMemberShip
{
    public class UserMembershipDto
    {
        public int Id { get; set; }
        public string PersonFullName { get; set; }
        public string MembershipTitle { get; set; }
        public string CreatedBy { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
    }

}
