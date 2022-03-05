using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AboutLanguageServices
    {
        private readonly OleevDbContext _context;

        public AboutLanguageServices(OleevDbContext context)
        {
            _context = context;
        }

        //public void Edit(int AboutID, int LangID, string Title, string Description, string LangCode, string PhotoURL)
        //{
        //    SEO seo = new();

        //    About about = new()
        //    {
        //        ID = AboutID,
        //        CreatedDate = DateTime.Now,
        //        PhotoURL = PhotoURL,
        //    };

        //    _context.Abouts.Update(about);


        //    AboutLanguage aboutLanguage = new()
        //    {
        //        ID = LangID,
        //        Title = Title,
        //        Description = Description,
        //        SEO = seo.SeoURL(Title),
        //        LangCode = LangCode,
        //        AboutID = AboutID

        //    };

        //    var updatedEntity = _context.Entry(aboutLanguage);
        //    updatedEntity.State = EntityState.Modified;
        //    _context.SaveChanges();
        //}
    }
}
