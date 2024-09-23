using backend_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly DbangularContext _context;

        public TareaController(DbangularContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var listaTareas = await _context.Tareas.ToListAsync();
            return Ok(listaTareas);
        }
        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody] Tarea request)
        {
            await _context.Tareas.AddAsync(request);
            await _context.SaveChangesAsync();
            return Ok(request);
        }
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminar = await _context.Tareas.FindAsync(id);

            if (eliminar == null)
            {
                return BadRequest("No existe la tarea");
            }
            _context.Tareas.Remove(eliminar);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
