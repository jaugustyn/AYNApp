using ToDo.Domain.DTOs;
using ToDo.Domain.Interfaces;

namespace ToDo.API.Services;

public class ToDoListService
{
    private readonly IToDoUnitOfWork _unitOfWork;
    private readonly IToDoListRepository _todoListRepository;
    
    public ToDoListService(IToDoUnitOfWork unitOfWork, IToDoListRepository todoListRepository)
    {
        _unitOfWork = unitOfWork;
        _todoListRepository = todoListRepository;
    }

    public async Task<IEnumerable<ToDoListDto>> GetAllAsync()
    {
        var lists = await _todoListRepository.GetAllAsync();
        var listsDto = lists.Select(ToDoListDto.TodoListToDto);

        return listsDto;
    }

    public async Task<ToDoListDto> GetByIdAsync(Guid toDoId)
    {
        var list = await _todoListRepository.GetByIdAsync(toDoId);
        return list is null ? null : ToDoListDto.TodoListToDto(list);
    }

    public async Task<ToDoListDto> CreateAsync(Guid userId, ToDoListManipulationDto entity)
    {
        var list = new Domain.Models.ToDoList()
        {
            Id = Guid.NewGuid(),
            Title = entity.Title,
        };

        var newList = await _todoListRepository.CreateAsync(list);
        await _unitOfWork.CommitAsync();

        return ToDoListDto.TodoListToDto(newList);
    }

    public async Task UpdateAsync(Guid todoId, ToDoListManipulationDto entity)
    {
        var oldList = await GetByIdAsync(todoId);

        var list = new Domain.Models.ToDoList
        {
            Id = oldList.Id,
            Title = entity.Title,
        };

        await _todoListRepository.UpdateAsync(list);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAsync(Guid todoId)
    {
        var list = await _todoListRepository.GetByIdAsync(todoId);
        await _todoListRepository.DeleteAsync(list);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<ToDoListDto>> SearchAsync(string keyPhrase)
    {
        var lists = await GetAllAsync();
        IQueryable<ToDoListDto>? query = null;

        if (!string.IsNullOrWhiteSpace(keyPhrase))
        {
            keyPhrase = keyPhrase.ToLower();
            query = lists.AsQueryable().Where(x => x.Title.ToLower().Contains(keyPhrase)).OrderBy(x => x.Title);
        }

        return query;
    }
}