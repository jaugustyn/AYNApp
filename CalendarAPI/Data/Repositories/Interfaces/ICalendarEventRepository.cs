using CalendarAPI.Models;

namespace CalendarAPI.Data.Repositories.Interfaces;

public interface ICalendarEventRepository
{
    Task<IQueryable<CalendarEvent>> GetAllByCalendarId(Guid calendarId);
}