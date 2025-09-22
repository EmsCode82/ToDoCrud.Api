using Microsoft.EntityFrameworkCore;
using ToDoCrud.Api.Models;

namespace ToDoCrud.Api.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<TodoItem> Todos => Set<TodoItem>();
    }
}
