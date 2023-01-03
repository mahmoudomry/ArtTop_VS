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
    public class FAQsController : Controller
    {
        private readonly ArtTopContext _context;

        public FAQsController(ArtTopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.FAQs.ToList());
        }
        public IActionResult Details(int? id)
        {
            if (id == null || _context.FAQs == null)
            {
                return NotFound();
            }

            var faq = _context.FAQs
                .FirstOrDefault(m => m.Id == id);
            if (faq == null)
            {
                return NotFound();
            }

            return View(faq);
        }
        public IActionResult Create()
        {
            return View(new FAQ());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ArabicTitle,EnglishTitle,ArabicDetails,EnglishDetails")] FAQ faq)
        {
            if (ModelState.IsValid)
            {

                if (faq == null || faq.Id == 0)
                    _context.Add(faq);
                else
                    _context.Update(faq);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(faq);
        }

        // GET: Administrative/StaticPages/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.FAQs == null)
            {
                return NotFound();
            }

            var faq = _context.FAQs.Find(id);
            if (faq == null)
            {
                return NotFound();
            }
            return View("Create", faq);
        }

        [ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FAQs == null)
            {
                return Problem("Entity set 'ArtTopContext.FAQs'  is null.");
            }
            var faq = await _context.FAQs.FindAsync(id);
            if (faq != null)
            {
                _context.FAQs.Remove(faq);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

