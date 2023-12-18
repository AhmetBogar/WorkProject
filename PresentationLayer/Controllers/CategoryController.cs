using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
        public IActionResult CategoryProducts(int id)
        {
            var values = _productService.GetProductWithCategoryID(id);
            return View(values);
        }
        public  IActionResult Test()
        {
            return View();
        }
    }
}
