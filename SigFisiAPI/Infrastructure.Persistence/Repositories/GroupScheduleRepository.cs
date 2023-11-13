using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GroupScheduleRepository : GenericRepository<GroupSchedule>, IGroupScheduleRepository
{
    public GroupScheduleRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<GroupSchedule>> GetUnavailableSchedulesAsync(int groupNumber, int semester)
    {
        return await DbSet.Include(x => x.Group)
            .ThenInclude(x => x.Course)
            .Include(x => x.Day)
            .Include(x => x.Classroom)
            .Where(x => x.Group.Number == groupNumber && x.Group.Course.Semester == semester)
            .ToListAsync();
    }
}