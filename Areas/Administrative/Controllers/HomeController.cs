using ArtTop.Data;
using ArtTop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArtTop.Areas.Administrative.Controllers
{
    [Area("Administrative")]
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ArtTopContext _context;

        public HomeController(ArtTopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult SiteSetting()
        {
            SiteSetting Setting = _context.SiteSettings.FirstOrDefault();
            return View();
        }
        public ActionResult About()
        {
           
            return View();
        }

        public ActionResult NewsLetter()
        {

            return View(_context.NewsLetters.OrderByDescending(x=>x.Created_at).ToList());
        }
        public ActionResult Booking()
        {

            return View(_context.Bookings.Include("Office").Include("Doctor").OrderByDescending(x => x.Id).ToList());
        }
        public ActionResult BookDetails(int Id)
        {

            return View(_context.Bookings.Include("Office").Include("Doctor").FirstOrDefault(x=>x.Id==Id));
        }

        // Get: Administrative/Clients/Delete/5
        [ActionName("DeleteBook")]

        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'ArtTopContext.Bookings'  is null.");
            }
            var book = await _context.Bookings.FindAsync(id);
            if (book != null)
            {
                _context.Bookings.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Booking));
        }
    }
}
