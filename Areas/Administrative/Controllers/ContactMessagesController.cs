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
    public class ContactMessagesController : Controller
    {
        private readonly ArtTopContext _context;

        public ContactMessagesController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/ContactMessages
        public async Task<IActionResult> Index()
        {
              return View(await _context.ContactMessages.ToListAsync());
        }

        // GET: Administrative/ContactMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContactMessages == null)
            {
                return NotFound();
            }

            var contactMessages = await _context.ContactMessages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactMessages == null)
            {
                return NotFound();
            }
            if (contactMessages.IsRead == false)
            {
                contactMessages.IsRead = true;
                _context.Update(contactMessages);
                _context.SaveChanges();
            }
            return View(contactMessages);
        }

        // GET: Administrative/ContactMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrative/ContactMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Subject,Message,Inserted_at,IsRead")] ContactMessages contactMessages)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactMessages);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactMessages);
        }

        // GET: Administrative/ContactMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContactMessages == null)
            {
                return NotFound();
            }

            var contactMessages = await _context.ContactMessages.FindAsync(id);
            if (contactMessages == null)
            {
                return NotFound();
            }
            return View(contactMessages);
        }

        // POST: Administrative/ContactMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,Subject,Message,Inserted_at,IsRead")] ContactMessages contactMessages)
        {
            if (id != contactMessages.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactMessages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactMessagesExists(contactMessages.Id))
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
            return View(contactMessages);
        }

        // GET: Administrative/ContactMessages/Delete/5
       
        [ ActionName("Delete")]
     
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContactMessages == null)
            {
                return Problem("Entity set 'ArtTopContext.ContactMessages'  is null.");
            }
            var contactMessages = await _context.ContactMessages.FindAsync(id);
            if (contactMessages != null)
            {
                _context.ContactMessages.Remove(contactMessages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactMessagesExists(int id)
        {
          return _context.ContactMessages.Any(e => e.Id == id);
        }
    }
}
