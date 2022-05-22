using Microsoft.AspNetCore.Mvc;

namespace CRUD_NetCore.Controllers
{
    public class EspecialidadController : Controller
    {
        public EspecialidadController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}