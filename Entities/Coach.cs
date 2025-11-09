namespace Entities
{
public class Coach : BaseEntity
{
    public int PersonId { get; set; }
    public string Specialization { get; set; } = null!; // تخصص‌ها: فیتنس، کراس فیت، تغذیه و ...
    public int ExperienceYears { get; set; } // سابقه کاری
    public string? CertificateNumber { get; set; } // شماره گواهینامه یا مجوز رسمی
    public bool IsActive { get; set; } = true;

    // Navigation
    public Person Person { get; set; } = null!;
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<GymClass> Classes { get; set; } = new List<GymClass>();
}

}






