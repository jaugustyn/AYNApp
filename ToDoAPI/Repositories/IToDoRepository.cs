using ToDoAPI.Models;
using ToDoAPI.Models.DTOs;

namespace ToDoAPI.Repositories;

public interface IToDoRepository
{
    Task<ToDo> GetByIdAsync(Guid id);
    Task<List<ToDo>> GetAllAsync();
    Task<ToDo> CreateAsync(ToDo entity);
    Task UpdateAsync(Guid id, ToDo entity);
    Task DeleteAsync(Guid id);
}