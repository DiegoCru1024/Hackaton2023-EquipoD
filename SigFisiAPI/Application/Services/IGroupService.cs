using Application.Contracts.Group;
using Application.Contracts.GroupSchedule;

namespace Application.Services;

public interface IGroupService
{
    Task<GetGroupWithSchedules> CreateGroupAsync(CreateGroup createGroup);
    Task<GetGroup?> GetGroupByIdAsync(int id);
    Task<IEnumerable<GetGroup>?> GetAllGroupsAsync();
}