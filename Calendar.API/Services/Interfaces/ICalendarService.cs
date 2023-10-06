using Calendar.Domain.DTOs;

namespace Calendar.API.Services.Interfaces;

public interface ICalendarService
{
    Task<CalendarDto?> GetByIdAsync(Guid calendarId);
    Task<IQueryable<CalendarDto>> GetMyCalendars(Guid userId);
    Task<CalendarDto> CreateCalendar(Guid userId, ManipulationCalendarDto calendarDto);
    Task UpdateCalendar(Guid calendarId, ManipulationCalendarDto calendarDto);
    Task DeleteCalendar(Guid calendarId);
}