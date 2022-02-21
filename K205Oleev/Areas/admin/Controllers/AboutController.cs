using K205Oleev.Data;
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
            var about = _context.AboutLanguages.Include(x=>x.About).Where(x=>x.LangCode=="Az").ToList();
            return View(about);
        }
    }
}
