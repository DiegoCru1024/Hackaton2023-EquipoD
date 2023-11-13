using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class DayRepository : GenericRepository<Day>, IDayRepository
{
    public DayRepository(ApplicationContext context) : base(context)
    {
    }

    public async Task<Day?> GetByNumberAsync(int number)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Number == number);
    }
}