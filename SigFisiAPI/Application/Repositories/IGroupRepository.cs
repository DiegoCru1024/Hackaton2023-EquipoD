using Application.Contracts.Group;
using Domain;

namespace Application.Repositories;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<List<int>> GetGroupNumbers(int studyPlanId, int semester);
    Task<int> GetNextNumberByCourseId (int courseId);
    Task<Group?> GetByNumberAndCourseId(int groupNumber, int groupCourseId);
}