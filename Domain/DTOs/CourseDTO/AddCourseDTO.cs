using Domain.Enums;

namespace Domain.DTOs.CourseDTO;

public class AddCourseDTO
{
    
    public string CourseName { get; set; } = null!;
    public string? Description { get; set; }
    public Status Status { get; set; }

}
