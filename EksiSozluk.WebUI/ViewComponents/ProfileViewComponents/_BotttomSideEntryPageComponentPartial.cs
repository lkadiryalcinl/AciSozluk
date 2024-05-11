using EksiSozluk.WebUI.Dto.ProfileDtos;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.ViewComponents.ProfileViewComponents
{
    public class _BotttomSideEntryPageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(List<TitleWithEntryDto> myentries)
        {
            var values = myentries;
            return View(values);
        }
    }
}