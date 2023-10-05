using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Shared.Domain;

public interface IGenericRepository<TEntity> where TEntity : class, IEntityBase
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
    Task<TEntity> CreateAsync(TEntity entity);
    Task UpdateAsync(Guid id, TEntity entity);
    Task DeleteAsync(Guid id);
}