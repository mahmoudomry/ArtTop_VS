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
    public class OfficeSlidersController : Controller
    {
        private readonly ArtTopContext _context;

        public OfficeSlidersController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/OfficeSliders
        public async Task<IActionResult> Index(int? OfficeId)
        {
            if (OfficeId == null)
            {
                var artTopContext = _context.OfficeSliders.Include(o => o.Office);
                return View(await artTopContext.ToListAsync());
            }
            else
            {
                var artTopContext = _context.OfficeSliders.Where(x=>x.OfficeId== OfficeId).Include(o => o.Office);
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
        public IActionResult Create(int? OfficeId)
        {
            if (OfficeId != null)
                ViewData["OfficeId"] = new SelectList(_context.Offices.Where(x=>x.Id== OfficeId), "Id", "EnglishTitle");
            else
                ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "EnglishTitle");
            return View(new OfficeSlider());
        }

        // POST: Administrative/OfficeSliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoverImage,IsActive,Order,OfficeId")] OfficeSlider officeSlider, IFormFile? CoverImageFile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(officeSlider, CoverImageFile);
                if (officeSlider.Id == 0)
                    _context.Add(officeSlider);
                else
                    _context.Update(officeSlider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { OfficeId = officeSlider.OfficeId});
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "EnglishTitle", officeSlider.OfficeId);
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
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "EnglishTitle", officeSlider.OfficeId);
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
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "EnglishTitle", officeSlider.OfficeId);
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
        private void UploadImages(OfficeSlider slider, IFormFile? CoverImagefile)
        {
            Helper h = new Helper();
            slider.CoverImage = h.saveimage(CoverImagefile, slider.CoverImage == "" || slider.CoverImage == null ? "service-01.jpg" : slider.CoverImage);

        }
    }
}
