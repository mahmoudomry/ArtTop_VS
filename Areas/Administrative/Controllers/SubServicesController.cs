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
    public class SubServicesController : Controller
    {
        private readonly ArtTopContext _context;

        public SubServicesController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/SubServices
        public async Task<IActionResult> Index()
        {
            var artTopContext = _context.SubServices.Include(s => s.Service);
            return View(await artTopContext.ToListAsync());
        }

        public JsonResult GetSubServices(int id)
        {
            var list = _context.SubServices.Where(x => x.ServiceId == id).ToList();
            return Json(list);  
        }

        // GET: Administrative/SubServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SubServices == null)
            {
                return NotFound();
            }

            var subService = await _context.SubServices
                .Include(s => s.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subService == null)
            {
                return NotFound();
            }

            return View(subService);
        }

        // GET: Administrative/SubServices/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle");
            return View(new SubService());
        }

        // POST: Administrative/SubServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicTitle,EnglishTitle,ArabicDetails,EnglishDetails,CoverImage,Icon,ServiceId")] SubService subService, IFormFile? CoverImagefile, IFormFile? Iconfile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(subService, CoverImagefile, Iconfile);
                if (subService == null || subService.Id == 0)
                {
                    _context.Add(subService);
                }
                else
                    _context.Update(subService);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", subService.ServiceId);
            return View(subService);
        }

        // GET: Administrative/SubServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SubServices == null)
            {
                return NotFound();
            }

            var subService = await _context.SubServices.FindAsync(id);
            if (subService == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", subService.ServiceId);
            return View("Create",subService);
        }

        // POST: Administrative/SubServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicTitle,EnglishTitle,ArabicDetails,EnglishDetails,CoverImage,Icon,ServiceId")] SubService subService)
        {
            if (id != subService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubServiceExists(subService.Id))
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
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", subService.ServiceId);
            return View(subService);
        }


        // GET: Administrative/SubServices/Delete/5
        [ ActionName("Delete")]
  
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SubServices == null)
            {
                return Problem("Entity set 'ArtTopContext.SubServices'  is null.");
            }
            var subService = await _context.SubServices.FindAsync(id);
            if (subService != null)
            {
                _context.SubServices.Remove(subService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubServiceExists(int id)
        {
          return _context.SubServices.Any(e => e.Id == id);
        }
        private void UploadImages(SubService subService, IFormFile? CoverImagefile, IFormFile? Iconfile)
        {
            Helper h = new Helper();
            subService.CoverImage = h.saveimage(CoverImagefile, subService.CoverImage == "" || subService.CoverImage == null ? "service-01.jpg" : subService.CoverImage);
            subService.Icon = h.saveimage(Iconfile, subService.Icon == "" || subService.Icon == null ? "construction.svg" : subService.Icon);
        }
    }
}
