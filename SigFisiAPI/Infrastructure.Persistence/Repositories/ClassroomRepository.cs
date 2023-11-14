using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class ClassroomRepository : GenericRepository<Classroom>, IClassroomRepository
{
    public ClassroomRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Classroom>> GetAvailableClassroomsByScheduleId()
    {
        throw new NotImplementedException();
    }
}