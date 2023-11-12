using Application.Contracts.StudyPlan;

namespace Application.Services;

public interface IStudyPlanService
{
    Task<IEnumerable<GetStudyPlan>> GetAllStudyPlansAsync();
}