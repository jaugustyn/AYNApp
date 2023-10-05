using Shared.Domain;
using Shared.Entities;

namespace Shared.Repositories;

public class GenericRepository<TEntity, TContext>: IGenericRepository<TEntity, TContext> where TEntity: class, IEntityBase where TContext : DbContext
{
    private readonly AppDbContext
    public Task<IEnumerable<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<T> CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}