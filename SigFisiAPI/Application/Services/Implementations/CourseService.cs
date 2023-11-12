using Application.Contracts.Course;
using Application.Repositories;

namespace Application.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetCourse>> SearchCoursesAsync(int? studyPlanId = null, int? semester = null)
    {
        var courses = await _unitOfWork.Courses.GetAllAsync();
        if (studyPlanId != null)
        {
            courses = courses.Where(x => x.StudyPlanId == studyPlanId);
        }
        if( semester != null)
        {
            courses = courses.Where(x => x.Semester == semester);
        }

        return courses.Select(x => new GetCourse()
        {
            Id = x.Id,
            Name = x.Name
        });
    }
}