using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
