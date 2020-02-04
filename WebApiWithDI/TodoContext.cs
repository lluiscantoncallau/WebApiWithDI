using Microsoft.EntityFrameworkCore;
using WebApiWithDI.Models;

namespace WebApiWithDI
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate(); //i have tried this too 
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TodoItem>()
                .HasKey(x => x.Id);

        }
    }
}
