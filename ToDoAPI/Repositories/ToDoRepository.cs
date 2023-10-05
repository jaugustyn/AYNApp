using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Models.DTOs;

namespace ToDoAPI.Repositories;

public class ToDoRepository: IToDoRepository
{
    private readonly AppDbContext _context;
    
    public ToDoRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ToDo> GetByIdAsync(Guid id)
    {
        return await _context.ToDos.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<List<ToDo>> GetAllAsync()
    {
        return await _context.ToDos.ToListAsync();
    }
    
    public async Task<ToDo> CreateAsync(ToDo entity)
    {
        var newtodo = new ToDo
        {
            Id = new Guid(),
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            FinishDate = entity.FinishDate
        };
        await _context.ToDos.AddAsync(newtodo);
        await _context.SaveChangesAsync();
        
        return await GetByIdAsync(newtodo.Id);
    }

    public async Task UpdateAsync(Guid todoId, ToDo entity)
    {
        _context.ToDos.Update(entity);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        _context.ToDos.Remove(entity);
        await _context.SaveChangesAsync();
    }
}