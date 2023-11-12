using Application.Contracts.Group;
using Application.Exceptions;
using Application.Repositories;

namespace Application.Services.Implementations;

public class GroupService : IGroupService
{
    private readonly IUnitOfWork _unitOfWork;

    public GroupService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GetGroup?> GetGroupByIdAsync(int id)
    {
        var group = await _unitOfWork.Groups.GetByIdAsync(id);

        if (group == null)
        {
            throw new AppException("No se encontro la el grupo");
        }

        return new GetGroup();
    }

    public async Task<IEnumerable<GetGroup>?> GetAllGroupsAsync()
    {
        throw new NotImplementedException();
    }
}