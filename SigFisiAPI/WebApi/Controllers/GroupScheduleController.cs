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

    [HttpGet("GetAllUnavailable")]
    public async Task<IActionResult> GetUnavailableSchedules(int groupNumber, int semester)
    {
        var schedules = await _groupScheduleService.GetUnavailableSchedules(groupNumber, semester);
        return Ok(schedules);
    }
}