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
    public class OfficeSocialMediasController : Controller
    {
        private readonly ArtTopContext _context;

        public OfficeSocialMediasController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/OfficeSocialMedias
        public async Task<IActionResult> Index(int? OfficeId)
        {
            if (OfficeId == null)
            {
                var artTopContext = _context.OfficeSocialMedias.Include(o => o.Office);
                return View(await artTopContext.ToListAsync());
            }
            else
            {
                var artTopContext = _context.OfficeSocialMedias.Where(x => x.OfficeId == OfficeId).Include(o => o.Office);
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
                .Include(o => o.Office)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (officeSocialMedia == null)
            {
                return NotFound();
            }

            return View(officeSocialMedia);
        }

        // GET: Administrative/OfficeSocialMedias/Create
        public IActionResult Create(int? OfficeId)
        {
            if (OfficeId != null)
                ViewData["OfficeId"] = new SelectList(_context.Offices.Where(x => x.Id == OfficeId), "Id", "EnglishTitle");
            else
                ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "EnglishTitle");
            return View(new OfficeSocialMedia());
        }

        // POST: Administrative/OfficeSocialMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfficeId,ArabicTitle,EnglishTitle,Link,Icon,Order")] OfficeSocialMedia officeSocialMedia)
        {
            if (ModelState.IsValid)
            {
                if (officeSocialMedia.Id == 0)
                    _context.Add(officeSocialMedia);
                else
                    _context.Update(officeSocialMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { OfficeId = officeSocialMedia.OfficeId });
            }
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "EnglishTitle", officeSocialMedia.OfficeId);
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
            ViewData["OfficeId"] = new SelectList(_context.Offices, "Id", "EnglishTitle", officeSocialMedia.OfficeId);
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
