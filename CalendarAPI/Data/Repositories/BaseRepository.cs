using System.Linq.Expressions;
using CalendarAPI.Data.Repositories.Interfaces;
using CalendarAPI.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace CalendarAPI.Data.Repositories;

public class BaseRepository<T>: IBaseRepository<T> where T : class, IEntityBase
{
    private readonly AppDbContext _context;

    protected BaseRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public Task<IQueryable<T>> FindAll(bool trackChanges)
    {
        return Task.FromResult(!trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>());
    }

    public Task<IQueryable<T>> FindAllByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return Task.FromResult(!trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression));
    }

    public async Task Create(T entity) => await _context.Set<T>().AddAsync(entity);

    public Task Update(T entity) => Task.FromResult(_context.Set<T>().Update(entity));

    public Task Delete(T entity) => Task.FromResult(_context.Set<T>().Remove(entity));
}