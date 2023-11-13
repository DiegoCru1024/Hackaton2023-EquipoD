using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationContext context) : base(context)
    {
    }

    public override async Task<Group?> GetByIdAsync(int id)
    {
        return await DbSet
            .Include(x => x.GroupSchedules)
            .ThenInclude(y => y.CourseDictationType)
            .Include(x => x.GroupSchedules)
            .ThenInclude(y => y.Day)
            .Include(x => x.Course)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<IEnumerable<Group>> GetAllAsync()
    {
        return await DbSet
            .Include(x => x.GroupSchedules)
            .Include(x => x.Course)
            .ToListAsync();
    }
    public async Task<int> GetNextNumberByCourseId(int courseId)
    {
        var lastGroup = await DbSet.Where(x => x.CourseId == courseId)
            .OrderByDescending(x => x.Number)
            .FirstOrDefaultAsync();

        return lastGroup?.Number + 1 ?? 1;
    }

    public async Task<Group?> GetByNumberAndCourseId(int groupNumber, int groupCourseId)
    {
        return await DbSet
            .Include(x => x.GroupSchedules)
            .Include(x => x.Course)
            .FirstOrDefaultAsync(x => x.Number == groupNumber && x.CourseId == groupCourseId);
    }
}