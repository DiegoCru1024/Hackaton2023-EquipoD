using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudyPlanController : ControllerBase
{
    private readonly IStudyPlanService StudyPlanService;

    public StudyPlanController(IStudyPlanService studyPlanService)
    {
        StudyPlanService = studyPlanService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllStudyPlans()
    {
        var studyPlans = await StudyPlanService.GetAllStudyPlansAsync();
        return Ok(studyPlans);
    }

}