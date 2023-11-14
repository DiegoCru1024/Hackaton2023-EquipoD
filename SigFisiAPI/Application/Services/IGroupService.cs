using Application.Contracts.Group;
using Application.Contracts.GroupSchedule;

namespace Application.Services;

public interface IGroupService
{
    Task<GetGroupWithSchedules> CreateGroupAsync(CreateGroup createGroup);
    Task<GetGroupWithSchedules?> GetGroupByIdAsync(int id);
    Task<IEnumerable<GetGroup>?> GetAllGroupsAsync();
    Task<IEnumerable<GetGroupNumber>?> GetNumberByStudyPlanAndSemesterAsync(int studyPlanId, int semester);
    Task<int> GetNextGroupNumberByCourseId(int courseId);
    Task DeleteGroupAsync(int id);
}