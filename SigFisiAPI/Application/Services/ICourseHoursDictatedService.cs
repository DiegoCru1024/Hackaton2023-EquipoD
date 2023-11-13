using Application.Contracts.CourseHoursDictated;

namespace Application.Services;

public interface ICourseHoursDictatedService
{
    Task<IEnumerable<GetCourseHoursDictated>> SearchCourseHoursDictated(int courseId);
}