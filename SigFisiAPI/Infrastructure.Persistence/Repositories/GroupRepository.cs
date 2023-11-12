using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationContext context) : base(context)
    {
    }
}