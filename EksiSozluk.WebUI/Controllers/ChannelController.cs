using EksiSozluk.WebUI.Dto.ChannelDtos;
using EksiSozluk.WebUI.Dto.FollowChannelDtos;
using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

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
            var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var followedChannels = await _httpClientServiceAction.InvokeAsync<List<ResultFollowChannelDto>>($"FollowChannels/GetFollowChannelsByFilter?userId={userId}");

            var values = await _httpClientServiceAction.InvokeAsync<List<ResultChannelsDto>>($"Channels/GetChannels");

            if (!userId.IsNullOrEmpty())
            {
                Parallel.ForEach(values, value =>
            {
                if (followedChannels.IsNullOrEmpty())
                    return;
                Parallel.ForEach(followedChannels, fc =>
                {
                    if (value.Id == fc.ChannelId)
                        value.IsFollowedByUser = true;
                });
            });
            }

            var orderedValues = values.OrderByDescending(x => x.IsFollowedByUser).ToList();
            return View(orderedValues);
        }

        public async Task<IActionResult> UnfollowChannel(string channelId)
        {
            var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _httpClientServiceAction.RemoveAsync($"FollowChannels/UnfollowChannel?channelId={channelId}&userId={userId}");
            return RedirectToAction("Index", "Channel");
        }

        public async Task<IActionResult> FollowChannel(string channelId)
        {
            var userId = HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!userId.IsNullOrEmpty())
            {
                CreateFollowChannelDto createFollowChannelDto = new()
                {
                    ChannelId = Guid.Parse(channelId),
                    UserId = userId,
                    FollowDate = DateTime.Now
                };

                await _httpClientServiceAction.CreateAsync<CreateFollowChannelDto>("FollowChannels/FollowChannel", createFollowChannelDto);

                return RedirectToAction("Index", "Channel");
            }
            return RedirectToAction("Index", "Channel");
        }
    }
}
