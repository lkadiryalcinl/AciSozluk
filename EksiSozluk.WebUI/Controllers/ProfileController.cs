using EksiSozluk.WebUI.Dto.UserDtos;
using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public ProfileController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public IActionResult Index(string userId)
        {
            var values = _httpClientServiceAction.InvokeAsync<List<UserEntryDto>>($"User/GetEntriesByUserId?={userId}");

            return View();
        }
    }
}
