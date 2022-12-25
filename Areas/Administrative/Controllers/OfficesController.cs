using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtTop.Data;
using ArtTop.Models;

namespace ArtTop.Areas.Administrative.Controllers
{
    [Area("Administrative")]
    public class OfficesController : Controller
    {
        private readonly ArtTopContext _context;

        public OfficesController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/Offices
        public async Task<IActionResult> Index()
        {
            var artTopContext = _context.Offices.Include(o => o.Service);
            return View(await artTopContext.ToListAsync());
        }

        // GET: Administrative/Offices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Offices == null)
            {
                return NotFound();
            }

            var office = await _context.Offices
                .Include(o => o.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (office == null)
            {
                return NotFound();
            }

            return View(office);
        }

        // GET: Administrative/Offices/Create
        public IActionResult Create()
        {

            var list= new SelectList(_context.Services, "Id", "EnglishTitle");
            int id=0;
            int.TryParse(list.FirstOrDefault().Value, out id);
            ViewData["ServiceId"] = list;
            ViewData["SubServicesIds"] = new SelectList(_context.SubServices.Where(x=>x.ServiceId==id), "Id", "EnglishTitle");
            return View(new Office());
        }

        // POST: Administrative/Offices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceId,ArabicTitle,EnglishTitle,ArabicManagerName," +
            "ManagerName,ArabicAboutTitle,EnglishAboutTitle,ArabicDetails,EnglishDetails,CoverImage,Icon," +
            "ArabicContactTitle,EnglishContactTitle,ArabicAddress,EnglishAddress,Phone,WorkingHours,Weekend," +
            "MissionAR,MissionEn,Mission,ClientAR,ClientEn,Client,WorkerAR,WorkerEn,Worker," +
            "ExperienceAR,ExperienceEn,Experience,Location,ProfileImage,CoverImageArabic,WorkingHoursAr,WeekendAr")] Office office,
            int[]? SubServicesIds, IFormFile?CoverImageFile,IFormFile ? ProfileImageFile,IFormFile? CoverImageArabicFile,IFormFile? ProfileImageArFile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(office, CoverImageFile, ProfileImageFile, CoverImageArabicFile, ProfileImageArFile);
                if(office==null||office.Id==0)
                _context.Add(office);
                else
                    _context.Update(office);


              
                await _context.SaveChangesAsync();
                if (SubServicesIds.Length > 0)
                {
                    _context.OfficeSubServices.RemoveRange(_context.OfficeSubServices.Where(o => o.OfficeId == office.Id));
                    List<OfficeSubServices> mylist = new List<OfficeSubServices>();
                    foreach (int sub in SubServicesIds)
                    {
                        mylist.Add(new OfficeSubServices { OfficeId = office.Id, SubSeviceId = sub });
                    }
                    _context.AddRange(mylist);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SubServicesSelected = string.Join(',', SubServicesIds);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", office.ServiceId);

            ViewData["SubServicesIds"] = new SelectList(_context.SubServices.Where(x=>x.ServiceId== office.ServiceId), "Id", "EnglishTitle", SubServicesIds);
            return View(office);
        }

        // GET: Administrative/Offices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Offices == null)
            {
                return NotFound();
            }

            var office = await _context.Offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", office.ServiceId);
            var listItems = _context.OfficeSubServices.Where(x => x.OfficeId == office.Id).ToList();
            ViewData["SubServicesIds"] = new SelectList(_context.SubServices.Where(x => x.ServiceId == office.ServiceId), "Id", "EnglishTitle", listItems.Select(x => x.SubSeviceId));

            ViewBag.SubServicesSelected = string.Join(',', office.OfficeSubServices.Select(x => x.SubSeviceId));
            return View("Create",office);
        }

        // POST: Administrative/Offices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceId,ArabicTitle,EnglishTitle,ArabicManagerName,ManagerName,ArabicAboutTitle,EnglishAboutTitle,ArabicDetails,EnglishDetails,CoverImage,Icon,ArabicContactTitle,EnglishContactTitle,ArabicAddress,EnglishAddress,Phone,WorkingHours,Weekend,MissionAR,MissionEn,Mission,ClientAR,ClientEn,Client,WorkerAR,WorkerEn,Worker,ExperienceAR,ExperienceEn,Experience,Location")] Office office)
        {
            if (id != office.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(office);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeExists(office.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", office.ServiceId);
            return View(office);
        }



        // get: Administrative/Offices/Delete/5
        [ ActionName("Delete")]
    
        public  IActionResult DeleteConfirmed(int id)
        {
            if (_context.Offices == null)
            {
                return Problem("Entity set 'ArtTopContext.Offices'  is null.");
            }
            var office =  _context.Offices.Find(id);
            if (office != null)
            {
                _context.OfficeSubServices.RemoveRange(_context.OfficeSubServices.Where(o => o.OfficeId == office.Id)); _context.SaveChanges();
                _context.OfficeSliders.RemoveRange(_context.OfficeSliders.Where(x => x.Type == 1 && x.OfficeId == office.Id)); _context.SaveChanges();
                _context.OfficeSocialMedias.RemoveRange(_context.OfficeSocialMedias.Where(x => x.Type == 1 && x.OfficeId == office.Id)); _context.SaveChanges();
                _context.Bookings.RemoveRange(_context.Bookings.Where(x => x.Type == 1 && x.OfficeId == office.Id)); _context.SaveChanges();
                _context.Offices.Remove(office);
            }
            
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeExists(int id)
        {
          return _context.Offices.Any(e => e.Id == id);
        }
        private void UploadImages(Office office, IFormFile? CoverImagefile,IFormFile? ProfileImageFile,IFormFile? CoverImageArabicFile,IFormFile? ProfileImageArFile)
        {
            Helper h = new Helper();
            office.CoverImage = h.saveimage(CoverImagefile, office.CoverImage == "" || office.CoverImage == null ? "about-clinic-img.png" : office.CoverImage);
            office.CoverImageArabic = h.saveimage(CoverImageArabicFile, office.CoverImageArabic == "" || office.CoverImageArabic == null ? "about-clinic-img.png" : office.CoverImageArabic);
            office.ProfileImage = h.saveimage(ProfileImageFile, office.ProfileImage == "" || office.ProfileImage == null ? "about-clinic-img.png" : office.ProfileImage);
            office.ProfileImageAr = h.saveimage(ProfileImageArFile, office.ProfileImageAr == "" || office.ProfileImageAr == null ? "about-clinic-img.png" : office.ProfileImageAr);
        }
    }
}
