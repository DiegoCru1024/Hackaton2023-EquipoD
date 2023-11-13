using Application.Repositories;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository <T> where T : class
{
    public readonly ApplicationContext Context;
    internal DbSet<T> DbSet;

    protected GenericRepository(ApplicationContext context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }


    public virtual async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await DbSet.AddRangeAsync(entities);
        return entities;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        return await Task.Run(() =>
        {
            DbSet.Update(entity);
            return entity;
        });
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        await Task.Run(() => DbSet.Remove(entity));
    }
}