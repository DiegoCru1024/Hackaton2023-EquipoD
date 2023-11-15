using Application.Contracts.Group;
using Domain;

namespace Application.Repositories;

public interface IGroupRepository : IGenericRepository<Group>
{
    Task<IEnumerable<Group>> GetGroupsByStudyPlanAndSemester(int studyPlanId, int semester);
    Task<int> GetNextNumberByCourseId (int courseId);
    Task<List<Group>> GetAllByCourseId(int courseId);
    Task<IEnumerable<Group>> GetByNumberAndCourseId(int groupNumber, int groupCourseId);
}