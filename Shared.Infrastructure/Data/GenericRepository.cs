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
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await DbSet.Where(expression).ToListAsync();
    }

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        var result = await DbSet.AddAsync(entity);
        return result.Entity;
    }

    public void Update(TEntity entity) => DbSet.Update(entity);

    public void Delete(TEntity entity) => DbSet.Remove(entity);
}