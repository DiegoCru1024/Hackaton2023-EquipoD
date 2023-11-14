using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClassroomController : ControllerBase
{
    private readonly IClassroomService _classroomService;

    public ClassroomController(IClassroomService classroomService)
    {
        _classroomService = classroomService;
    }

    [HttpGet("GetAllAvailable/{scheduleId:int}")]
    public async Task<IActionResult> GetAllAvailableByScheduleId(int scheduleId)
    {
        var classroom = await _classroomService.GetAllAvailableByScheduleId(scheduleId);
        return Ok(classroom);
    }
}