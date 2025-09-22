using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ToDoCrud.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        // In-memory store for now (will swap to EF Core later)
        private static readonly List<TodoDto> _items = new()
        {
            new TodoDto { Id = 1, Title = "First task", IsDone = false }
        };

        [HttpGet]
        public ActionResult<IEnumerable<TodoDto>> Get() => Ok(_items);

        [HttpGet("{id:int}")]
        public ActionResult<TodoDto> GetById(int id)
            => _items.FirstOrDefault(t => t.Id == id) is { } item ? Ok(item) : NotFound();

        [HttpPost]
        public ActionResult<TodoDto> Create([FromBody] TodoCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title)) return BadRequest("Title is required.");
            var id = _items.Count == 0 ? 1 : _items.Max(t => t.Id) + 1;
            var item = new TodoDto { Id = id, Title = dto.Title, IsDone = false };
            _items.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] TodoUpdateDto dto)
        {
            var item = _items.FirstOrDefault(t => t.Id == id);
            if (item is null) return NotFound();
            item.Title = dto.Title;
            item.IsDone = dto.IsDone;
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(t => t.Id == id);
            if (item is null) return NotFound();
            _items.Remove(item);
            return NoContent();
        }
    }

    // DTOs (keep in this file for now)
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
