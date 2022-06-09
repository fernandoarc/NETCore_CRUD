using Microsoft.AspNetCore.Mvc;
using CRUD_NetCore.Models.BD;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NETCore_CRUD.Models;

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

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//validar que los datos provengan desde el formulario y no desde la url del navegador
        public async Task<IActionResult> Crear([Bind("IdPaciente, Nombre, Apellido, Direccion, Telefono, Email")]Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Editar(int? IdPaciente)
        {
            if (IdPaciente == null)
            {
                return NotFound();
            }
            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.IdPaciente == IdPaciente);
            if (paciente == null)
            {
                return NotFound();
            }
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int? IdPaciente, [Bind("IdPaciente, Nombre, Apellido, Direccion, Telefono, Email")]Paciente paciente)
        {
            if (IdPaciente == null || IdPaciente != paciente.IdPaciente)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        public async Task<IActionResult> Eliminar(int? IdPaciente)
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

        [HttpPost, ActionName("Eliminar")]//aplica un alias para poder sobrecargar metodos
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmacion(int? IdPaciente)
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
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}