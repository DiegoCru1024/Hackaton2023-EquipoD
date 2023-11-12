using Application.Contracts.Group;

namespace Application.Services;

public interface IGroupService
{
    Task<GetGroup?> GetGroupByIdAsync(int id);
    Task<IEnumerable<GetGroup>?> GetAllGroupsAsync();
}