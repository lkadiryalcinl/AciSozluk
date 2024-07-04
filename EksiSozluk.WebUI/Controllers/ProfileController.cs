using EksiSozluk.Domain.Entities;
using EksiSozluk.WebUI.Dto.EntryDtos;
using EksiSozluk.WebUI.Dto.ProfileDtos;
using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EksiSozluk.WebUI.Controllers.ProfileController
{
    public class ProfileController : Controller
    {
        private readonly HttpClientServiceAction _httpClientServiceAction;

        public ProfileController(HttpClientServiceAction httpClientServiceAction)
        {
            _httpClientServiceAction = httpClientServiceAction;
        }

        public async Task<IActionResult> Index(string username)
        {
            var UserID = await _httpClientServiceAction.InvokeAsync<User>($"User/{username}");
            var values = await _httpClientServiceAction.InvokeAsync<List<TitleWithEntryDto>>($"Entry/GetEntriesByFilter?id={UserID.Id}");
            // Find all items to remove
            var itemsToShow = values.Where(x => !x.IsDelete).ToList();
            // Update remaining items
            foreach (var item in itemsToShow)
            {
                item.UserName = username;
                item.UserId = UserID.Id;
            };

            ProfileStatsDto profileStatsDto = new()
            {
                EntryCount = itemsToShow.Count,
                Username = username
            };
            TempData["profileStats"] = profileStatsDto;
            ViewBag.myentries = itemsToShow;
            return View();

        }


        public async Task<IActionResult> RemoveEntry(Guid id)
        {
            var username = HttpContext.User.Identity?.Name;
            RemoveEntryDto removeEntryDto = new()
            {
                Id = id,
            };
            await _httpClientServiceAction.UpdateAsync<RemoveEntryDto>($"Entry/ProfileEntryRemove?id={id}", removeEntryDto);
            return RedirectToAction("Index", new { username });
        }
    }
}
