using System.ComponentModel.DataAnnotations;
using Shared.Entities;

namespace ToDoAPI.Models;

public class ToDoList: IEntityBase
{
    
    [Key]
    public Guid Id { get; set; }
    public string Title { get; set; }
}