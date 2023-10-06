using ToDo.Domain.Interfaces;
using ToDo.Domain.Models.DTOs;

namespace ToDo.API.Services;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _toDoRepository;

    public ToDoService(IToDoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }

    //Users not implemented yet
    public async Task<IEnumerable<ToDoDto>> GetAllByUserIdAsync(Guid userId)
    {
        var todos = await _toDoRepository.GetAllAsync();
        // var userTodos = todos.Where(x => x.UserId.Equals(userId)).Select(ToDoDto.TodoToDto)
        //     .OrderByDescending(x => x.StartDate).ToList();
        var todoslist = todos.Select(ToDoDto.TodoToDto).OrderBy(x => x.StartDate).ToList();

        return todoslist;
    }

    public async Task<IEnumerable<ToDoDto>> GetAllAsync()
    {
        var todos = await _toDoRepository.GetAllAsync();
        var todosDto = todos.Select(ToDoDto.TodoToDto);

        return todosDto;
    }

    public async Task<ToDoDto> GetByIdAsync(Guid toDoId)
    {
        var todo = await _toDoRepository.GetByIdAsync(toDoId);
        return todo is null ? null : ToDoDto.TodoToDto(todo);
    }

    public async Task<ToDoDto> CreateAsync(Guid userId, ToDoManipulationDto entity)
    {
        var todo = new Domain.Models.ToDo()
        {
            Id = Guid.NewGuid(),
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            FinishDate = entity.FinishDate
        };

        var newTodo = await _toDoRepository.CreateAsync(todo);

        return ToDoDto.TodoToDto(newTodo);
    }

    public async Task UpdateAsync(Guid todoId, ToDoManipulationDto entity)
    {
        var oldTodo = await GetByIdAsync(todoId);

        var todo = new Domain.Models.ToDo
        {
            Id = oldTodo.Id,
            Title = entity.Title,
            Description = entity.Description,
            StartDate = entity.StartDate,
            FinishDate = entity.FinishDate
        };

        await _toDoRepository.UpdateAsync(todoId, todo);
    }

    public async Task DeleteAsync(Guid toDoId)
    {
        await _toDoRepository.DeleteAsync(toDoId);
    }

    public async Task<IEnumerable<ToDoDto>> SearchAsync(string keyPhrase)
    {
        var todos = await GetAllAsync();
        IQueryable<ToDoDto>? query = null;

        if (!string.IsNullOrWhiteSpace(keyPhrase))
        {
            keyPhrase = keyPhrase.ToLower();
            query = todos.AsQueryable().Where(x => x.Title.ToLower().Contains(keyPhrase)).OrderBy(x => x.StartDate);
        }

        return query;
    }
}