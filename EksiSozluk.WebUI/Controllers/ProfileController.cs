using EksiSozluk.Domain.Entities;
using EksiSozluk.WebUI.Dto.EntryDtos;
using EksiSozluk.WebUI.Dto.ProfileDtos;
using EksiSozluk.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EksiSozluk.WebUI.Controllers
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
            userid = username;
            // Find all items to remove
            var itemsToRemove = values.Where(x => x.IsDelete).ToList();
            // Update remaining items
            foreach (var item in values)
            {
                item.UserName = username;
            }
            // Remove the items outside of the iteration
            foreach (var item in itemsToRemove)
            {
                values.Remove(item);
            }
            ProfileStatsDto profileStatsDto = new()
            {
                EntryCount = values.Count,
                Username = username
            };
            TempData["profileStats"] = profileStatsDto;
            ViewBag.myentries = values;
            return View();



        }




        public static string userid;
        public async Task<IActionResult> RemoveEntry(Guid id)
        {
            RemoveEntryDto removeEntryDto = new();
            await _httpClientServiceAction.UpdateAsync<RemoveEntryDto>($"Entry/ProfileEntryRemove?id={id}", removeEntryDto);
            return RedirectToAction("Index", new { username = userid });
        }
    }
}
