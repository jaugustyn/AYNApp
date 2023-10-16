using Shared.Domain.Interfaces;

namespace Calendar.Domain.Models;

public class Calendar: IEntityBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public Guid UserId { get; set; }
    // public User User { get; set; }
}