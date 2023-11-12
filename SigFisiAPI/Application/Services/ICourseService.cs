using Application.Contracts.Course;

namespace Application.Services;

public interface ICourseService
{
    Task<IEnumerable<GetCourse>> SearchCoursesAsync(int? studyPlanId, int? semester);
}