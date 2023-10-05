using CalendarAPI.Data.Repositories.Interfaces;
using CalendarAPI.Models;

namespace CalendarAPI.Data.Repositories;

public class CalendarEventRepository: BaseRepository<CalendarEvent>, ICalendarEntryRepository
{
    public CalendarEventRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public Task<IQueryable<CalendarEvent>> GetAllByCalendarId(Guid calendarId)
    {
        return FindAllByCondition(x => x.CalendarId.Equals(calendarId), trackChanges: false);
    }
}