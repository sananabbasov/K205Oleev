﻿using K205Oleev.Data;
using K205Oleev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {
        private readonly OleevDbContext _context;

        public AboutController(OleevDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var about = _context.AboutLanguages.Include(x=>x.About).Where(x=>x.LangCode=="AZ").ToList();
            return View(about);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL)
        {
            About about = new()
            {
                PhotoURL = PhotoURL,
                CreatedDate = DateTime.Now,
            };

            _context.Abouts.Add(about);
            _context.SaveChanges();
            for (int i = 0; i < Description.Count; i++)
            {
                AboutLanguage aboutLanguage = new()
                {
                    Title = Title[i],
                    Description = Description[i],
                    LangCode = LangCode[i],
                    SEO = SEO[i],
                    AboutID = about.ID
                };
                _context.AboutLanguages.Add(aboutLanguage);

            }


            _context.SaveChanges();




            return RedirectToAction(nameof(Index));
        }
    }
}