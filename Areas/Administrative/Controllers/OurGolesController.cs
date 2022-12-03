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
    public class OurGolesController : Controller
    {
        private readonly ArtTopContext _context;

        public OurGolesController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/OurGoles
        public async Task<IActionResult> Index()
        {
              return View(await _context.OurGoles.ToListAsync());
        }



        // GET: Administrative/OurGoles/Create
        public IActionResult Create()
        {
            return View(new OurGoles());
        }

        // POST: Administrative/OurGoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicTitle,EnglishTitle,Icon,Order")] OurGoles ourGoles, IFormFile IconFile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(ourGoles, IconFile);
                if(ourGoles != null&& ourGoles.Id==0)
                 _context.Add(ourGoles);
                else
                    _context.Update(ourGoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourGoles);
        }

        // GET: Administrative/OurGoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OurGoles == null)
            {
                return NotFound();
            }

            var ourGoles = await _context.OurGoles.FindAsync(id);
            if (ourGoles == null)
            {
                return NotFound();
            }
            return View("Create", ourGoles);
        }

        // POST: Administrative/OurGoles/Edit/5
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
            if (_context.OurGoles == null)
            {
                return Problem("Entity set 'ArtTopContext.OurGoles'  is null.");
            }
            var ourGoles = await _context.OurGoles.FindAsync(id);
            if (ourGoles != null)
            {
                _context.OurGoles.Remove(ourGoles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurGolesExists(int id)
        {
          return _context.OurGoles.Any(e => e.Id == id);
        }
        private void UploadImages(OurGoles ourGoles, IFormFile? Iconfile)
        {
            Helper h = new Helper();
            ourGoles.Icon = h.saveimage(Iconfile, ourGoles.Icon == "" || ourGoles.Icon == null ? "features-inner-01.svg" : ourGoles.Icon);
        }
    }
}
