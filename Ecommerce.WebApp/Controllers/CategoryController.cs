using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models;
using Ecommerce.WebApp.Models.CategoryList;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebApp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        }

        public IActionResult Index(Category category)
        {
            var categories = _categoryRepository.GetAll();
            ICollection<CategoryListItem> categoryModels = categories.Select(c => new CategoryListItem()
            {
                Id = c.Id,
                Name = c.Name,
                CategoryCode = c.CategoryCode,

            }).ToList();
            var categoryListModel = new CategoryListViewModel();
            categoryListModel.CategoryList = categoryModels;
            return View(categoryListModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryCreate model)
        {

            if (ModelState.IsValid)
            {
                var category = new Category()
                {
                    Name = model.Name,
                    CategoryCode = model.CategoryCode,
          
                };
                //Database operations 
                bool isSuccess = _categoryRepository.Add(category);

                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }

            }

            return View();

        }
    }
}
