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
    public class ContactItemsController : Controller
    {
        private readonly ArtTopContext _context;

        public ContactItemsController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/ContactItems
        public async Task<IActionResult> Index()
        {
              return View(await _context.ContactItem.ToListAsync());
        }

        // GET: Administrative/ContactItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactItem == null)
            {
                return NotFound();
            }

            var contactItem = await _context.ContactItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactItem == null)
            {
                return NotFound();
            }

            return View(contactItem);
        }

        // GET: Administrative/ContactItems/Create
        public IActionResult Create()
        {
            return View(new ContactItem());
        }

        // POST: Administrative/ContactItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EnglishValue,ArabicValue,Icon,Order,ShowInHome")] ContactItem contactItem, IFormFile? Iconfile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(contactItem, Iconfile);
                if(contactItem==null|| contactItem.Id==0)
                _context.Add(contactItem);
                else
                    _context.Update(contactItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactItem);
        }

        // GET: Administrative/ContactItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactItem == null)
            {
                return NotFound();
            }

            var contactItem = await _context.ContactItem.FindAsync(id);
            if (contactItem == null)
            {
                return NotFound();
            }
            return View("Create",contactItem);
        }

        // POST: Administrative/ContactItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EnglishValue,ArabicValue,Icon,Order,ShowInHome")] ContactItem contactItem)
        {
            if (id != contactItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactItemExists(contactItem.Id))
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
            return View(contactItem);
        }

    

        // Get: Administrative/ContactItems/Delete/5
        [ ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactItem == null)
            {
                return Problem("Entity set 'ArtTopContext.ContactItem'  is null.");
            }
            var contactItem = await _context.ContactItem.FindAsync(id);
            if (contactItem != null)
            {
                _context.ContactItem.Remove(contactItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactItemExists(int id)
        {
          return _context.ContactItem.Any(e => e.Id == id);
        }
        private void UploadImages(ContactItem contact,IFormFile? Iconfile)
        {
            Helper h = new Helper();
            contact.Icon = h.saveimage(Iconfile, contact.Icon == "" || contact.Icon == null ? "service-01.jpg" : contact.Icon);
        }
    }
}
