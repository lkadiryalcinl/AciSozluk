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
            var values = channelName.IsNullOrEmpty() ? await _httpClientServiceVC.InvokeAsyncVal<List<TitleDto>>("Titles/GetTitleByFilter?channelName=debe") 
                : await _httpClientServiceVC.InvokeAsyncVal<List<TitleDto>>($"Titles/GetTitleByFilter?channelName={channelName}");
            
            return View(values);
        }
    }
}
