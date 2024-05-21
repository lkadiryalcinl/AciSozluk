using EksiSozluk.Domain.Entities;
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


        string userid;

        public async Task<IActionResult> Index(string username)
        {
            var UserID = await _httpClientServiceAction.InvokeAsync<User>($"User/{username}");
            var values = await _httpClientServiceAction.InvokeAsync<List<TitleWithEntryDto>>($"Entry/GetEntriesByFilter?id={UserID.Id}");
            userid = username;

            values.ForEach(x =>
            {
                x.UserName = username;
                x.UserId = UserID.Id;
            });

            ProfileStatsDto profileStatsDto = new()
            {
                EntryCount = values.Count(),
                Username = username
            };
            TempData["profileStats"] = profileStatsDto;
            ViewBag.myentries = values;
            return View();
        }

        public async Task<IActionResult> RemoveEntry()
        {
         //   var UserID = await _httpClientServiceAction.InvokeAsync<User>($"User/{username}");




            return RedirectToAction("Index", "Profile",new {username=userid});
        }

    }
}
