namespace ToDoAPI.Models;

public class ToDoList: IEntityBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}