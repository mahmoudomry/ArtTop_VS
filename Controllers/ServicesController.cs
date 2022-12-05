using ArtTop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            {
                ViewBag.ServiceSliders = _context.ServiceSlider.Where(x => x.ServiceId == service.Id).ToList();
                ViewBag.SubServices = _context.SubServices.Where(x => x.ServiceId == service.Id).ToList();
                ViewBag.Offices = _context.Offices.Include(x=>x.OfficeSubServices).Where(x => x.ServiceId == service.Id).ToList();
                return View(service);
            }
            else
                return NotFound();
            return View();
        }
        public IActionResult Profile(int Id)
        {
            ViewBag.current_controller = "Services";
            ViewBag.current_action = "Profile";
            var servicesList = _context.Services.ToList();
            ViewBag.Services = servicesList;
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();

            var office = _context.Offices.Where(x => x.Id == Id).FirstOrDefault();
            if (office != null)
            {
                ViewBag.OfficeSliders = _context.OfficeSliders.Where(x => x.OfficeId == Id).ToList();
                ViewBag.SubServices = _context.OfficeSubServices.Where(x => x.OfficeId == Id).Select(x=>x.SubService).ToList();
                ViewBag.OfficesMedia = _context.OfficeSocialMedias.Where(x => x.OfficeId == Id).ToList();
                return View(office);
            }
            else
                return NotFound();
            return View();
        }
    }
}
