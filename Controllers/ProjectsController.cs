using ArtTop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ArtTop.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ArtTopContext _context;
        public ProjectsController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, ArtTopContext context)
        {
            _logger = logger;
            _localizer = localizer;
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.current_controller = "Projects";
            ViewBag.current_action = "Index";
            ViewBag.Services = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.Projects = _context.Projects.ToList();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            ViewBag.ServicesItems = _context.Offices.Select(x => new { x.Id, x.ArabicTitle, x.EnglishTitle, Type = 1, x.ServiceId }).ToList().Union(_context.Doctors.Select(x => new { x.Id, ArabicTitle = x.ArabicName, EnglishTitle = x.EnglisName, Type = 2, x.ServiceId }).ToList());
            return View();
        }
        public IActionResult Details(int?id)
        {
            ViewBag.current_controller = "Projects";
            ViewBag.current_action = "Details";
            ViewBag.Services = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
           // ViewBag.Projects = _context.Projects.ToList();
            ViewBag.ContactItems = _context.ContactItem.ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            ViewBag.ServicesItems = _context.Offices.Select(x => new { x.Id, x.ArabicTitle, x.EnglishTitle, Type = 1, x.ServiceId }).ToList().Union(_context.Doctors.Select(x => new { x.Id, ArabicTitle = x.ArabicName, EnglishTitle = x.EnglisName, Type = 2, x.ServiceId }).ToList());
            var project= _context.Projects.Find(id);
            if(project!=null)
            return View(project);
            else
            return NotFound();
        }

    }
}
