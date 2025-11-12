namespace ApplicationService.DTOs.Student
{
    public class StudentRegisterDto
    {
        public int PersonId { get; set; }
        public int? CoachId { get; set; }
        public string? Level { get; set; }
        public string? Goal { get; set; }
    }

}
