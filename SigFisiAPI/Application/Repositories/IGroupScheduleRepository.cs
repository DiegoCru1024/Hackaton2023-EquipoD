using Domain;

namespace Application.Repositories;

public interface IGroupScheduleRepository : IGenericRepository<GroupSchedule>
{
    Task<IEnumerable<GroupSchedule>> GetUnavailableScheduleInDayAsync(int groupNumber, int dayId);
}