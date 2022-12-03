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
    public class ProjectsController : Controller
    {
        private readonly ArtTopContext _context;

        public ProjectsController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/Projects
        public async Task<IActionResult> Index()
        {
            var artTopContext = _context.Projects.Include(p => p.Service);
            return View(await artTopContext.ToListAsync());
        }

        // GET: Administrative/Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Administrative/Projects/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle");
            return View(new Project()); ;
        }

        // POST: Administrative/Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArabicTitle,EnglishTitle,ArabicDetails,EnglishDetails,CoverImage,ServiceId,Client,ClientLogo,DeliveryDate")] Project project, IFormFile? CoverImagefile,IFormFile? ClientLogoFile)
        {
            if (ModelState.IsValid)
            {
                UploadImages(project, CoverImagefile, ClientLogoFile);
                if (project == null || project.Id == 0)
                    _context.Add(project);
                else
                    _context.Update(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", project.ServiceId);
            return View(project);
        }

        // GET: Administrative/Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "EnglishTitle", project.ServiceId);
            return View("create",project);
        }

        // POST: Administrative/Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArabicTitle,EnglishTitle,ArabicDetails,EnglishDetails,CoverImage,ServiceId")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "ArabicDetails", project.ServiceId);
            return View(project);
        }

       
        

        // POST: Administrative/Projects/Delete/5
        [ActionName("Delete")]
    
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'ArtTopContext.Projects'  is null.");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return _context.Projects.Any(e => e.Id == id);
        }
        private void UploadImages(Project project, IFormFile? CoverImagefile, IFormFile? ClientLogoFile)
        {
            Helper h = new Helper();
            project.CoverImage = h.saveimage(CoverImagefile, project.CoverImage == "" || project.CoverImage == null ? "service-01.jpg" : project.CoverImage);
            project.ClientLogo = h.saveimage(ClientLogoFile, project.ClientLogo == "" || project.ClientLogo == null ? "sultan-military-city-logo.png" : project.ClientLogo);
        }
    }
}
