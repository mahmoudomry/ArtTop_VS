using ArtTop.Data;
using ArtTop.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
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
            ViewBag.Services= _context.Services.OrderBy(x=>x.Order).ToList();
            ViewBag.Features=_context.Features.ToList();
            ViewBag.Projects= _context.Projects.OrderByDescending(x=>x.Id).Take(3).ToList();
            ViewBag.Clients= _context.Clients.ToList();
           ViewBag.ContactItems=_context.ContactItem.Where(x=>x.ShowInHome==true).ToList();
            ViewBag.SocialMedia=_context.SocialMedia.ToList();
            ViewBag.current_controller = "Home";
            ViewBag.current_action = "Index";

            ViewBag.ServicesItems = _context.Offices.Select(x=>new { x.Id, x.ArabicTitle, x.EnglishTitle, Type = 1,x.ServiceId }).ToList().Union(_context.Doctors.Select(x => new { x.Id, ArabicTitle= x.ArabicName, EnglishTitle=x.EnglisName , Type = 2, x.ServiceId }).ToList());
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
            ViewBag.current_controller = "Home";
            ViewBag.current_action = "About";
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.Features = _context.Features.ToList();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            ViewBag.About = _context.Abouts.FirstOrDefault();
            ViewBag.OurValues=_context.OurValues.ToList();
            ViewBag.OurGoles=_context.OurGoles.ToList();
            ViewBag.Services = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.ServicesItems = _context.Offices.Select(x => new { x.Id, x.ArabicTitle, x.EnglishTitle, Type = 1, x.ServiceId }).ToList().Union(_context.Doctors.Select(x => new { x.Id, ArabicTitle = x.ArabicName, EnglishTitle = x.EnglisName, Type = 2, x.ServiceId }).ToList());
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.current_controller = "Home";
            ViewBag.current_action = "Contact";
            ViewBag.Home = _localizer["home"];
           
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.Services = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.ContactItemsAll = _context.ContactItem.ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            ViewBag.ServicesItems = _context.Offices.Select(x => new { x.Id, x.ArabicTitle, x.EnglishTitle, Type = 1, x.ServiceId }).ToList().Union(_context.Doctors.Select(x => new { x.Id, ArabicTitle = x.ArabicName, EnglishTitle = x.EnglisName, Type = 2, x.ServiceId }).ToList());
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(ContactUsViewModel contact)
        {

            if (ModelState.IsValid)
            {
                ContactMessages message= new ContactMessages();
                message.FullName=contact.FullName;  
                message.Email=contact.Email;    
                message.Subject=contact.Subject;
                message.Message = contact.Message;
                message.Inserted_at = DateTime.Now;
                message.IsRead = false;
                _context.Add(message);
                _context.SaveChanges();
                TempData["Message"] = "<div class='alert alert-success'> " + _localizer["MessageSentSuccessfully"] + "</div>";
                return RedirectToAction("Contact", "Home",new ContactUsViewModel());
                
            }
            TempData["Message"] = "<div class='alert alert-danger'> " + _localizer["PleaseFillAllBoxes"] + "</div>";
            ViewBag.current_controller = "Home";
            ViewBag.current_action = "Contact";
            ViewBag.Home = _localizer["home"];

            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.Services = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.ContactItemsAll = _context.ContactItem.ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            return View("Contact", contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddEmaiToNewsLetter(NewsLetterViewModel News)
        {
            string Message = "";

            if (ModelState.IsValid)
            {

                if (_context.NewsLetters.FirstOrDefault(x => x.Email == News.Email) == null)
                {
                    NewsLetter newsLetter = new NewsLetter();
                    newsLetter.Email = News.Email;
                    newsLetter.Created_at = DateTime.Now;


                    _context.Add(newsLetter);
                    _context.SaveChanges();
                     Message = "<div class='alert alert-success'> " + _localizer["YouSubscribeSuccessfully"] + "</div>";
                    return Json(new { status = "success", Message = Message });
                }
                else {
                     Message = "<div class='alert alert-success'> " + _localizer["YouSubscribeSuccessfully"] + "</div>";
                    return Json(new { status = "success", Message = Message });
                }

            }

             Message = "<div class='alert alert-danger'> " + _localizer["PleaseFillAllBoxes"] + "</div>";
            return Json(new { status = "failed", Message = Message });
           
        }
    }
    public class ContactUsViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
       
    }

    public class NewsLetterViewModel
    {
      
        [Required, EmailAddress]
        public string Email { get; set; }
      

    }
}