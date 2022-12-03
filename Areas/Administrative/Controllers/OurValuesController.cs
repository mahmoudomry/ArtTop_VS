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
    public class OurValuesController : Controller
    {
        private readonly ArtTopContext _context;

        public OurValuesController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/OurValues
        public async Task<IActionResult> Index()
        {
              return View(await _context.OurValues.ToListAsync());
        }

        // GET: Administrative/OurValues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OurValues == null)
            {
                return NotFound();
            }

            var ourValues = await _context.OurValues
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourValues == null)
            {
                return NotFound();
            }

            return View(ourValues);
        }

        // GET: Administrative/OurValues/Create
        public IActionResult Create()
        {
            return View(new OurValues());
        }

        // POST: Administrative/OurValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicTitle,EnglishTitle,Icon")] OurValues ourValues,IFormFile IconFile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(ourValues,IconFile);
                if(ourValues!=null&&ourValues.Id==0)
                 _context.Add(ourValues);
                else
                    _context.Update(ourValues);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourValues);
        }

        // GET: Administrative/OurValues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OurValues == null)
            {
                return NotFound();
            }

            var ourValues = await _context.OurValues.FindAsync(id);
            if (ourValues == null)
            {
                return NotFound();
            }
            return View("Create",ourValues);
        }

        // POST: Administrative/OurValues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicTitle,EnglishTitle,Icon")] OurValues ourValues)
        //{
        //    if (id != ourValues.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ourValues);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!OurValuesExists(ourValues.Id))
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
        //    return View(ourValues);
        //}

        // GET: Administrative/OurValues/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.OurValues == null)
        //    {
        //        return NotFound();
        //    }

        //    var ourValues = await _context.OurValues
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ourValues == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ourValues);
        //}

        // POST: Administrative/OurValues/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OurValues == null)
            {
                return Problem("Entity set 'ArtTopContext.OurValues'  is null.");
            }
            var ourValues = await _context.OurValues.FindAsync(id);
            if (ourValues != null)
            {
                _context.OurValues.Remove(ourValues);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurValuesExists(int id)
        {
          return _context.OurValues.Any(e => e.Id == id);
        }
        private void UploadImages(OurValues ourValues, IFormFile? Iconfile)
        {
            Helper h = new Helper();
            ourValues.Icon = h.saveimage(Iconfile, ourValues.Icon == "" || ourValues.Icon == null ? "features-inner-01.svg" : ourValues.Icon);
        }
    }
}
