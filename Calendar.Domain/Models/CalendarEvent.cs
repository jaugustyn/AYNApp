using Shared.Entities;

namespace Calendar.Domain.Models;

public class CalendarEvent : IEntityBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset FinishDate { get; set; }
    public bool Active { get; set; }
    
    public Guid UserId { get; set; }
    // public User User { get; set; }
    
    public Guid CalendarId { get; set; }
    public Calendar Calendar { get; set; }
    
    // Repeat
}