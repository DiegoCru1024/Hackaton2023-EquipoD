using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CourseDictationTypeRepository : GenericRepository<CourseDictationType>, ICourseDictationTypeRepository
{
    public CourseDictationTypeRepository(ApplicationContext context) : base(context)
    {
    }

    public override async Task<CourseDictationType?> GetByIdAsync(int id)
    {
        return await DbSet.Include(x => x.CourseHoursDictateds)
            .ThenInclude(y => y.Course)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}