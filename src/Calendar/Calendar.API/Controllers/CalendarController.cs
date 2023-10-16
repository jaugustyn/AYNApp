using System.Security.Claims;
using Calendar.API.Services.Interfaces;
using Calendar.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly ICalendarService _calendarService;
        
        public CalendarController(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        [HttpGet("GetMyCalendars")]
        public async Task<ActionResult<IQueryable<Domain.Models.Calendar>>> GetMyCalendars()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var calendars = await _calendarService.GetMyCalendars(userId);
            if (calendars is null) return NotFound();

            return Ok(calendars);
        }
        
        [HttpPost]
        public async Task<ActionResult<Domain.Models.Calendar>> PostCalendar(ManipulationCalendarDto calendarDto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            await _calendarService.CreateCalendar(userId, calendarDto);

            return CreatedAtAction(nameof(GetMyCalendars), calendarDto); // check it
        }

        [HttpPut("{calendarId:guid}")]
        public async Task<IActionResult> PutCalendar(Guid calendarId, ManipulationCalendarDto calendarDto)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = User.FindFirstValue(ClaimTypes.Role);

            var calendar = await _calendarService.GetByIdAsync(calendarId);

            if (calendar == null) return NotFound();
            if (!calendar.UserId.Equals(userId) && role != "Administrator")
                return Unauthorized(new {error_message = "The calendar does not belong to this user"});

            await _calendarService.UpdateCalendar(calendarId, calendarDto);

            return NoContent();
        }

        [HttpDelete("{calendarId:guid}")]
        public async Task<IActionResult> DeleteCalendar(Guid calendarId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var role = User.FindFirstValue(ClaimTypes.Role);

            var calendar = await _calendarService.GetByIdAsync(calendarId);

            if (calendar == null) return NotFound();
            if (!calendar.UserId.Equals(userId) && role != "Administrator")
                return Unauthorized(new {error_message = "The calendar does not belong to this user"});

            await _calendarService.DeleteCalendar(calendarId);

            return NoContent();
        }
    }
}
