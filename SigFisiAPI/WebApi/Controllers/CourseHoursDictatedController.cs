using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseHoursDictatedController : ControllerBase
{
    private readonly ICourseHoursDictatedService _courseHoursDictatedService;

    public CourseHoursDictatedController(ICourseHoursDictatedService courseHoursDictatedService)
    {
        _courseHoursDictatedService = courseHoursDictatedService;
    }

    [HttpGet]
    public async Task<IActionResult> SearchCourseHoursDictated([FromQuery]int courseId)
    {
        var courseHoursDictated = await _courseHoursDictatedService.SearchCourseHoursDictated(courseId);
        return Ok(courseHoursDictated);
    }
}