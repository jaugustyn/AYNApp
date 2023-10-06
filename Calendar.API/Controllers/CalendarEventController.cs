using Calendar.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calendar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarEventController : ControllerBase
    {
        private readonly ICalendarEventService _calendarEventService;
        
        public CalendarEventController(ICalendarEventService calendarEventService)
        {
            _calendarEventService = calendarEventService;
        }
    }
}
