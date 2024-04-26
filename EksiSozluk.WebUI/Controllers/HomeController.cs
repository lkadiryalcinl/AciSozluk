using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(string channelName)
        {
            ViewBag.ChannelName = channelName;
            return View();
        }
    }
}
