namespace ToDo.Domain.Interfaces;

public interface IToDoRepository
{
    Task<Models.ToDo> GetByIdAsync(Guid id);
    Task<List<Models.ToDo>> GetAllAsync();
    Task<Models.ToDo> CreateAsync(Models.ToDo entity);
    Task UpdateAsync(Guid id, Models.ToDo entity);
    Task DeleteAsync(Guid id);
}