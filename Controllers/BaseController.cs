using Microsoft.AspNetCore.Mvc;

namespace ArtTop.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
