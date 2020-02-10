using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithDI.Models;

namespace WebApiWithDI.Repository
{
    public class EfTodoItemRepository : EfCoreRepository<TodoItemSqlServer, TodoContextSqlServer>
    {
        public EfTodoItemRepository(TodoContextSqlServer context) : base(context)
        {
        }
    }
}
