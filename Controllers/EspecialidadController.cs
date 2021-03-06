using NETCore_CRUD.Models;
using System.Linq;
using NETCore_CRUD.Models.BD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NETCore_CRUD.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Especialidad.ToListAsync());
        }

        public async Task<IActionResult> Editar(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var especialidad = await _context.Especialidad.Where(e => e.IdEspecialidad == Id).FirstOrDefaultAsync();
            if(especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int? id, [Bind("IdEspecialidad,Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        public async Task<IActionResult> Eliminar (int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var especialidad = await _context.Especialidad.FindAsync(Id);
            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var especialidad = await _context.Especialidad.Where(e => e.IdEspecialidad == Id).FirstOrDefaultAsync();
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear([Bind("IdEspecialidad, Descripcion")] Especialidad especialidad)
        {
            if(ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}