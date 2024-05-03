using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComonents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
