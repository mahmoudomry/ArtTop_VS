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
    public class AboutsController : Controller
    {
        private readonly ArtTopContext _context;

        public AboutsController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/Abouts
        public async Task<IActionResult> Index()
        {
              return View(await _context.Abouts.ToListAsync());
        }

        // GET: Administrative/Abouts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Abouts == null)
        //    {
        //        return NotFound();
        //    }

        //    var about = await _context.Abouts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (about == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(about);
        //}

        // GET: Administrative/Abouts/Create
        public IActionResult Create()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about==null?new About():about);
        }

        // POST: Administrative/Abouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicTitle,EnglishTitle,knowus_TitleArabic,knowus_TitleEnglish,knowus_DescArabic,knowus_DescEnglish,knowus_img1,knowus_img2,VisionIcon,VisionTitleArabic,VisionTitleEnglish,VisionDesceArabic,VisionDescEnglish,MissionIcon,MissionTitleArabic,MissionTitleEnglish,MissionDescArabic,MissionDescEnglish,GolesEnglishTitle,GolesArabicTitle")] About about,
            IFormFile?knowus_img1File, IFormFile? knowus_img2File, IFormFile? VisionIconFile, IFormFile? MissionIconFile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(about, knowus_img1File, knowus_img2File, VisionIconFile, MissionIconFile);
                if (about==null||about.Id==0)
                _context.Add(about);
                else
                    _context.Update(about);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home", new { area= "Administrative" });
            }
            return View(about);
        }

        // GET: Administrative/Abouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Abouts == null)
            {
                return NotFound();
            }

            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View("Create",about);
        }

        // POST: Administrative/Abouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicTitle,EnglishTitle,knowus_TitleArabic,knowus_TitleEnglish,knowus_DescArabic,knowus_DescEnglish,knowus_img1,knowus_img2,VisionIcon,VisionTitleArabic,VisionTitleEnglish,VisionDesceArabic,VisionDescEnglish,MissionIcon,MissionTitleArabic,MissionTitleEnglish,MissionDescArabic,MissionDescEnglish,GolesEnglishTitle,GolesArabicTitle")] About about)
        //{
        //    if (id != about.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(about);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AboutExists(about.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(about);
        //}

        //// GET: Administrative/Abouts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Abouts == null)
        //    {
        //        return NotFound();
        //    }

        //    var about = await _context.Abouts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (about == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(about);
        //}

        // GET: Administrative/Abouts/Delete/5
        [ ActionName("Delete")]
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Abouts == null)
            {
                return Problem("Entity set 'ArtTopContext.Abouts'  is null.");
            }
            var about = await _context.Abouts.FindAsync(id);
            if (about != null)
            {
                _context.Abouts.Remove(about);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutExists(int id)
        {
          return _context.Abouts.Any(e => e.Id == id);
        }
        private void UploadImages(About about, IFormFile? knowus_img1File, IFormFile? knowus_img2File, IFormFile? VisionIconFile, IFormFile? MissionIconFile)
        {
            Helper h = new Helper();
            about.knowus_img1 = h.saveimage(knowus_img1File, about.knowus_img1 == "" || about.knowus_img1 == null ? "features-inner-01.svg" : about.knowus_img1);
            about.knowus_img2 = h.saveimage(knowus_img2File, about.knowus_img2 == "" || about.knowus_img2 == null ? "features-inner-01.svg" : about.knowus_img2);
            about.VisionIcon = h.saveimage(VisionIconFile, about.VisionIcon == "" || about.VisionIcon == null ? "features-inner-01.svg" : about.VisionIcon);
            about.MissionIcon = h.saveimage(MissionIconFile, about.MissionIcon == "" || about.MissionIcon == null ? "features-inner-01.svg" : about.MissionIcon);
        }
    }
}
