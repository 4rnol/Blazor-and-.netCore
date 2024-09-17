using BackendNetforemost.Contexto;
using Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendNetforemost.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadController : ControllerBase
    {

        private readonly ManejadorDeTareas _context;

        public PrioridadController(ManejadorDeTareas contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prioridad>>> GetPrioridades()
        {
            return await _context.Prioridades.ToListAsync();
        }


    }
}
