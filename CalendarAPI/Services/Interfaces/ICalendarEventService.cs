using CalendarAPI.DTOs;
using CalendarAPI.Models;

namespace CalendarAPI.Services;

public interface ICalendarEventService
{
    Task<CalendarEvent> GetByIdAsync(Guid calendarId);
    Task<IQueryable<CalendarEvent>> GetEventsByCalendarIdAsync(Guid userId);
    Task<CalendarEvent> CreateEventAsync(Guid userId, ManipulationCalendarEntryDto eventDto);
    Task UpdateEventAsync(Guid userId, ManipulationCalendarEntryDto eventDto);
    Task DeleteEventAsync(Guid calendarId);
}