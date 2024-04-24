namespace Domain.DTOs.CourseDTO;

public class GetCourseDTO
{
    public int Id { get; set; } 
    public string CourseName { get; set; } = null!;
    public string? Description { get; set; }
    public string Status { get; set; }

}
