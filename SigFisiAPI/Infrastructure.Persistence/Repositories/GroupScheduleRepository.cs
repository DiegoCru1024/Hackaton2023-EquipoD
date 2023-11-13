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
    public async Task<IEnumerable<GroupSchedule>> GetUnavailableScheduleInDayAsync(int groupNumber, int dayId)
    {
        return await DbSet.Include(x => x.Group)
            .Where(x => x.Group.Number == groupNumber && x.DayId == dayId)
            .ToListAsync();
    }
}