
using Entities;
using K205Oleev.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;

namespace K205Oleev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AboutServices _aboutServices;

        public HomeController(ILogger<HomeController> logger, AboutServices aboutServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                AboutLanguages = _aboutServices.GetAll()
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}