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
    public class StaticPagesController : Controller
    {
        private readonly ArtTopContext _context;

        public StaticPagesController(ArtTopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View( _context.StaticPages.ToList());
        }
        public  IActionResult Details(int? id)
        {
            if (id == null || _context.StaticPages == null)
            {
                return NotFound();
            }

            var page =  _context.StaticPages
                .FirstOrDefault(m => m.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            return View(page);
        }
        public IActionResult Create()
        {
            return View(new StaticPage());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ArabicTitle,EnglishTitle,ArabicDetails,EnglishDetails")] StaticPage page)
        {
            if (ModelState.IsValid)
            {
             
                if (page == null || page.Id == 0)
                    _context.Add(page);
                else
                    _context.Update(page);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(page);
        }

        // GET: Administrative/StaticPages/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.StaticPages == null)
            {
                return NotFound();
            }

            var page =  _context.StaticPages.Find(id);
            if (page == null)
            {
                return NotFound();
            }
            return View("Create", page);
        }
    }
}
