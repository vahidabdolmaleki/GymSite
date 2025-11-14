public class WorkoutDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? Reps { get; set; }
    public int? Sets { get; set; }
    public int? DurationMinutes { get; set; }

    public int WorkoutSubCategoryId { get; set; }
    public string SubCategoryName { get; set; } = null!;

    public List<WorkoutMediaDto> Media { get; set; } = new();
}

