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
    public class DoctorsController : Controller
    {
        private readonly ArtTopContext _context;

        public DoctorsController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/Doctors
        public async Task<IActionResult> Index()
        {
            var artTopContext = _context.Doctors.Include(d => d.Office).Include(d => d.Service);
            return View(await artTopContext.ToListAsync());
        }

        // GET: Administrative/Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(d => d.Office)
                .Include(d => d.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Administrative/Doctors/Create
        public IActionResult Create()
        {
            var items = _context.Offices.ToList();
            items.Insert(0, new Office() { EnglishTitle="None"});
            ViewData["OfficeId"] = new SelectList(items, "Id", "EnglishTitle");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle");
            ViewData["SubServicesIds"] = new SelectList(_context.SubServices, "Id", "EnglishTitle");
            return View(new Doctor());
        }

        // POST: Administrative/Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceId,OfficeId,ArabicTitle,EnglishTitle," +
            "ArabicName,EnglisName,ArabicAboutTitle,EnglishAboutTitle,ArabicDetails,EnglishDetails,CoverImage," +
            "CoverImageArabic,ProfileImage,ProfileImageAr,ArabicContactTitle,EnglishContactTitle,ArabicAddress," +
            "EnglishAddress,Phone,WorkingHours,WorkingHoursAr,Weekend,WeekendAr,Location")] Doctor doctor,
            int[]? SubServicesIds, IFormFile? CoverImageFile, IFormFile? ProfileImageFile, 
            IFormFile? CoverImageArabicFile, IFormFile? ProfileImageArFile)
        {
            if (ModelState.IsValid)
            {
                doctor.OfficeId= doctor.OfficeId==0?null:doctor.OfficeId;
                UploadImages(doctor, CoverImageFile, ProfileImageFile, CoverImageArabicFile, ProfileImageArFile);
                if (doctor == null || doctor.Id == 0)
                    _context.Add(doctor);
                else
                    _context.Update(doctor);
                await _context.SaveChangesAsync();

                if (SubServicesIds.Length > 0)
                {
                    _context.DoctorSubServices.RemoveRange(_context.DoctorSubServices.Where(o => o.DoctorId == doctor.Id));
                    List<DoctorSubServices> mylist = new List<DoctorSubServices>();
                    foreach (int sub in SubServicesIds)
                    {
                        mylist.Add(new DoctorSubServices { DoctorId = doctor.Id, SubSeviceId = sub });
                    }
                    _context.AddRange(mylist);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var items = _context.Offices.ToList();
            items.Insert(0, new Office() { EnglishTitle = "None" });
           
            ViewData["OfficeId"] = new SelectList(items, "Id", "EnglishTitle", doctor.OfficeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", doctor.ServiceId);
            ViewData["SubServicesIds"] = new SelectList(_context.SubServices, "Id", "EnglishTitle", SubServicesIds);
            return View(doctor);
        }

        // GET: Administrative/Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            var items = _context.Offices.ToList();
            items.Insert(0, new Office() { EnglishTitle = "None" });
         
            ViewData["OfficeId"] = new SelectList(items, "Id", "EnglishTitle", doctor.OfficeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", doctor.ServiceId);
           var listItems = _context.DoctorSubServices.Where(x => x.DoctorId == doctor.Id).ToList();
            ViewData["SubServicesIds"] = new SelectList(_context.SubServices, "Id", "EnglishTitle", listItems.Select(x => x.SubSeviceId));
            return View("Create",doctor);
        }

        // POST: Administrative/Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServiceId,OfficeId,ArabicTitle,EnglishTitle,ArabicName,EnglisName,ArabicAboutTitle,EnglishAboutTitle,ArabicDetails,EnglishDetails,CoverImage,CoverImageArabic,ProfileImage,ProfileImageAr,ArabicContactTitle,EnglishContactTitle,ArabicAddress,EnglishAddress,Phone,WorkingHours,WorkingHoursAr,Weekend,WeekendAr,Location")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "ArabicAboutTitle", doctor.OfficeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ArabicDetails", doctor.ServiceId);
            return View(doctor);
        }

        // GET: Administrative/Doctors/Delete/5
       
        [ActionName("Delete")]
        
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctors == null)
            {
                return Problem("Entity set 'ArtTopContext.Doctors'  is null.");
            }
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
          return _context.Doctors.Any(e => e.Id == id);
        }
        private void UploadImages(Doctor doctor, IFormFile? CoverImagefile, IFormFile? ProfileImageFile, IFormFile? CoverImageArabicFile, IFormFile? ProfileImageArFile)
        {
            Helper h = new Helper();
            doctor.CoverImage = h.saveimage(CoverImagefile, doctor.CoverImage == "" || doctor.CoverImage == null ? "about-clinic-img.png" : doctor.CoverImage);
            doctor.CoverImageArabic = h.saveimage(CoverImageArabicFile, doctor.CoverImageArabic == "" || doctor.CoverImageArabic == null ? "about-clinic-img.png" : doctor.CoverImageArabic);
            doctor.ProfileImage = h.saveimage(ProfileImageFile, doctor.ProfileImage == "" || doctor.ProfileImage == null ? "about-clinic-img.png" : doctor.ProfileImage);
            doctor.ProfileImageAr = h.saveimage(ProfileImageArFile, doctor.ProfileImageAr == "" || doctor.ProfileImageAr == null ? "about-clinic-img.png" : doctor.ProfileImageAr);
        }
    }
}
