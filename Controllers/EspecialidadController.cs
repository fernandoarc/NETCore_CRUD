using CRUD_NetCore.Models;
using System.Linq;
using CRUD_NetCore.Models.BD;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_NetCore.Controllers
{
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;
        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Especialidad.ToList());
        }

        public IActionResult Editar(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var especialidad = _context.Especialidad.Where(e => e.IdEspecialidad == Id).FirstOrDefault();
            if(especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public IActionResult Editar(int? id, [Bind("IdEspecialidad,Descripcion")] Especialidad especialidad)
        {
            if (id != especialidad.IdEspecialidad)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }
    }
}