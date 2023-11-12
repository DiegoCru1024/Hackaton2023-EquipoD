using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("Search")]
    public async Task<IActionResult> SearchCourses([FromQuery] int? studyPlanId, [FromQuery] int? semester)
    {
        var courses = await _courseService.SearchCoursesAsync(studyPlanId, semester);
        return Ok(courses);
    }
}