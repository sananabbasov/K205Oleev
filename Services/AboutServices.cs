﻿using DataAccess;
using Entities;
using Helper.Methods;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AboutServices
    {
        private readonly OleevDbContext _context;

        public AboutServices(OleevDbContext context)
        {
            _context = context;
        }

        public List<AboutLanguage> GetAll()
        {
            var about = _context.AboutLanguages.Include(x=>x.About).Where(x=>x.LangCode == "AZ").ToList();
            return about;
        }

        public void CreateAbout(string Title, string Description, string LangCode, string SEO, string PhotoURL)
        {
            About about = new()
            {
                PhotoURL = PhotoURL,
                CreatedDate = DateTime.Now,
            };

            _context.Abouts.Add(about);
            _context.SaveChanges();
            
                AboutLanguage aboutLanguage = new()
                {
                    Title = Title,
                    Description = Description,
                    LangCode = LangCode,
                    SEO = SEO,
                    AboutID = about.ID
                };
                _context.AboutLanguages.Add(aboutLanguage);
            
            
            _context.SaveChanges();
        }


        public List<AboutLanguage> GetAboutLanguages(int id)
        {
            return _context.AboutLanguages.Where(x=>x.About.ID == id).ToList();
        }

        public About GetAboutById(int id)
        {
            return _context.Abouts.FirstOrDefault(x=>x.ID == id);
        }

        public void Edit(About about, int AboutID, int LangID, string Title, string Description, string LangCode, string PhotoURL)
        {
            SEO seo = new();

            about.PhotoURL = PhotoURL;

            _context.Abouts.Update(about);

            AboutLanguage aboutLanguage = new()
            {
                ID = LangID,
                Title = Title,
                Description = Description,
                SEO = seo.SeoURL(Title),
                LangCode = LangCode,
                AboutID = AboutID

            };

            var updatedEntity = _context.Entry(aboutLanguage);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
