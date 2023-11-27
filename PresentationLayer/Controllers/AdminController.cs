using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICategoryDal _categoryDal;

        public AdminController(ICategoryService categoryService, IProductService productService, ICategoryDal categoryDal)
        {
            _categoryService = categoryService;
            _productService = productService;
            _categoryDal = categoryDal;
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

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category, IFormFile imageFile)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", "png" };
            var extension = Path.GetExtension(imageFile.FileName);
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

            if(imageFile != null)
            {
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Geçerli bir resim türü seçiniz.");
                }
            }

            if (ModelState.IsValid)
            {
                using(var stream=new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                category.CategoryImage = randomFileName;
                _categoryService.TInsert(category);
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }


        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {
            var values = _categoryService.TGetById(id);
            return View("CategoryDeleteConfirm", values);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id, int CategoryId)
        {
            var values = _categoryService.TGetById(id);
            _categoryService.TDelete(values);
            return RedirectToAction("CategoryList");
        }
    }
}
