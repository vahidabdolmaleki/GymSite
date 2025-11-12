namespace ApplicationService.DTOs
{
    public class CoachDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public int? ExperinceYears { get; set; } = null!;
        public string? CertificateNumber { get; set;}
        public string? Specilization { get; set; }
        public bool? IsActive { get; set;}
    }

}
