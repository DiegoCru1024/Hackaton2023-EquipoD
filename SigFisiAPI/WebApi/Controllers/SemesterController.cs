using Application.Contracts.Semester;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class SemesterController : ControllerBase
{
    private readonly ISemesterService _semesterService;

    public SemesterController(ISemesterService semesterService)
    {
        _semesterService = semesterService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSemester(CreateSemester createSemester)
    {
        var semester = await _semesterService.CreateSemesterAsync(createSemester);
        return CreatedAtAction(nameof(GetSemesterById), new { id = semester.Id }, semester);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSemesterById(int id)
    {
        var semester = await _semesterService.GetSemesterAsync(id);
        return Ok(semester);
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllSemesters()
    {
        var semesters = await _semesterService.GetAllSemestersAsync();
        return Ok(semesters);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSemester(int id, [FromBody] UpdateSemester updateSemester)
    {
        var semester = await _semesterService.UpdateSemesterAsync(id, updateSemester);
        return Ok(semester);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSemester(int id)
    {
        await _semesterService.DeleteSemesterAsync(id);
        return NoContent();
    }

    [HttpPut("{id}/Activate")]
    public async Task<IActionResult> ActivateSemester(int id)
    {
        await _semesterService.ActivateSemesterAsync(id);
        return Ok();
    }

}