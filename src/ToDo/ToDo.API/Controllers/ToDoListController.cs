using Microsoft.AspNetCore.Mvc;
using ToDo.API.Services;
using ToDo.Domain.DTOs;

namespace ToDo.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ToDoListController: ControllerBase
{
    private readonly ToDoListService _todoListService;

    public ToDoListController(ToDoListService todoListListService)
    {
        _todoListService = todoListListService;
    }

    [HttpGet("{listId:guid}")]
    public async Task<ActionResult<ToDoListDto>> GetTodoList(Guid listId)
    {
        var list = await _todoListService.GetByIdAsync(listId);
        if (list is null) return NotFound();
        return Ok(list);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoListDto>>> GetAllTodoLists()
    {
        return Ok(await _todoListService.GetAllAsync());
    }

    [HttpPost]
    public async Task<ActionResult<ToDoListDto>> PostTodoList(ToDoListManipulationDto listManipulationDto)
    {
        // var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var list = await _todoListService.CreateAsync(new Guid(), listManipulationDto);
        return CreatedAtAction(nameof(GetTodoList), new {listId = list.Id}, list);
    }

    [HttpPut("{listId:guid}")]
    public async Task<IActionResult> PutTodoList(Guid listId, ToDoListManipulationDto listManipulationDto)
    {
        // var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        // var role = User.FindFirstValue(ClaimTypes.Role);

        var list = await _todoListService.GetByIdAsync(listId);

        if (list is null) return NotFound();

        // if (!todo.UserId.Equals(userId) && role != "Administrator")
        //     return Unauthorized(new {error_message = "The list does not belong to this user"});

        await _todoListService.UpdateAsync(listId, listManipulationDto);

        return CreatedAtAction(nameof(GetTodoList), new {listId = list.Id}, listManipulationDto);
    }

    [HttpDelete("{listId:guid}")]
    public async Task<ActionResult<IEnumerable<ToDoListDto>>> DeleteTodoList(Guid listId)
    {
        // var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        // var role = User.FindFirstValue(ClaimTypes.Role);

        var list = await _todoListService.GetByIdAsync(listId);

        if (list is null) return NotFound();
        // if (!todo.UserId.Equals(userId) && role != "Administrator")
        //     return Unauthorized(new {error_message = "The list does not belong to this user"});

        await _todoListService.DeleteAsync(listId);

        return NoContent();
    }
}