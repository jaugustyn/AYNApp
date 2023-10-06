using Microsoft.AspNetCore.Mvc;
using ToDo.API.Services;
using ToDo.Domain.Models.DTOs;

namespace ToDo.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _todoService;

    public ToDoController(IToDoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet("{toDoId:guid}")]
    public async Task<ActionResult<ToDoDto>> GetToDo(Guid toDoId)
    {
        var todo = await _todoService.GetByIdAsync(toDoId);
        if (todo is null) return NotFound();
        return Ok(todo);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoDto>>> GetAllToDos()
    {
        return Ok(await _todoService.GetAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult<ToDoDto>> PostToDo(ToDoManipulationDto toDoManipulationDto)
    {
        // var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var todo = await _todoService.CreateAsync(new Guid(), toDoManipulationDto);
        return CreatedAtAction(nameof(GetToDo), new {toDoId = todo.Id}, todo);
    }

    [HttpPut("{toDoId:guid}")]
    public async Task<IActionResult> PutToDo(Guid toDoId, ToDoManipulationDto toDoManipulationDto)
    {
        // var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        // var role = User.FindFirstValue(ClaimTypes.Role);

        var todo = await _todoService.GetByIdAsync(toDoId);

        if (todo is null) return NotFound();

        // if (!todo.UserId.Equals(userId) && role != "Administrator")
        //     return Unauthorized(new {error_message = "The todo does not belong to this user"});

        await _todoService.UpdateAsync(toDoId, toDoManipulationDto);

        return CreatedAtAction(nameof(GetToDo), new {toDoId = todo.Id}, toDoManipulationDto);
    }

    [HttpDelete("{toDoId:guid}")]
    public async Task<ActionResult<IEnumerable<ToDoDto>>> DeleteToDo(Guid toDoId)
    {
        // var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        // var role = User.FindFirstValue(ClaimTypes.Role);

        var todo = await _todoService.GetByIdAsync(toDoId);

        if (todo is null) return NotFound();
        // if (!todo.UserId.Equals(userId) && role != "Administrator")
        //     return Unauthorized(new {error_message = "The todo does not belong to this user"});

        await _todoService.DeleteAsync(toDoId);

        return NoContent();
    }
}