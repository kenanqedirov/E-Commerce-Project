using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComonents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
