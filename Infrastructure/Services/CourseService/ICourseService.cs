using Domain.DTOs.CourseDTO;
using Domain.Responses;

namespace Infrastructure.Services.CourseService;

public interface ICourseService
{
    
    Task<Response<List<GetCourseDTO>>> GetCoursesAsync();
    Task<Response<GetCourseDTO>> GetCourseByIdAsync(int id);
    Task<Response<string>> CreateCourseAsync(AddCourseDTO course);
    Task<Response<string>> UpdateCourseAsync(UpdateCourseDTO course);
    Task<Response<bool>> DeleteCourseAsync(int id);
}
