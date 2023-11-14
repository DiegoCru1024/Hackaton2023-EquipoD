using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CourseHoursDictatedRepository : GenericRepository<Domain.CourseHoursDictated>, ICourseHoursDictatedRepository
{
    public CourseHoursDictatedRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CourseHoursDictated>> SearchCourseHoursDictated(int? courseId = null)
    {
        var courseHoursDictated = DbSet
            .Include(x => x.Course)
            .ThenInclude(y => y.CourseHoursDictateds)
            .ThenInclude(z => z.CourseDictationType)
            .AsQueryable();

        if (courseId != null)
        {
            courseHoursDictated = courseHoursDictated.Where(x => x.CourseId == courseId);
        }

        return await courseHoursDictated.ToListAsync();
    }
}