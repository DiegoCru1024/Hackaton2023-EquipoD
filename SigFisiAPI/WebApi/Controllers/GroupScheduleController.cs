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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAvailableSchedules()
    {
        var schedules = await _groupScheduleService.GetAllSchedules();
        return Ok(schedules);
    }

    [HttpGet("GetAllUnavailable")]
    public async Task<IActionResult> GetUnavailableSchedules(int groupNumber, int semester)
    {
        var schedules = await _groupScheduleService.GetUnavailableSchedules(groupNumber, semester);
        return Ok(schedules);
    }

    [HttpGet("GetAllWithoutClassroom")]
    public async Task<IActionResult> GetSchedulesWithoutClassroom()
    {
        var schedules = await _groupScheduleService.GetSchedulesWithoutClassroom();
        return Ok(schedules);
    }
}