
public class WorkoutMediaDto
{
    public int Id { get; set; }
    public string FileUrl { get; set; } = null!;
    public string? ThumbnailUrl { get; set; }
    public string? MimeType { get; set; }
    public bool IsPrimary { get; set; }
    public int? DurationSeconds { get; set; }
    public string? Caption { get; set; }
}

