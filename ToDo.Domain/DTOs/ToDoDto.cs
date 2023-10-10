using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.DTOs;

public class ToDoDto : ToDoManipulationDto
{
    [Key] public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? FinishDate { get; set; }

    public Guid ToDoListId { get; set; }

    public static ToDoDto TodoToDto(Models.ToDo toDo)
    {
        return new ToDoDto()
        {
            Id = toDo.Id,
            Description = toDo.Description,
            Title = toDo.Title,
            FinishDate = toDo.FinishDate,
            StartDate = toDo.StartDate,
            ToDoListId = toDo.ToDoListId,
        };
    }
}