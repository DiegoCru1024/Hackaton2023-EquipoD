using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
{
    public SemesterRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<bool> HasGroups(int semesterId)
    {
        return await DbSet.AnyAsync(x => x.Id == semesterId && x.Groups.Any());
    }
}