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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(List<string> Title, List<string> Description, List<string> LangCode, List<string> SEO, string PhotoURL)
        {

            return View();
        }
    }
}
