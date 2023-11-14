using Application.Contracts.GroupSchedule;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
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

    [HttpGet("Search")]
    public async Task<IActionResult> SearchSchedules(int groupNumber, int semester, int studyPlanId)
    {
        var schedules = await _groupScheduleService.SearchGroupSchedule(groupNumber, semester, studyPlanId);
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

    [HttpPut("AssignClassroom/{scheduleId}/{classroomId}")]
    public async Task<IActionResult> AssignClassroom(int scheduleId, int classroomId)
    {
        var schedule = await _groupScheduleService.AssignClassroom(scheduleId, classroomId);
        return Ok(schedule);
    }
}