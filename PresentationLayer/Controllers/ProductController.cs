using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductDetails(int id)
        {
            var values = _productService.GetProductById(id);
            return View(values);
        }
        public PartialViewResult ProductDetailsOthers()
        {
            return PartialView();
        }
    }
}
