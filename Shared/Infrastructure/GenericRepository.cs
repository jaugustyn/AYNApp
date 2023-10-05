using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Entities;

namespace Shared.Infrastructure;

public class GenericRepository<TEntity, TContext>: IGenericRepository<TEntity> where TEntity: class, IEntityBase where TContext : DbContext
{
    private readonly DbFactory<TContext> _dbFactory;
    protected DbSet<TEntity> _dbSet;

    protected DbSet<TEntity> DbSet
    {
        get => _dbSet ??= _dbFactory.Context.Set<TEntity>();
    }
    public Task<IEnumerable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> CreateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}