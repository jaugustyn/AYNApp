using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Entities;

namespace Shared.Infrastructure;

public abstract class GenericRepository<TEntity, TContext>: IGenericRepository<TEntity> where TEntity: class, IEntityBase where TContext : DbContext
{
    private readonly DbFactory<TContext> _dbFactory;
    private DbSet<TEntity> DbSet { get; }

    public GenericRepository(DbFactory<TContext> dbFactory, DbSet<TEntity> dbSet)
    {
        _dbFactory = dbFactory;
        DbSet = _dbFactory.Context.Set<TEntity>();
    }
    
    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public Task<IQueryable<TEntity>> GetAllAsync(bool trackChanges = false)
    {
        return Task.FromResult(!trackChanges ? DbSet.AsNoTracking() : DbSet);
    }

    public Task<IQueryable<TEntity>> GetAllByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges = false)
    {
        return Task.FromResult(!trackChanges ? DbSet.Where(expression).AsNoTracking() : DbSet.Where(expression));
    }

    public Task CreateAsync(TEntity entity) => Task.FromResult(DbSet.AddAsync(entity));

    public Task UpdateAsync(TEntity entity) => Task.FromResult(DbSet.Update(entity));

    public Task DeleteAsync(TEntity entity) => Task.FromResult(DbSet.Remove(entity));
}