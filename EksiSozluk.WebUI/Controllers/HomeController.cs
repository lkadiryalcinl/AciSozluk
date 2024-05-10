using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using EksiSozluk.WebUI.Dto.TitleDtos;
using Microsoft.IdentityModel.Tokens;

namespace EksiSozluk.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public HomeController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IActionResult> Index(string channelName)
        {
            ViewBag.ChannelName = channelName;
            var values = channelName.IsNullOrEmpty() ?
                await _httpClientServiceAction.InvokeAsync<List<TitlesWithFirstEntryDto>>($"Titles/GetTitlesByFilterWithFirstEntry?id=gündem")
                : await _httpClientServiceAction.InvokeAsync<List<TitlesWithFirstEntryDto>>($"Titles/GetTitlesByFilterWithFirstEntry?id={channelName}");
            return View(values);
        }
    }
}