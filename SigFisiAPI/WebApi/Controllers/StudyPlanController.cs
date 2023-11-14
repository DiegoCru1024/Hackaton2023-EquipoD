using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StudyPlanController : ControllerBase
{
    private readonly IStudyPlanService _studyPlanService;

    public StudyPlanController(IStudyPlanService studyPlanService)
    {
        _studyPlanService = studyPlanService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllStudyPlans()
    {
        var studyPlans = await _studyPlanService.GetAllStudyPlansAsync();
        return Ok(studyPlans);
    }

}