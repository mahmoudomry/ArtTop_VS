using Microsoft.AspNetCore.Mvc;

namespace ArtTop.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }

    }
}
