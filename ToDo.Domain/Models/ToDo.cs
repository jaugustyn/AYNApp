using System.ComponentModel.DataAnnotations;
using Shared.Domain.Interfaces;

namespace ToDo.Domain.Models;

public class ToDo : IEntityBase
{
    [Key] public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTimeOffset? StartDate { get; set; }
    public DateTimeOffset? FinishDate { get; set; }


    // public Guid ToDoListId { get; set; }
    // public ToDoList ToDoList { get; set; }
}