using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.DTOs;

public class ToDoListDto
{
    [Key] 
    public Guid Id { get; set; }
    public string Title { get; set; }

    public static ToDoListDto TodoListToDto(Models.ToDoList todoList)
    {
        return new ToDoListDto()
        {
            Id = todoList.Id,
            Title = todoList.Title,
        };
    }
}