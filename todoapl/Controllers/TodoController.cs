using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Models;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _context;
    public TodoController(AppDbContext context) { _context = context; }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos() 
    {
        return await _context.Todos.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<TodoItem>> CreateTodo([FromBody] TodoItem item)
    {
        if (item == null) return BadRequest();
        _context.Todos.Add(item);
        await _context.SaveChangesAsync();
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var item = await _context.Todos.FindAsync(id);
        if (item == null) return NotFound();
        _context.Todos.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}