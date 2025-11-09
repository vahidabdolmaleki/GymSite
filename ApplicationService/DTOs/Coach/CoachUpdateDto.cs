namespace ApplicationService.DTOs
{
    public class CoachUpdateDto
    {
        public int PersonId { get; set; }
        public string? Specilization { get; set; }
        public int? ExperinceYears { get; set; }
        public string? CertificateNumber { get; set;}
        public bool? IsActive {  get; set; }
    }

}
