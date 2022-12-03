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
    public class ServicesController : Controller
    {
        private readonly ArtTopContext _context;

        public ServicesController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/Services
        public async Task<IActionResult> Index()
        {
              return View(await _context.Services.ToListAsync());
        }

        // GET: Administrative/Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Administrative/Services/Create
        public IActionResult Create()
        {
            return View(new Service());
        }

        // POST: Administrative/Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicTitle,EnglishTitle,ArabicDetails,EnglishDetails,CoverImage,Icon")] Service service ,IFormFile? CoverImagefile, IFormFile? Iconfile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(service, CoverImagefile, Iconfile);
                if (service == null || service.Id == 0)
                {
                    _context.Add(service);
                }
                else
                    _context.Update(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // GET: Administrative/Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound(); 
            }
            return View("create",service);
        }

        // POST: Administrative/Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicTitle,EnglishTitle,ArabicDetails,EnglishDetails,CoverImage,Icon")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
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
            return View(service);
        }

        // GET: Administrative/Services/Delete/5
      
        [ActionName("Delete")]
  
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Services == null)
            {
                return Problem("Entity set 'ArtTopContext.Services'  is null.");
            }
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return _context.Services.Any(e => e.Id == id);
        }
        private void UploadImages(Service service, IFormFile? CoverImagefile, IFormFile? Iconfile)
        {
            Helper h = new Helper();
            service.CoverImage = h.saveimage(CoverImagefile, service.CoverImage == "" || service.CoverImage == null ? "service-01.jpg" : service.CoverImage);
            service.Icon = h.saveimage(Iconfile, service.Icon == "" || service.Icon == null ? "construction.svg" : service.Icon);
        }
    }
}
