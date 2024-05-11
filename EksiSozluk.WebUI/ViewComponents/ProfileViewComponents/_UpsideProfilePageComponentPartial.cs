using EksiSozluk.WebUI.Dto.ProfileDtos;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.ViewComponents.ProfileViewComponents
{
    public class _UpsideProfilePageComponentPartial : ViewComponent
    {
        public  IViewComponentResult Invoke(ProfileStatsDto profileStatsDto)
        {
            var values = profileStatsDto;
            return View(values);
        }
    }
}
