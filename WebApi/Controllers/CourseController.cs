using Domain.DTOs.CourseDTO;
using Domain.Responses;
using Infrastructure.Services.CourseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
      private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("get-Course")]
    public async Task<Response<List<GetCourseDTO>>> GetCourseAsync()
    {
        return await _courseService.GetCoursesAsync();
    }
    [HttpGet("{CourseId:int}")]
    public async Task<Response<GetCourseDTO>> GetStudentByIdAsync(int courseId)
    {
        return await _courseService.GetCourseByIdAsync(courseId);
    }
    
    [HttpPost("create-Course")]
    public async Task<Response<string>> AddStudentAsync(AddCourseDTO courseDTO)
    {
        return await _courseService.CreateCourseAsync(courseDTO);
    }
    
    [HttpPut("update-Course")]
    public async Task<Response<string>> UpdateStudentAsync(UpdateCourseDTO updateCourseDTO)
    {
        return await _courseService.UpdateCourseAsync(updateCourseDTO);
    }
    
    [HttpDelete("{CourseId:int}")]
    public async Task<Response<bool>> DeleteStudentAsync(int CourseId)
    {
        return await _courseService.DeleteCourseAsync(CourseId);
    }
    
}
