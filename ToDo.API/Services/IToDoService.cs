using ToDo.Domain.Models.DTOs;

namespace ToDo.API.Services;

public interface IToDoService
{
    Task<IEnumerable<ToDoDto>> GetAllAsync();
    Task<ToDoDto> GetByIdAsync(Guid todoId);
    Task<ToDoDto> CreateAsync(Guid userId, ToDoManipulationDto entity);
    Task UpdateAsync(Guid todoId, ToDoManipulationDto entity);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<ToDoDto>> SearchAsync(string keyPhrase);
}