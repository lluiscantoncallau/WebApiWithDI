using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiWithDI;
using WebApiWithDI.Models;

namespace WebApiWithDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemSqlServersController : ControllerBase
    {
        private readonly TodoContextSqlServer _context;

        public TodoItemSqlServersController(TodoContextSqlServer context)
        {
            _context = context;
        }

        // GET: api/TodoItemSqlServers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemSqlServer>>> GetTodoItemSqlServer()
        {
            return await _context.TodoItemSqlServer.ToListAsync().ConfigureAwait(false);
        }

        // GET: api/TodoItemSqlServers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemSqlServer>> GetTodoItemSqlServer(long id)
        {
            var todoItemSqlServer = await _context.TodoItemSqlServer.FindAsync(id);

            if (todoItemSqlServer == null)
            {
                return NotFound();
            }

            return todoItemSqlServer;
        }

        // PUT: api/TodoItemSqlServers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItemSqlServer(long id, TodoItemSqlServer todoItemSqlServer)
        {
            if (id != todoItemSqlServer.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItemSqlServer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemSqlServerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItemSqlServers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TodoItemSqlServer>> PostTodoItemSqlServer(TodoItemSqlServer todoItemSqlServer)
        {
            if(todoItemSqlServer == null) { return BadRequest(); }
            _context.TodoItemSqlServer.Add(todoItemSqlServer);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return CreatedAtAction("GetTodoItemSqlServer", new { id = todoItemSqlServer.Id }, todoItemSqlServer);
        }

        // DELETE: api/TodoItemSqlServers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemSqlServer>> DeleteTodoItemSqlServer(long id)
        {
            var todoItemSqlServer = await _context.TodoItemSqlServer.FindAsync(id);
            if (todoItemSqlServer == null)
            {
                return NotFound();
            }

            _context.TodoItemSqlServer.Remove(todoItemSqlServer);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return todoItemSqlServer;
        }

        private bool TodoItemSqlServerExists(long id)
        {
            return _context.TodoItemSqlServer.Any(e => e.Id == id);
        }
    }
}
