using Calendar.Domain.Models;

namespace Calendar.Domain.DTOs;

public class CalendarEventDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset FinishDate { get; set; }
    public bool Active { get; set; }
    
    public Guid UserId { get; set; }
    public Guid CalendarId { get; set; }
}

public class ManipulationCalendarEntryDto
{
    public string? Name { get; set; }
    public string? Notes { get; set; }
    public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset FinishDate { get; set; } = DateTimeOffset.Now.AddHours(1);
    public bool Active { get; set; } = true;
    
    public Guid CalendarId { get; set; }
}

public static class CalendarEventDtoMapper
{
    public static CalendarEventDto MapFromDomain(this CalendarEvent calendarEvent)
    {
        var item = new CalendarEventDto()
        {
            Id = calendarEvent.Id,
            Name = calendarEvent.Name,
            Notes = calendarEvent.Notes,
            StartDate = calendarEvent.StartDate,
            FinishDate = calendarEvent.FinishDate,
            Active = calendarEvent.Active,
            CalendarId = calendarEvent.CalendarId,
            UserId = calendarEvent.UserId,
        };
        return item;
    }
}