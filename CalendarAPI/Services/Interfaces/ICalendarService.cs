using CalendarAPI.DTOs;
using CalendarAPI.Models;

namespace CalendarAPI.Services;

public interface ICalendarService
{
    Task<Calendar> GetByIdAsync(Guid calendarId);
    Task<IQueryable<Calendar>> GetMyCalendars(Guid userId);
    Task CreateCalendar(Guid userId, ManipulationCalendarDto calendarDto);
    Task UpdateCalendar(Guid userId, ManipulationCalendarDto calendarDto);
    Task DeleteCalendar(Guid calendarId);
}