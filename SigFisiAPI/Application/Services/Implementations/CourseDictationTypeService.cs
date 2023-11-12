using Application.Contracts.CourseDictationType;
using Application.Repositories;

namespace Application.Services.Implementations;

public class CourseDictationTypeService : ICourseDictationTypeService
{
    private IUnitOfWork _unitOfWork;

    public CourseDictationTypeService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetCourseDictationType>> SearchCourseDictationTypes(SearchCourseDictationType model)
    {
        var courseDictationTypes = await _unitOfWork.CourseDictationTypes.GetAllAsync();

        courseDictationTypes = courseDictationTypes
            .Where(x => x.CourseHoursDictateds
                .Any(y => y.CourseId == model.CourseId &&
                          y.Course.Semester == model.Semester &&
                          y.Course.StudyPlanId == model.StudyPlanId));

        return courseDictationTypes.Select(x => new GetCourseDictationType()
        {
            Id = x.Id,
            Name = x.Name,
        });
    }
}