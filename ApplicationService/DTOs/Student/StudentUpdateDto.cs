namespace ApplicationService.DTOs.Student
{
    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public int? CoachId { get; set; }
        public string? Level { get; set; }
        public string? Goal { get; set; }
        public bool IsActive { get; set; }
    }

}
