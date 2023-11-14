using Application.Contracts.GroupSchedule;

namespace Application.Services;

public interface IGroupScheduleService
{
    Task<IEnumerable<GetGroupSchedule>> GetAllSchedules();
    Task<IEnumerable<GetGroupSchedule>> GetUnavailableSchedules(int groupNumber, int semester);
    Task<IEnumerable<GetGroupSchedule>> GetSchedulesWithoutClassroom();
}