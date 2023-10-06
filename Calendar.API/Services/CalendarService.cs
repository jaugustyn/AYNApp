using Calendar.API.Services.Interfaces;
using Calendar.Domain.DTOs;
using Calendar.Domain.Interfaces;

namespace Calendar.API.Services;

public class CalendarService: ICalendarService
{
    private readonly ICalendarRepository _calendarRepository;
    
    public CalendarService(ICalendarRepository calendarRepository)
    {
        _calendarRepository = calendarRepository;
    }

    public async Task<CalendarDto?> GetByIdAsync(Guid calendarId)
    {
        var item = await _calendarRepository.GetByIdAsync(calendarId);
        return item?.MapFromDomain();
    }

    public async Task<IQueryable<CalendarDto>> GetMyCalendars(Guid userId)
    {
        var items = await _calendarRepository.FindAllByCondition(x => x.UserId.Equals(userId), trackChanges: false);
        return items.AsEnumerable().Select(CalendarDtoMapper.MapFromDomain).AsQueryable();
    }

    public async Task<CalendarDto> CreateCalendar(Guid userId, ManipulationCalendarDto calendarDto)
    {
        var item = new Domain.Models.Calendar()
        {
            Id = new Guid(),
            Name = calendarDto.Name,
            Description = calendarDto.Description,
            UserId = userId,
        };
        
        await _calendarRepository.Create(item);
        var newEvent = await _calendarRepository.GetByIdAsync(item.Id);
        
        return newEvent.MapFromDomain();
    }

    public async Task UpdateCalendar(Guid userId, ManipulationCalendarDto calendarDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCalendar(Guid calendarId)
    {
        throw new NotImplementedException();
    }
}