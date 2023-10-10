namespace ToDo.Domain.DTOs;

public class ToDoManipulationDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? FinishDate { get; set; }
    public Guid ToDoListId { get; set; }
}