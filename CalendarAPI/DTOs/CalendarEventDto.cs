namespace CalendarAPI.DTOs;

public class CalendarEntryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public TimeSpan Duration  { get; set; }
    public bool Active { get; set; }
    public bool IsDone { get; set; }
    
    public Guid UserId { get; set; }
    public Guid CalendarId { get; set; }
}

public class ManipulationCalendarEntryDto
{
    public string? Name { get; set; }
    public string? Notes { get; set; }
    public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;
    public TimeSpan Duration { get; set; } = TimeSpan.FromHours(1);
    public bool Active { get; set; } = true;
    
    public Guid CalendarId { get; set; }
}