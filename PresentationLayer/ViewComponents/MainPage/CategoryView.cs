using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace PresentationLayer.ViewComponents.MainPage
{
    public class CategoryView:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryView(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetList();
            return View(values);
        }
    }
}
