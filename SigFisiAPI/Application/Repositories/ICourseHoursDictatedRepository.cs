using Domain;

namespace Application.Repositories;

public interface ICourseHoursDictatedRepository : IGenericRepository<CourseHoursDictated>
{
    public Task<IEnumerable<CourseHoursDictated>> SearchCourseHoursDictated(int? courseId);
}