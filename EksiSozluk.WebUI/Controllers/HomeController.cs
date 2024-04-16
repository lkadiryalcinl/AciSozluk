using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
