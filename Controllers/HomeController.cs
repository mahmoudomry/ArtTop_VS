using ArtTop.Data;
using ArtTop.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;

namespace ArtTop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ArtTopContext _context;
        public HomeController(ILogger<HomeController> logger,IStringLocalizer<HomeController> localizer,ArtTopContext context)
        {
            _logger = logger;
            _localizer = localizer;
            _context = context;
        }
        //home
        public IActionResult Index()
        {
            ViewBag.Home = _localizer["home"];
            ViewBag.Sliders=_context.Sliders.ToList();
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.Services= _context.Services.ToList();
            ViewBag.Features=_context.Features.ToList();
            ViewBag.Projects= _context.Projects.ToList();
            ViewBag.Clients= _context.Clients.ToList();
           ViewBag.ContactItems=_context.ContactItem.Where(x=>x.ShowInHome==true).ToList();
            ViewBag.SocialMedia=_context.SocialMedia.ToList();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //About
        public IActionResult About()
        {

            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.Features = _context.Features.ToList();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            ViewBag.About = _context.Abouts.FirstOrDefault();
            ViewBag.OurValues=_context.OurValues.ToList();
            ViewBag.OurGoles=_context.OurGoles.ToList();
            ViewBag.Services = _context.Services.ToList();
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            returnUrl= returnUrl.Replace("ar-EG", culture).Replace("en-US", culture);

            if (!returnUrl.Contains(culture))
                returnUrl=returnUrl.Replace($"~/", $"~/{culture}/");
            //returnUrl["culture"] = culture;
            //   string url = ("~/" + returnUrl["culture"] + "/" + (returnUrl["controller"]!= null ? "/" + returnUrl["controller"] : "")+(returnUrl["action"] != null ?  "/" + returnUrl["action"]:"") +( returnUrl["id"] != null ? "/" + returnUrl["id"] : ""));
            return LocalRedirect(returnUrl);
        }

    }
}