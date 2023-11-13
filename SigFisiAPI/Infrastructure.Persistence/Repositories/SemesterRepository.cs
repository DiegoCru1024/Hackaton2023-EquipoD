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

    public async Task<Semester?> GetActiveSemester()
    {
        return await DbSet.FirstOrDefaultAsync(x => x.IsActive == true);
    }

    public async Task SetActiveSemester(int semesterId)
    {
        var semester = await DbSet.FirstOrDefaultAsync(x => x.Id == semesterId);
        if (semester != null)
        {
            semester.IsActive = true;
        }
        var semesters = await DbSet.ToListAsync();
        foreach (var s in semesters)
        {
            if (s.Id != semesterId)
            {
                s.IsActive = false;
            }
        }
    }
}