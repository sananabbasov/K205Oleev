using DataAccess;
using Entities;
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

        public void CreateAbout(List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL)
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
        }
    }
}
