using Microsoft.AspNetCore.Mvc;

namespace K205Oleev.Controllers
{
    public class TranslateController : Controller
    {
        public IActionResult Index(string lang)
        {
            CookieOptions cookieOptions = new();
            cookieOptions.Path = lang;
            return View();
        }
    }
}
