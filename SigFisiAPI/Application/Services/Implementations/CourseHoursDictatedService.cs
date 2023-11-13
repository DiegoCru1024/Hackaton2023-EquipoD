using Application.Contracts.CourseHoursDictated;
using Application.Repositories;

namespace Application.Services.Implementations;

public class CourseHoursDictatedService : ICourseHoursDictatedService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseHoursDictatedService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<GetCourseHoursDictated>> SearchCourseHoursDictated(int courseId)
    {
        var courseHoursDictated = await _unitOfWork.CourseHoursDictated.SearchCourseHoursDictated(courseId);
        return courseHoursDictated.Select(x => new GetCourseHoursDictated()
        {
            DictationTypeName = x.CourseDictationType.Name,
            Hours = x.Hours,
            CourseName = x.Course.Name,
            Id = x.Id,
            DictationTypeId = x.CourseDictationTypeId
        });
    }
}