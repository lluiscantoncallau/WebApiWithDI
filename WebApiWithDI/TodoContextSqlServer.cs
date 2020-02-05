using Microsoft.EntityFrameworkCore;
using WebApiWithDI.Models;

namespace WebApiWithDI
{
    public class TodoContextSqlServer : DbContext
    {
        public TodoContextSqlServer(DbContextOptions<TodoContextSqlServer> options):base(options)
        { }

        public DbSet<TodoItemSqlServer> TodoItemSqlServer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItemSqlServer>().HasData(
                    new TodoItemSqlServer { Id = 1, FirstName = "Lluis", IsComplete = true },
                    new TodoItemSqlServer { Id = 2, FirstName = "Josep", IsComplete = true },
                    new TodoItemSqlServer { Id = 3, FirstName = "Enric", IsComplete = true },
                    new TodoItemSqlServer { Id = 4, FirstName = "Ricard", IsComplete = true }
                    );
        }
    }
}
