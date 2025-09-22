using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoCrud.Api.Data;
using ToDoCrud.Api.Models;

namespace ToDoCrud.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly TodoDbContext _db;
        public TodosController(TodoDbContext db) => _db = db;

        // GET: /api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoDto>>> Get()
        {
            var items = await _db.Todos
                .AsNoTracking()
                .Select(t => new TodoDto { Id = t.Id, Title = t.Title, IsDone = t.IsDone })
                .ToListAsync();

            return Ok(items);
        }

        // GET: /api/todos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<TodoDto>> GetById(int id)
        {
            var t = await _db.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (t is null) return NotFound();

            return Ok(new TodoDto { Id = t.Id, Title = t.Title, IsDone = t.IsDone });
        }

        // POST: /api/todos
        [HttpPost]
        public async Task<ActionResult<TodoDto>> Create([FromBody] TodoCreateDto dto)
        {
            if (dto is null || string.IsNullOrWhiteSpace(dto.Title))
                return BadRequest("Title is required.");

            var entity = new TodoItem { Title = dto.Title, IsDone = false };
            await _db.Todos.AddAsync(entity);
            await _db.SaveChangesAsync();

            var result = new TodoDto { Id = entity.Id, Title = entity.Title, IsDone = entity.IsDone };
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, result);
        }

        // PUT: /api/todos/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TodoUpdateDto dto)
        {
            var entity = await _db.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return NotFound();

            entity.Title = dto.Title;
            entity.IsDone = dto.IsDone;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: /api/todos/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.Todos.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return NotFound();

            _db.Todos.Remove(entity);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }

    // DTOs (kept local for now)
    public record TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public bool IsDone { get; set; }
    }

    public record TodoCreateDto
    {
        public string Title { get; set; } = "";
    }

    public record TodoUpdateDto
    {
        public string Title { get; set; } = "";
        public bool IsDone { get; set; }
    }
}
