using ArtTop.Data;
using ArtTop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtTop.Areas.Administrative.Controllers
{
    [Area("Administrative")]
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ArtTopContext _context;

        public HomeController(ArtTopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult SiteSetting()
        {
            SiteSetting Setting = _context.SiteSettings.FirstOrDefault();
            return View();
        }
        public ActionResult About()
        {
           
            return View();
        }
    }
}
