using Application.Contracts.StudyPlan;
using Application.Repositories;

namespace Application.Services.Implementations;

public class StudyPlanService : IStudyPlanService
{
    private readonly IUnitOfWork _unitOfWork;

    public StudyPlanService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<GetStudyPlan>> GetAllStudyPlansAsync()
    {
        var studyPlans = await _unitOfWork.StudyPlans.GetAllAsync();
        return studyPlans.Select(x => new GetStudyPlan()
        {
            Id = x.Id,
            Code = x.Code
        });
    }
}