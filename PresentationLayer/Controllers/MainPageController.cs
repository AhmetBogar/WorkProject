using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
