using Microsoft.AspNetCore.Mvc;

namespace ArtTop.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
