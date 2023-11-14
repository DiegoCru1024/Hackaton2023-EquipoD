using Application.Contracts.Group;
using Application.Contracts.GroupSchedule;

namespace Application.Services;

public interface IGroupScheduleService
{
    Task<IEnumerable<GetGroupSchedule>> GetAllSchedules();
    Task<IEnumerable<GetGroupSchedule>> SearchGroupSchedule(int groupNumber, int semester,
        int studyPlanId);
    Task<IEnumerable<GetGroupSchedule>> GetUnavailableSchedules(int groupNumber, int semester);
    Task<GetGroupSchedule> AssignClassroom(int scheduleId, int classroomId);
    Task<IEnumerable<GetGroupSchedule>> GetSchedulesWithoutClassroom();
}