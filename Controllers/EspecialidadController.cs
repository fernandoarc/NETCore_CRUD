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
    }
}