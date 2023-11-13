using Application.Contracts.GroupSchedule;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupScheduleController : ControllerBase
{
    private readonly IGroupScheduleService _groupScheduleService;

    public GroupScheduleController(IGroupScheduleService groupScheduleService)
    {
        _groupScheduleService = groupScheduleService;
    }

    [HttpGet("FindAvailableSchedules")]
    public async Task<IActionResult> FindAvailableSchedules([FromQuery]FindAvailableSchedules model)
    {
        var schedules = await _groupScheduleService.FindAvailableSchedules(model);
        return Ok(schedules);
    }
}