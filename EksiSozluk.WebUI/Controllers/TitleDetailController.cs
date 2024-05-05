using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using EksiSozluk.WebUI.Dto.TitleDtos;
using Microsoft.IdentityModel.Tokens;

namespace EksiSozluk.WebUI.Controllers
{
    public class TitleDetailController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public TitleDetailController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IActionResult> Index(string channelName, string titleId)
        {
            ViewBag.ChannelName = channelName;
            ViewBag.TitleId = titleId;
            var values = await _httpClientServiceAction.InvokeAsync<TitleWithEntriesDto>($"Titles/GetTitleByFilterWithEntries?id={titleId}");
            return titleId.IsNullOrEmpty() ? View() : View(values);
        }
    }
}
