using CalendarAPI.DTOs;
using CalendarAPI.Models;

namespace CalendarAPI.Services;

public interface ICalendarEventService
{
    Task<CalendarEventDto?> GetByIdAsync(Guid calendarId);
    Task<IQueryable<CalendarEventDto>> GetEventsByCalendarIdAsync(Guid userId);
    Task<CalendarEventDto> CreateEventAsync(Guid userId, ManipulationCalendarEntryDto eventDto);
    Task UpdateEventAsync(Guid eventId, ManipulationCalendarEntryDto eventDto);
    Task DeleteEventAsync(Guid calendarId);
}