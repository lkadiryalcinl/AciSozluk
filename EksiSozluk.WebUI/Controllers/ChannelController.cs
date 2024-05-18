using EksiSozluk.WebUI.Dto.ChannelDtos;
using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.Controllers
{
    public class ChannelController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public ChannelController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _httpClientServiceAction.InvokeAsync<List<ResultChannelsDto>>($"Channels/GetChannels");
            return View(values);
        }
    }
}
