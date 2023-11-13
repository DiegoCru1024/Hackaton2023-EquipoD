using Domain;

namespace Application.Repositories;

public interface IGroupScheduleRepository : IGenericRepository<GroupSchedule>
{
    Task<IEnumerable<GroupSchedule>> GetUnavailableSchedulesAsync(int groupNumber, int semester);
}