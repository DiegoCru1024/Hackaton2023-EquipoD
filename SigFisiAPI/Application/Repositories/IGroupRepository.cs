using Domain;

namespace Application.Repositories;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<int> GetNextNumberByCourseId (int courseId);
    Task<Group?> GetByNumberAndCourseId(int groupNumber, int groupCourseId);
}