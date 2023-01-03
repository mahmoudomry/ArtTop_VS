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
    public class SiteSettingsController : Controller
    {
        private readonly ArtTopContext _context;

        public SiteSettingsController(ArtTopContext context)
        {
            _context = context;
        }

        // GET: Administrative/SiteSettings
        public async Task<IActionResult> Index()
        {
              return View(await _context.SiteSettings.ToListAsync());
        }

        // GET: Administrative/SiteSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SiteSettings == null)
            {
                return NotFound();
            }

            var siteSetting = await _context.SiteSettings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteSetting == null)
            {
                return NotFound();
            }

            return View(siteSetting);
        }

        // GET: Administrative/SiteSettings/Create
        public IActionResult Create()
        {
            var siteSetting =  _context.SiteSettings.FirstOrDefault();
            if (siteSetting == null)
            { return View(new SiteSetting());
               
            }
            return View(siteSetting);
           
        }

        // POST: Administrative/SiteSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,HeaderLogo,SiteTitleEn,SiteTitleAr,SiteDescEn,SiteDescAr," +
            "ServiceTitleEn,ServiceTitleAr,ServiceDescEn,ServiceDescAr,FeatureTitleEn," +
            "FeatureTitleAr,FeatureDescEn,FeatureDescAr,FeatureImg1,FeatureImg2," +
            "ProjectTitleEn,ProjectTitleAr,BookingTitleEn,BookingTitleAr,BookingDescEn,BookingDescAr," +
            "Maarooflogo,MaaroofLink,VATlogo,VatLink,CopyRight,Queryphone,ContactArabicTitle,ContactEnglishTitle,ContactDescArabic,ContactDescEnglish")] SiteSetting siteSetting,IFormFile? setting_HeaderLogo, IFormFile? setting_FeatureImg1, IFormFile? setting_FeatureImg2
            , IFormFile? setting_Maarooflogo, IFormFile? setting_VATlogo)
        {
            if (ModelState.IsValid)
            {
                UploadImages(siteSetting, setting_HeaderLogo, setting_FeatureImg1, setting_FeatureImg2, setting_Maarooflogo, setting_VATlogo);
                if (siteSetting.Id == null|| siteSetting.Id == 0)
                _context.Add(siteSetting);
                else
                _context.Update(siteSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),"Home", new { area = "Administrative" });
            }
            return View(siteSetting);
        }
        private void UploadImages(SiteSetting site, IFormFile? setting_HeaderLogo, IFormFile? setting_FeatureImg1, IFormFile? setting_FeatureImg2
            , IFormFile? setting_Maarooflogo, IFormFile? setting_VATlogo)
        {
            Helper h = new Helper(); 
            
                site.HeaderLogo = h.saveimage(setting_HeaderLogo, site.HeaderLogo == "" || site.HeaderLogo == null ? "logo.svg" : site.HeaderLogo);
                site.FeatureImg1 = h.saveimage(setting_FeatureImg1, site.FeatureImg1 == "" || site.FeatureImg1 == null ? "features-img-01.jpg" : site.FeatureImg1);
                site.FeatureImg2 = h.saveimage(setting_FeatureImg2, site.FeatureImg2 == "" || site.FeatureImg2 == null ? "features-img-02.jpg" : site.FeatureImg2);
                site.Maarooflogo = h.saveimage(setting_Maarooflogo, site.Maarooflogo == "" || site.Maarooflogo == null ? "footer-logo-1.png" : site.Maarooflogo);
                site.VATlogo = h.saveimage(setting_VATlogo, site.VATlogo == "" || site.VATlogo == null ? "footer-logo-2.png" : site.VATlogo);
           
        }
       

    }
}
