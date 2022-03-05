using DataAccess;
using Entities;
using Helper.Methods;
using K205Oleev.Areas.admin.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services;

namespace K205Oleev.Areas.admin.Controllers
{
    [Area("admin")]
    //[Authorize]
    public class AboutController : Controller
    {
        private readonly AboutServices _services;
        private IWebHostEnvironment _environment;

        public AboutController(AboutServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
          var about = _services.GetAll();
            
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

            for (int i = 0; i < Title.Count; i++)
            {
                _services.CreateAbout(Title[i], Description[i], LangCode[i], SEO[i], PhotoURL);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EditVM editVM = new()
            {
                AboutLanguages = _services.GetAboutLanguages(id),
                About = _services.GetAboutById(id)

            };


            return View(editVM);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(About about, int AboutID,List<int> LangID, List<string> Title, List<string> Description, List<string> LangCode, IFormFile Image)
        {

            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }


            for (int i = 0; i < Title.Count; i++)
            {
                _services.Edit(about,AboutID, LangID[i], Title[i], Description[i], LangCode[i], path);
            }
            
            

            

            return RedirectToAction(nameof(Index));
        }
       
    }
}
