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
    public class SocialMediasController : Controller
    {
        private readonly ArtTopContext _context;

        public SocialMediasController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/SocialMedias
        public async Task<IActionResult> Index()
        {
              return View(await _context.SocialMedia.ToListAsync());
        }

        // GET: Administrative/SocialMedias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SocialMedia == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialMedia == null)
            {
                return NotFound();
            }

            return View(socialMedia);
        }

        // GET: Administrative/SocialMedias/Create
        public IActionResult Create()
        {
            return View(new SocialMedia());
        }

        // POST: Administrative/SocialMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicTitle,EnglishTitle,Link,Icon,Order")] SocialMedia socialMedia,IFormFile Iconfile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(socialMedia, Iconfile);
                if(socialMedia==null||socialMedia.Id==0)
                _context.Add(socialMedia);
                else
                    _context.Update(socialMedia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialMedia);
        }

        // GET: Administrative/SocialMedias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SocialMedia == null)
            {
                return NotFound();
            }

            var socialMedia = await _context.SocialMedia.FindAsync(id);
            if (socialMedia == null)
            {
                return NotFound();
            }
            return View(socialMedia);
        }

        // POST: Administrative/SocialMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicTitle,EnglishTitle,Link,Icon,Order")] SocialMedia socialMedia)
        {
            if (id != socialMedia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialMedia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialMediaExists(socialMedia.Id))
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
            return View(socialMedia);
        }

        // GET: Administrative/SocialMedias/Delete/5
      
        [ActionName("Delete")]
    
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SocialMedia == null)
            {
                return Problem("Entity set 'ArtTopContext.SocialMedia'  is null.");
            }
            var socialMedia = await _context.SocialMedia.FindAsync(id);
            if (socialMedia != null)
            {
                _context.SocialMedia.Remove(socialMedia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialMediaExists(int id)
        {
          return _context.SocialMedia.Any(e => e.Id == id);
        }
        private void UploadImages(SocialMedia social, IFormFile? Iconfile)
        {
            Helper h = new Helper();
            social.Icon = h.saveimage(Iconfile, social.Icon == "" || social.Icon == null ? "service-01.jpg" : social.Icon);
        }
    }
}
