using EksiSozluk.WebUI.Dto.TitleDtos;
using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EksiSozluk.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _MainCoverUILayoutComponentPartial : ViewComponent
    {
        private readonly HttpClientServiceViewComponent _httpClientServiceVC;

        public _MainCoverUILayoutComponentPartial(HttpClientServiceViewComponent httpClientServiceVC)
        {
            _httpClientServiceVC = httpClientServiceVC;
        }

        public async Task<IViewComponentResult> InvokeAsync(string channelName)
        {
            channelName = ViewBag.ChannelName;
            return channelName.IsNullOrEmpty() ? await _httpClientServiceVC.InvokeAsync<List<TitleDto>>("Titles?channelName=gündem") 
                : await _httpClientServiceVC.InvokeAsync<List<TitleDto>>($"Titles?channelName={channelName}");
        }
    }
}
