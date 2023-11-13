using Domain;

namespace Application.Repositories;

public interface IGroupScheduleRepository : IGenericRepository<GroupSchedule>
{
    Task<IEnumerable<GroupSchedule>> GetUnavailableSchedulesAsync(int groupNumber, int semester);
    Task<IEnumerable<GroupSchedule>> GetUnavailableSchedulesByDayAsync(int groupNumber, int semester, int dayId);
}