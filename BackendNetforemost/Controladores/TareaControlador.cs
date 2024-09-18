using BackendNetforemost.Contexto;
using Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendNetforemost.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ManejadorDeTareas _context;

        public TareaController(ManejadorDeTareas contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            return await _context.Tareas.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Tarea>> GetTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
                return NotFound();

            return tarea;
        }

        [HttpPost]
        public async Task<ActionResult<Tarea>> CreateTarea(Tarea tarea)
        {
            tarea.Created_At = DateTime.Now;
            tarea.Updated_At = DateTime.Now;
            tarea.Finalizado = false;
            tarea.Eliminado = false;
            _context.Tareas.Add(tarea);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id)
                return BadRequest();

            tarea.Updated_At = DateTime.Now;
            _context.Entry(tarea).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
