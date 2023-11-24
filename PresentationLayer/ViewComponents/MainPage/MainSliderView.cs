using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MainPage
{
    public class MainSliderView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
