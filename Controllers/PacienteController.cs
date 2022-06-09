using Microsoft.AspNetCore.Mvc;
using CRUD_NetCore.Models.BD;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NETCore_CRUD.Controllers
{
    public class PacienteController : Controller
    {
        private readonly TurnosContext _context;

        public PacienteController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Paciente.ToListAsync());    
        }

        public async Task<IActionResult> Detalle(int? IdPaciente)
        {
            if (IdPaciente == null)
            {
                return NotFound();
            }

            var paciente = await _context.Paciente.FindAsync(IdPaciente);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }
    }
}