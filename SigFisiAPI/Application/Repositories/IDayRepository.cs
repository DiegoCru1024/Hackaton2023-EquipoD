using Domain;

namespace Application.Repositories;

public interface IDayRepository : IGenericRepository<Day>
{
    Task<Day?> GetByNumberAsync(int number);
}