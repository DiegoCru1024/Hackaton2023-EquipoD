using Application.Contracts.Classroom;

namespace Application.Services;

public interface IClassroomService
{
    Task<IEnumerable<GetClassroom>> GetAllAvailableByScheduleId(int scheduleId);
}