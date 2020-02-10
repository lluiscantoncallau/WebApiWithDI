using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiWithDI;
using WebApiWithDI.Models;
using WebApiWithDI.Repository;

namespace WebApiWithDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemSqlServersController : ControllerBase
    {
        private readonly EfTodoItemRepository _repository;

        public TodoItemSqlServersController(EfTodoItemRepository repository)
        {
            _repository = repository;
        }

        // GET: api/TodoItemSqlServers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemSqlServer>>> GetTodoItemSqlServer() => await _repository.GetAll().ConfigureAwait(false);

        // GET: api/TodoItemSqlServers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemSqlServer>> GetTodoItemSqlServer(long id)
        {

            var todoItemSqlServer = await _repository.Get(id).ConfigureAwait(false);

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
            if (todoItemSqlServer != null && id != todoItemSqlServer.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.Update(todoItemSqlServer).ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/TodoItemSqlServers
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TodoItemSqlServer>> PostTodoItemSqlServer(TodoItemSqlServer todoItemSqlServer)
        {
            if (todoItemSqlServer == null) { return BadRequest(); }
            await _repository.Add(todoItemSqlServer).ConfigureAwait(false);
            return CreatedAtAction("GetTodoItemSqlServer", new { id = todoItemSqlServer.Id }, todoItemSqlServer);
        }

        // DELETE: api/TodoItemSqlServers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItemSqlServer>> DeleteTodoItemSqlServer(long id)
        {
            var todoItemSqlServer = await _repository.Delete(id).ConfigureAwait(false);
            if (todoItemSqlServer == null)
            {
                return NotFound();
            }

            return todoItemSqlServer;
        }
    }
}
