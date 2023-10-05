using System.ComponentModel.DataAnnotations;

namespace ToDoAPI.Models;

public class ToDoList
{
    
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
}