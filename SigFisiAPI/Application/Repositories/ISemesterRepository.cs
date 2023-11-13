using Domain;

namespace Application.Repositories;

public interface ISemesterRepository : IGenericRepository<Semester>
{
    Task<bool> HasGroups(int semesterId);
    Task<Semester?> GetActiveSemester();
    Task SetActiveSemester(int semesterId);

}