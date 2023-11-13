using Application.Contracts.GroupSchedule;

namespace Application.Services;

public interface IGroupScheduleService
{
    Task<IEnumerable<Schedule>> FindAvailableSchedules(FindAvailableSchedules model);
}