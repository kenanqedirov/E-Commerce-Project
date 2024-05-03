using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComonents.UILayoutViewComponents
{
    public class _TopBarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
