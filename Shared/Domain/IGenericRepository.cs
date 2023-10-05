using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Shared.Repositories;

public interface IGenericRepository<TEntity, TContext> where TEntity : class, IEntityBase where TContext : DbContext
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<T> CreateAsync(T entity);
    Task UpdateAsync(Guid id, T entity);
    Task DeleteAsync(Guid id);
}