using Application.Contracts.Semester;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

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
}