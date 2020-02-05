using Microsoft.EntityFrameworkCore;
using WebApiWithDI.Models;

namespace WebApiWithDI
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

       
    }
}
