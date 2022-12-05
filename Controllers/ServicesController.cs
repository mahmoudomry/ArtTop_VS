using ArtTop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ArtTop.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ArtTopContext _context;
        public ServicesController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, ArtTopContext context)
        {
            _logger = logger;
            _localizer = localizer;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.current_controller = "Services";
            ViewBag.current_action = "Index";
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.Services = _context.Services.ToList();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            return View();
        }
        public IActionResult Details(int id)
        {
            ViewBag.current_controller = "Services";
            ViewBag.current_action = "Details";
            var servicesList= _context.Services.ToList();
            ViewBag.Services = servicesList;
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
          
            
            var service = servicesList.Where(x=>x.Id==id).FirstOrDefault();
            if (service != null)
                return View(service);
            else
                return NotFound();
            return View();
        }
        public IActionResult Profile()
        {
            ViewBag.current_controller = "Services";
            ViewBag.current_action = "Profile";
            var servicesList = _context.Services.ToList();
            ViewBag.Services = servicesList;
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();


            return View();
        }
    }
}
