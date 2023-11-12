using Application.Repositories;
using Domain;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class DayRepository : GenericRepository<Day>, IDayRepository
{
    public DayRepository(ApplicationContext context) : base(context)
    {
    }
}