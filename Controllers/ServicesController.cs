using ArtTop.Data;
using ArtTop.Models;
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
            ViewBag.Services = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();
            return View();
        }
        public IActionResult Details(int id)
        {
            ViewBag.current_controller = "Services";
            ViewBag.current_action = "Details";
            var servicesList = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.Services = servicesList;
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();


            var service = servicesList.Where(x => x.Id == id).FirstOrDefault();
            if (service != null)
            {
                ViewBag.ServiceSliders = _context.ServiceSlider.Where(x => x.ServiceId == service.Id).ToList();
                ViewBag.SubServices = _context.SubServices.Where(x => x.ServiceId == service.Id).ToList();
                ViewBag.Offices = _context.Offices.Include(x => x.OfficeSubServices).Where(x => x.ServiceId == service.Id).ToList();
                ViewBag.Doctors = _context.Doctors.Include(x => x.SubServices).Where(x => x.ServiceId == service.Id).ToList();
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
            var servicesList = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.Services = servicesList;
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();

            var office = _context.Offices.Where(x => x.Id == Id).FirstOrDefault();
            if (office != null)
            {
                ViewBag.OfficeSliders = _context.OfficeSliders.Where(x => x.OfficeId == Id).ToList();
                ViewBag.SubServices = _context.OfficeSubServices.Where(x => x.OfficeId == Id).Select(x => x.SubService).ToList();
                ViewBag.OfficesMedia = _context.OfficeSocialMedias.Where(x => x.OfficeId == Id).ToList();
                return View(office);
            }
            else
                return NotFound();
            return View();
        }
        public IActionResult PersonProfile(int Id)
        {
            ViewBag.current_controller = "Services";
            ViewBag.current_action = "PersonProfile";
            var servicesList = _context.Services.OrderBy(x => x.Order).ToList();
            ViewBag.Services = servicesList;
            ViewBag.SiteSetting = _context.SiteSettings.FirstOrDefault();
            ViewBag.ContactItems = _context.ContactItem.Where(x => x.ShowInHome == true).ToList();
            ViewBag.SocialMedia = _context.SocialMedia.ToList();

            var doctor = _context.Doctors.Where(x => x.Id == Id).FirstOrDefault();
            if (doctor != null)
            {
                ViewBag.OfficeSliders = _context.OfficeSliders.Where(x => x.DoctorId == Id).ToList();
                ViewBag.SubServices = _context.DoctorSubServices.Where(x => x.DoctorId == Id).Select(x => x.SubService).ToList();
                ViewBag.OfficesMedia = _context.OfficeSocialMedias.Where(x => x.DoctorId == Id).ToList();
                return View(doctor);
            }
            else
                return NotFound();
            return View();
        }

        [HttpGet]
        public JsonResult GetWorkers(int? id)
        {

            var service= _context.Services.FirstOrDefault(x => x.Id == id);
            
             var doctorsList = _context.Doctors.Where(x => x.ServiceId == id).Select(x => new { x.Id, x.ArabicName, x.EnglisName, Type = "2" }).ToList();
            var officeList = _context.Offices.Where(a => a.ServiceId == id).Select(x => new { x.Id, x.ArabicManagerName, x.ManagerName, Type = "1" }).ToList();

            List<DoctorLookup> MyList=new List<DoctorLookup>();
            foreach (var doctor in doctorsList) { 
            DoctorLookup d = new DoctorLookup();
                d.Id = doctor.Id;   
                d.ArabicName = doctor.ArabicName;   
                d.EnglisName= doctor.EnglisName;
                d.Type = doctor.Type;   
                MyList.Add(d);

            }

            foreach (var office in officeList)
            {
                DoctorLookup d = new DoctorLookup();
                d.Id = office.Id;
                d.ArabicName = office.ArabicManagerName;
                d.EnglisName = office.ManagerName;
                d.Type = office.Type;
                MyList.Add(d);

            }

            return Json(new { List = MyList,WorkerAR=service.WorkersArabic, WorkerEn=service.WorkersEnglish });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult BookAppointment(BookAppointmentViewModel book)
        {
            if (ModelState.IsValid)
            {

                var date = DateOnly.Parse(book.Date);
                var time = TimeOnly.Parse(book.Time);
                var isAvailable = true;
                if (book.DoctorType == 2)
                {
                    var bookd = _context.Bookings.Where(x => x.DoctorId == book.DoctorId && x.Date == date && x.Time == time).FirstOrDefault();
                    if (bookd != null)
                        isAvailable = false;
                }
                else if (book.DoctorType == 1)
                {
                    var bookd = _context.Bookings.Where(x => x.OfficeId == book.DoctorId && x.Date == date && x.Time == time).FirstOrDefault();
                    if (bookd != null)
                        isAvailable = false;
                }
                if (!isAvailable)
                    return Json(new { IsAvailable = isAvailable, Message = "Book Is Not Available", MessageAr = "الموعد غير متاح" });
                else
                {
                    Booking b = new Booking();
                    b.IsRead = false;
                    b.IsDone = false;
                    b.Type = book.DoctorType;
                  
                   if(book.DoctorType==1)
                        b.OfficeId = book.DoctorId;
                   if(book.DoctorType==2)
                        b.DoctorId = book.DoctorId;
                   b.ServiceId=book.ServiceId;

                    b.FullName=book.FullName; 
                    b.Phone = book.Phone;
                    b.Email=book.Email;
                    b.Date=date;
                    b.Time=time;   
                    _context.Bookings.Add(b);   
                    _context.SaveChanges();
                    return Json(new { IsAvailable = isAvailable, Message = "The Appintment Booked Successed",MessageAr="تم حجز الموعد بنجاح" });
                }
            }
            return Json(new { IsAvailable = false, Message = "Please Fill All Boxes" , MessageAr = "الرجاء ملء جميع الحقول" });

        }

    }

    public class DoctorLookup
        {

        public int? Id { get; set; }
        public string? ArabicName { get; set; }
        public string? EnglisName { get; set; }
        public string? Type { get; set; }

    }
    public class BookAppointmentViewModel
    {

      
        public string FullName { get; set; }
        public string Phone { get; set; }
        
        public string Email { get; set; }
        public int ServiceId { get; set; }
        public int DoctorId { get; set; }
        public int DoctorType { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
