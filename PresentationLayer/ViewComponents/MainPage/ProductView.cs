using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.ViewComponents.MainPage
{
    public class ProductView:ViewComponent
    {
        private readonly IProductService _productService;

        public ProductView(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var values=_productService.TGetList();
            return View(values);
        }
    }
}
