using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.ViewComponents.ProfileViewComponents
{
    public class _UpsideProfilePageComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
