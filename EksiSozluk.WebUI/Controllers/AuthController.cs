using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
