using Application.Contracts.Group;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGroupById(int id)
    {
        var group = await _groupService.GetGroupByIdAsync(id);
        return Ok(group);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllGroups()
    {
        var groups = await _groupService.GetAllGroupsAsync();
        return Ok(groups);
    }

    [HttpGet("GetGroupNumbers")]
    public async Task<IActionResult> GetByStudyPlanAndSemester(int studyPlanId, int semester)
    {
        var groups = await _groupService.GetNumberByStudyPlanAndSemesterAsync(studyPlanId, semester);
        return Ok(groups);
    }

    [HttpPost]
    public async Task<IActionResult> CreateGroup(CreateGroup model)
    {
        var group = await _groupService.CreateGroupAsync(model);
        return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, group);
    }

    [HttpGet("NextGroupNumber/{courseId}")]
    public async Task<IActionResult> GetNextGroupNumberByCourseId(int courseId)
    {
        var nextGroupNumber = await _groupService.GetNextGroupNumberByCourseId(courseId);
        return Ok(nextGroupNumber);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        await _groupService.DeleteGroupAsync(id);
        return NoContent();
    }


}