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
        public HomeController(ILogger<HomeController> logger,IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }
        //home
        public IActionResult Index()
        {
            ViewBag.Home = _localizer["home"];
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