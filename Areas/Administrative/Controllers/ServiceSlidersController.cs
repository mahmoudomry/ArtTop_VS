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
    public class ServiceSlidersController : Controller
    {
        private readonly ArtTopContext _context;

        public ServiceSlidersController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/ServiceSliders
        public async Task<IActionResult> Index()
        {
            var artTopContext = _context.ServiceSlider.Include(s => s.Service);
            return View(await artTopContext.ToListAsync());
        }

        // GET: Administrative/ServiceSliders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServiceSlider == null)
            {
                return NotFound();
            }

            var serviceSlider = await _context.ServiceSlider
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceSlider == null)
            {
                return NotFound();
            }

            return View(serviceSlider);
        }

        // GET: Administrative/ServiceSliders/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle");
            return View(new ServiceSlider());
        }

        // POST: Administrative/ServiceSliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CoverImage,IsActive,Order,ServiceId")] ServiceSlider serviceSlider, IFormFile? CoverImageFile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(serviceSlider, CoverImageFile);    
                if(serviceSlider.Id==0)
                _context.Add(serviceSlider);
                else
                    _context.Update(serviceSlider);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", serviceSlider.ServiceId);
            return View(serviceSlider);
        }

        // GET: Administrative/ServiceSliders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServiceSlider == null)
            {
                return NotFound();
            }

            var serviceSlider = await _context.ServiceSlider.FindAsync(id);
            if (serviceSlider == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", serviceSlider.ServiceId);
            return View("Create",serviceSlider);
        }

        // POST: Administrative/ServiceSliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CoverImage,IsActive,Order,ServiceId")] ServiceSlider serviceSlider)
        {
            if (id != serviceSlider.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceSlider);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceSliderExists(serviceSlider.Id))
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
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", serviceSlider.ServiceId);
            return View(serviceSlider);
        }

        // GET: Administrative/ServiceSliders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServiceSlider == null)
            {
                return NotFound();
            }

            var serviceSlider = await _context.ServiceSlider
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceSlider == null)
            {
                return NotFound();
            }

            return View(serviceSlider);
        }

        // POST: Administrative/ServiceSliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServiceSlider == null)
            {
                return Problem("Entity set 'ArtTopContext.ServiceSlider'  is null.");
            }
            var serviceSlider = await _context.ServiceSlider.FindAsync(id);
            if (serviceSlider != null)
            {
                _context.ServiceSlider.Remove(serviceSlider);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceSliderExists(int id)
        {
          return _context.ServiceSlider.Any(e => e.Id == id);
        }
        private void UploadImages(ServiceSlider slider, IFormFile? CoverImagefile)
        {
            Helper h = new Helper();
            slider.CoverImage = h.saveimage(CoverImagefile, slider.CoverImage == "" || slider.CoverImage == null ? "service-01.jpg" : slider.CoverImage);
            
        }
    }
}
