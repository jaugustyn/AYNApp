using CalendarAPI.Data.Repositories.Interfaces;
using CalendarAPI.DTOs;
using CalendarAPI.Models;

namespace CalendarAPI.Services;

public class CalendarEventService: ICalendarEventService
{
    private readonly ICalendarEventRepository _calendarEventRepository;
    public CalendarEventService(ICalendarEventRepository calendarEventRepository)
    {
        _calendarEventRepository = calendarEventRepository;
    }

    public async Task<CalendarEventDto?> GetByIdAsync(Guid calendarEventId)
    {
        var item = await _calendarEventRepository.GetByIdAsync(calendarEventId);
        return item?.MapFromDomain();
    }

    public async Task<IQueryable<CalendarEventDto>> GetEventsByCalendarIdAsync(Guid calendarId)
    {
        var items = await _calendarEventRepository.FindAllByCondition(x => x.CalendarId.Equals(calendarId), trackChanges: false);
        return items.AsEnumerable().Select(CalendarEventDtoMapper.MapFromDomain).AsQueryable().OrderBy(x => x.StartDate);
    }

    public async Task<CalendarEventDto> CreateEventAsync(Guid userId, ManipulationCalendarEntryDto eventDto)
    {
        var item = new CalendarEvent()
        {
            Id = new Guid(),
            Active = true,
            Name = eventDto.Name,
            Notes = eventDto.Notes,
            StartDate = eventDto.StartDate,
            FinishDate = eventDto.FinishDate,
            CalendarId = eventDto.CalendarId,
            UserId = userId,
        };
        
        await _calendarEventRepository.Create(item);
        var newEvent = await _calendarEventRepository.GetByIdAsync(item.Id);
        
        return newEvent.MapFromDomain();
    }

    public async Task UpdateEventAsync(Guid eventId, ManipulationCalendarEntryDto eventDto)
    {
        var oldEvent = await _calendarEventRepository.GetByIdAsync(eventId);
        
        var item = new CalendarEvent()
        {
            Id = oldEvent.Id,
            UserId = oldEvent.UserId,
            Active = eventDto.Active,
            Name = eventDto.Name,
            Notes = eventDto.Notes,
            StartDate = eventDto.StartDate,
            FinishDate = eventDto.FinishDate,
            CalendarId = eventDto.CalendarId,
        };
        
        await _calendarEventRepository.Update(item);
    }

    public async Task DeleteEventAsync(Guid eventId)
    {
        var item = await _calendarEventRepository.GetByIdAsync(eventId);
        await _calendarEventRepository.Delete(item);
    }
}