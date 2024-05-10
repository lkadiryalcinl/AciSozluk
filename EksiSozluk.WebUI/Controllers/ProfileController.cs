using EksiSozluk.Domain.Entities;
using EksiSozluk.WebUI.Dto.ProfileDtos;
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


        public async Task<IActionResult> Index(string username)
        {
            var UserID = await _httpClientServiceAction.InvokeAsync<User>($"User/{username}");
            var values = await _httpClientServiceAction.InvokeAsync<List<TitleWithEntryDto>>($"Entry/GetEntriesByFilter?id={UserID.Id}");

            values.ForEach(x =>
            {
                x.Username = username;
            });
            ViewBag.myentries = values;
            return View();
        }
    }



}
