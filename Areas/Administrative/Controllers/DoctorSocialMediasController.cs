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
    public class DoctorSocialMediasController : Controller
    {
        private readonly ArtTopContext _context;

        public DoctorSocialMediasController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/DoctorSocialMedias
        public async Task<IActionResult> Index(int? DoctorId)
        {
            if (DoctorId == null)
            {
                var artTopContext = _context.OfficeSocialMedias.Where(x=>x.Type==2).Include(o => o.Office);
                return View(await artTopContext.ToListAsync());
            }
            else
            {
                var doctor = _context.Doctors.Include("Service").FirstOrDefault(x => x.Id == DoctorId);
                ViewBag.PersonDetails = " Service: " + doctor.Service.EnglishTitle + " - Name: " + doctor.EnglisName + "";
                var artTopContext = _context.OfficeSocialMedias.Where(x => x.DoctorId == DoctorId && x.Type==2).Include(o => o.Office);
                return View(await artTopContext.ToListAsync());
            }
        }

        // GET: Administrative/OfficeSocialMedias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OfficeSocialMedias == null)
            {
                return NotFound();
            }

            var officeSocialMedia = await _context.OfficeSocialMedias
                .Include(o => o.Doctor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeSocialMedia == null)
            {
                return NotFound();
            }

            return View(officeSocialMedia);
        }

        // GET: Administrative/OfficeSocialMedias/Create
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
            return View(new OfficeSocialMedia());
        }

        // POST: Administrative/OfficeSocialMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,ArabicTitle,EnglishTitle,Link,Icon,Order,Type")] OfficeSocialMedia officeSocialMedia)
        {
            if (ModelState.IsValid)
            {
                officeSocialMedia.Type = officeSocialMedia.Type ?? 2;
                if (officeSocialMedia.Id == 0)
                    _context.Add(officeSocialMedia);
                else
                    _context.Update(officeSocialMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { DoctorId = officeSocialMedia.DoctorId });
            }
            var doctor = _context.Doctors.Include("Service").FirstOrDefault(x => x.Id == officeSocialMedia.DoctorId);
            ViewBag.PersonDetails = " Service: " + doctor.Service.EnglishTitle + " - Name: " + doctor.EnglisName + "";
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "EnglisName", officeSocialMedia.DoctorId);
            return View(officeSocialMedia);
        }

        // GET: Administrative/OfficeSocialMedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OfficeSocialMedias == null)
            {
                return NotFound();
            }

            var officeSocialMedia = await _context.OfficeSocialMedias.FindAsync(id);
            if (officeSocialMedia == null)
            {
                return NotFound();
            }
            var doctor = _context.Doctors.Include("Service").FirstOrDefault(x => x.Id == officeSocialMedia.DoctorId);
            ViewBag.PersonDetails = " Service: " + doctor.Service.EnglishTitle + " - Name: " + doctor.EnglisName + "";
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "DoctorId", officeSocialMedia.DoctorId);
            return View("Create", officeSocialMedia);
        }

        // POST: Administrative/OfficeSocialMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OfficeId,ArabicTitle,EnglishTitle,Link,Icon,Order")] OfficeSocialMedia officeSocialMedia)
        {
            if (id != officeSocialMedia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(officeSocialMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfficeSocialMediaExists(officeSocialMedia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { OfficeId = officeSocialMedia.OfficeId });
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "EnglishTitle", officeSocialMedia.OfficeId);
            return View(officeSocialMedia);
        }

        // GET: Administrative/OfficeSocialMedias/Delete/5
     
        [ ActionName("Delete")]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OfficeSocialMedias == null)
            {
                return Problem("Entity set 'ArtTopContext.OfficeSocialMedias'  is null.");
            }
            var officeSocialMedia = await _context.OfficeSocialMedias.FindAsync(id);
            if (officeSocialMedia != null)
            {
                _context.OfficeSocialMedias.Remove(officeSocialMedia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeSocialMediaExists(int id)
        {
          return _context.OfficeSocialMedias.Any(e => e.Id == id);
        }
    }
}
