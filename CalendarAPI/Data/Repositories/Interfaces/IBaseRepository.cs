using System.Linq.Expressions;

namespace CalendarAPI.Data.Repositories;

public interface IBaseRepository<T>
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IQueryable<T>> FindAll(bool trackChanges);
    Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
    Task Create(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}