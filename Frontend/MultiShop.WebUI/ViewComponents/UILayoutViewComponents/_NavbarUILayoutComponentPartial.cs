using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComonents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
