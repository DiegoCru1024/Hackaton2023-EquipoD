using Domain;

namespace Application.Repositories;

public interface IClassroomRepository : IGenericRepository<Classroom>
{
    Task<IEnumerable<Classroom>> GetAvailableClassroomsByScheduleAndCapacity(TimeSpan startTime, TimeSpan endTime, int dayId, int capacity,  int activeSemesterId);
}