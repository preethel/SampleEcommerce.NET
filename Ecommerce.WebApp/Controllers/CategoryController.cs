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
        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                ViewBag.Error = "Please provide valid id.";
                return View(); 
            }

            var category = _categoryRepository.GetById((int)id);

            if(category == null)
            {
                ViewBag.Error = "Sorry, no category found for this id.";
                return View();
            }

            var model = new CategoryEditVM()
            {
                Id = category.Id,
                Name = category.Name,
                CategoryCode = category.CategoryCode
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditVM model)
        {
            if(ModelState.IsValid)
            {
                var category = _categoryRepository.GetById(model.Id);

                if(category == null)
                {
                    ViewBag.Error = "category not found to update!";
                    return View(model);
                }

                category.Name = model.Name;
                category.CategoryCode = model.CategoryCode;
             

                bool isSuccess = _categoryRepository.Update(category);
                if (isSuccess)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                ViewBag.Error = "Please provide valid id.";
                return View();
            }

            var category = _categoryRepository.GetById((int)id);

            if (category == null)
            {
                ViewBag.Error = "Sorry, no product found for this id.";
                return View();
            }
            bool isSuccess = _categoryRepository.Delete(category);
            if (isSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
