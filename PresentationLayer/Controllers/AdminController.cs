using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace PresentationLayer.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICategoryDal _categoryDal;

        public AdminController(ICategoryService categoryService, IProductService productService, ICategoryDal categoryDal, Context context)
        {
            _categoryService = categoryService;
            _productService = productService;
            _categoryDal = categoryDal;
            _context = context;
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

            var extension = "";

            if (imageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", "png" };
                extension = Path.GetExtension(imageFile.FileName);
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Geçerli bir resim türü seçiniz.");
                }
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    category.CategoryImage = randomFileName;
                    _categoryService.TInsert(category);
                    return RedirectToAction("CategoryList");
                }

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
        public async Task<IActionResult> UpdateCategory(Category category, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var extension = Path.GetExtension(imageFile.FileName);
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    category.CategoryImage = randomFileName;
                }
            }

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

        public IActionResult ProductList()
        {
            var values = _productService.GetProductsWithCategory();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product, IFormFile imageFile)
        {

            var extension = "";

            if (imageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", "png" };
                extension = Path.GetExtension(imageFile.FileName);
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Geçerli bir resim türü seçiniz.");
                }
            }

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    product.ProductImage = randomFileName;
                    _productService.TInsert(product);
                    return RedirectToAction("ProductList");
                }

            }
            return View(product);
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            var values = _productService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var extension = Path.GetExtension(imageFile.FileName);
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    product.ProductImage = randomFileName;
                }
            }

            _productService.TUpdate(product);
            return RedirectToAction("ProductList");
        }
    }
}
