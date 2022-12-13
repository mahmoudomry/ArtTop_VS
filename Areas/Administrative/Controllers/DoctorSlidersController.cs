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
    public class DoctorSlidersController : Controller
    {
        private readonly ArtTopContext _context;

        public DoctorSlidersController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/OfficeSliders
        public async Task<IActionResult> Index(int? DoctorId)
        {
            if (DoctorId == null)
            {
                var artTopContext = _context.OfficeSliders.Where(x => x.Type == 2).Include(o => o.Office);
                return View(await artTopContext.ToListAsync());
            }
            else
            {
                var doctor = _context.Doctors.Include("Service").FirstOrDefault(x => x.Id == DoctorId);
                if (doctor != null)
                    ViewBag.PersonDetails = " Service: " + doctor.Service.EnglishTitle + " - Name: " + doctor.EnglisName + "";
                var artTopContext = _context.OfficeSliders.Where(x=>x.DoctorId == DoctorId && x.Type==2).Include(o => o.Office);
                return View(await artTopContext.ToListAsync());
            }
        }

        // GET: Administrative/OfficeSliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OfficeSliders == null)
            {
                return NotFound();
            }

            var officeSlider = await _context.OfficeSliders
                .Include(o => o.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeSlider == null)
            {
                return NotFound();
            }

            return View(officeSlider);
        }

        // GET: Administrative/OfficeSliders/Create
        public IActionResult Create(int? DoctorId)
        {
            if (DoctorId != null)
            {
                var doctor = _context.Doctors.Include("Service").FirstOrDefault(x => x.Id == DoctorId);
                ViewBag.PersonDetails = " Service: " + doctor.Service.EnglishTitle + " - Name: " + doctor.EnglisName + "";
                ViewData["DoctorId"] = new SelectList(_context.Doctors.Where(x => x.Id == DoctorId), "Id", "EnglisName");
            }
            else
                ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "EnglisName");
            return View(new OfficeSlider());
        }

        // POST: Administrative/OfficeSliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoverImage,IsActive,Order,DoctorId,CoverImageAr,Type")] OfficeSlider officeSlider, IFormFile? CoverImageFile, IFormFile? CoverImageArFile)
        {
            if (ModelState.IsValid)
            {
                officeSlider.Type = officeSlider.Type ?? 2;
                UploadImages(officeSlider, CoverImageFile, CoverImageArFile);
                if (officeSlider.Id == 0)
                    _context.Add(officeSlider);
                else
                    _context.Update(officeSlider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { DoctorId = officeSlider.DoctorId });
            }
            var doctor = _context.Doctors.Include("Service").FirstOrDefault(x => x.Id == officeSlider.DoctorId);
            ViewBag.PersonDetails = " Service: " + doctor.Service.EnglishTitle + " - Name: " + doctor.EnglisName + "";
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "EnglisName", officeSlider.DoctorId);
            return View(officeSlider);
        }

        // GET: Administrative/OfficeSliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OfficeSliders == null)
            {
                return NotFound();
            }

            var officeSlider = await _context.OfficeSliders.FindAsync(id);
            if (officeSlider == null)
            {
                return NotFound();
            }
            var doctor = _context.Doctors.Include("Service").FirstOrDefault(x => x.Id == officeSlider.DoctorId);
            ViewBag.PersonDetails = " Service: " + doctor.Service.EnglishTitle + " - Name: " + doctor.EnglisName + "";
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "EnglisName", officeSlider.DoctorId);
            return View("Create", officeSlider);
        }

        // POST: Administrative/OfficeSliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoverImage,IsActive,Order,OfficeId")] OfficeSlider officeSlider)
        {
            if (id != officeSlider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeSlider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeSliderExists(officeSlider.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Offices, "Id", "EnglisName", officeSlider.DoctorId);
            return View(officeSlider);
        }

        // GET: Administrative/OfficeSliders/Delete/5
     
        [ ActionName("Delete")]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OfficeSliders == null)
            {
                return Problem("Entity set 'ArtTopContext.OfficeSliders'  is null.");
            }
            var officeSlider = await _context.OfficeSliders.FindAsync(id);
            if (officeSlider != null)
            {
                _context.OfficeSliders.Remove(officeSlider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeSliderExists(int id)
        {
          return _context.OfficeSliders.Any(e => e.Id == id);
        }
        private void UploadImages(OfficeSlider slider, IFormFile? CoverImagefile, IFormFile? CoverImageArfile)
        {
            Helper h = new Helper();
            slider.CoverImage = h.saveimage(CoverImagefile, slider.CoverImage == "" || slider.CoverImage == null ? "service-01.jpg" : slider.CoverImage);
            slider.CoverImageAr = h.saveimage(CoverImageArfile, slider.CoverImageAr == "" || slider.CoverImageAr == null ? "service-01.jpg" : slider.CoverImageAr);
        }
    }
}
