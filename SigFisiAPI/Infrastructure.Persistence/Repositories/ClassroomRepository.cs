using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
{
    public ClassroomRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Classroom>> GetAvailableClassroomsByScheduleAndCapacity(TimeSpan startTime, TimeSpan endTime, int dayId, int capacity)
    {
        return await DbSet.Include(x => x.GroupSchedules)
            .Where(x => !x.GroupSchedules.Any(y =>
                y.DayId == dayId &&
                (startTime > y.EndTime || endTime < y.StartTime)
            ))
            .Where(x => x.Capacity >= capacity)
            .ToListAsync();
    }
}