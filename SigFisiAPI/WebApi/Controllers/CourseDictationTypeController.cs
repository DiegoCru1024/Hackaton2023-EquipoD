using Application.Contracts.CourseDictationType;
using Application.Services;
using Application.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CourseDictationTypeController : ControllerBase
{
    private readonly ICourseDictationTypeService _courseDictationTypeService;

    public CourseDictationTypeController(ICourseDictationTypeService courseDictationTypeService)
    {
        _courseDictationTypeService = courseDictationTypeService;
    }

    [HttpGet("Search")]
    public async Task<IActionResult> SearchCourseDictationTypes([FromQuery]SearchCourseDictationType searchCourseDictationType)
    {
        var courseDictationTypes = await _courseDictationTypeService.SearchCourseDictationTypes(searchCourseDictationType);
        return Ok(courseDictationTypes);
    }
}