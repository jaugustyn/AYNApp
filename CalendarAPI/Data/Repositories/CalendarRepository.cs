using CalendarAPI.Data.Repositories.Interfaces;
using CalendarAPI.Models;

namespace CalendarAPI.Data.Repositories;

public class CalendarRepository: BaseRepository<Calendar>, ICalendarRepository
{
    public CalendarRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}