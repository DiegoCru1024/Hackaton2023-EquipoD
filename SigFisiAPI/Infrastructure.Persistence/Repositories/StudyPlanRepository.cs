using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class StudyPlanRepository : GenericRepository<StudyPlan>, IStudyPlanRepository
{
    public StudyPlanRepository(ApplicationContext context) : base(context)
    {
    }
}