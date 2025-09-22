using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoCrud.Api.Models;

namespace ToDoCrud.Api.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(TodoDbContext db)
        {
            // Already has data? Nothing to do.
            if (await db.Todos.AnyAsync()) return;

            db.Todos.AddRange(
                new TodoItem { Title = "Buy milk", IsDone = false },
                new TodoItem { Title = "Learn EF Core", IsDone = false },
                new TodoItem { Title = "Ship portfolio update", IsDone = true }
            );

            await db.SaveChangesAsync();
        }
    }
}
