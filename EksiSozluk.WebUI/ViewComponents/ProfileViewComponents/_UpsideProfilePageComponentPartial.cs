using EksiSozluk.WebUI.Dto.ProfileDtos;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.ViewComponents.ProfileViewComponents
{
    public class _UpsideProfilePageComponentPartial : ViewComponent
    {
        public  IViewComponentResult Invoke()
        {
            var values = TempData["profileStats"];
            return View(values);
        }
    }
}
