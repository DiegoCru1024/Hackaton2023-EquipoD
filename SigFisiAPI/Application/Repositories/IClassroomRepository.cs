using Domain;

namespace Application.Repositories;

public interface IClassroomRepository : IGenericRepository<Classroom>
{
    Task<IEnumerable<Classroom>> GetAvailableClassroomsByScheduleId();
}