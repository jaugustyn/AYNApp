using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Shared.Domain;

public interface IGenericRepository<TEntity> where TEntity : class, IEntityBase
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}