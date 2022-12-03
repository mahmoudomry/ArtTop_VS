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
    public class FeaturesController : Controller
    {
        private readonly ArtTopContext _context;

        public FeaturesController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/Features
        public async Task<IActionResult> Index()
        {
              return View(await _context.Features.ToListAsync());
        }

        // GET: Administrative/Features/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var feature = await _context.Features
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // GET: Administrative/Features/Create
        public IActionResult Create()
        {
            return View(new Feature());
        }

        // POST: Administrative/Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicTitle,EnglishTitle,Icon")] Feature feature, IFormFile? Iconfile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(feature, Iconfile);
                if(feature==null||feature.Id==0)
                _context.Add(feature);
                else
                    _context.Update(feature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feature);
        }

        // GET: Administrative/Features/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Features == null)
            {
                return NotFound();
            }

            var feature = await _context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            return View("Create",feature);
        }

        // POST: Administrative/Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicTitle,EnglishTitle,Icon")] Feature feature)
        {
            if (id != feature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureExists(feature.Id))
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
            return View(feature);
        }



        // POST: Administrative/Features/Delete/5
        [ActionName("Delete")]
      
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Features == null)
            {
                return Problem("Entity set 'ArtTopContext.Features'  is null.");
            }
            var feature = await _context.Features.FindAsync(id);
            if (feature != null)
            {
                _context.Features.Remove(feature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureExists(int id)
        {
          return _context.Features.Any(e => e.Id == id);
        }
        private void UploadImages(Feature feature,  IFormFile? Iconfile)
        {
            Helper h = new Helper();
            feature.Icon = h.saveimage(Iconfile, feature.Icon == "" || feature.Icon == null ? "features-inner-01.svg" : feature.Icon);
        }
    }
}
