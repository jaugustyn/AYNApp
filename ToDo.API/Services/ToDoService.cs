using Microsoft.EntityFrameworkCore;
using Shared.Domain;
using Shared.Infrastructure;
using ToDo.Domain.DTOs;
using ToDo.Domain.Interfaces;
using ToDo.Infrastructure.Data;

namespace ToDo.API.Services;

public class ToDoService: IToDoService
{
    private readonly IToDoUnitOfWork _unitOfWork;
    private readonly IToDoRepository _toDoRepository;
    public ToDoService(IToDoUnitOfWork unitOfWork, IToDoRepository toDoRepository)
    {
        _unitOfWork = unitOfWork;
        _toDoRepository = toDoRepository;
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
        await _unitOfWork.CommitAsync();

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

        await _toDoRepository.UpdateAsync(todo);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAsync(Guid todoId)
    {
        var todo = await _toDoRepository.GetByIdAsync(todoId);
        await _toDoRepository.DeleteAsync(todo);
        await _unitOfWork.CommitAsync();
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