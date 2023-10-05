using CalendarAPI.Models;

namespace CalendarAPI.DTOs;

public class CalendarDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid UserId { get; set; }
}

public class ManipulationCalendarDto
{
    
    public string Name { get; set; }
    public string Description { get; set; }
}

public static class CalendarDtoMapper
{
    public static CalendarDto MapFromDomain(this Calendar calendar)
    {
        var item = new CalendarDto()
        {
            Id = calendar.Id,
            Description = calendar.Description,
            Name = calendar.Name,
            UserId = calendar.UserId,
        };
        return item;
    }
}
