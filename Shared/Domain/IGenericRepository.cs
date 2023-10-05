using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Shared.Domain;

public interface IGenericRepository<TEntity> where TEntity : class, IEntityBase
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IQueryable<TEntity>> GetAllAsync(bool trackChanges);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}