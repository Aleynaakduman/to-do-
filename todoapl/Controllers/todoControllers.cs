using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo;

namespace todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ToDocontext _context;

        public TodoController(ToDocontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            return Ok(await _context.ToDos.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(ToDo todo)
        {
            _context.ToDos.Add(todo);
            await _context.SaveChangesAsync();
            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(string id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return NotFound();

            todo.StatusId = "completed";
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo == null)
                return NotFound();

            _context.ToDos.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}