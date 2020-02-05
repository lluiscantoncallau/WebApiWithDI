using System;
using System.Collections.Generic;
using System.Linq;
using WebApiWithDI.Models;

namespace WebApiWithDI.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = (TodoContext)serviceProvider.GetService(typeof(TodoContext)))
            {
                _context.Database.EnsureCreated();

                if (_context.TodoItems.Any())
                {
                    return;
                }

                _context.TodoItems.AddRange(new List<TodoItem>
                {
                    new TodoItem {Id=1, FirstName="Lluis InMemory", IsComplete=true},
                    new TodoItem {Id=2, FirstName= "Josep  InMemory", IsComplete=true},
                    new TodoItem {Id=3, FirstName= "Enric  InMemory", IsComplete=true},
                    new TodoItem {Id=4, FirstName= "Ricard  InMemory", IsComplete=true}
                });

                _context.SaveChangesAsync();
            }
        }
    }
}