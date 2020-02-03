using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithDI.Models;

namespace WebApiWithDI.Initializer
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = (TodoContext)serviceProvider.GetService(typeof(TodoContext)))
            {                
                if (_context.TodoItems.Any())
                {
                    return;
                }

                _context.TodoItems.AddRange(new List<TodoItem>
                {
                    new TodoItem {Id=1, FirstName="Lluis", IsComplete=true},
                    new TodoItem {Id=2, FirstName= "Josep", IsComplete=true},
                    new TodoItem {Id=3, FirstName= "Enric", IsComplete=true},
                    new TodoItem {Id=4, FirstName= "Ricard", IsComplete=true}
                });

                _context.SaveChangesAsync();
            }
        }
    }
}
