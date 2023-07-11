using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using Ecommerce.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.WebApp.Models.Product;

namespace Ecommerce.WebApp.Controllers
{
    public class ProductController : Controller
    {

        ProductRepository _productRepository;
        
        CategoryRepository _categoryRepository;

        public ProductController()
        {
            _categoryRepository = new CategoryRepository();
            _productRepository = new ProductRepository();
        }

        public IActionResult Index(Product product)
        {
            var products = _productRepository.GetAll();
            ICollection<ProductListItem> productModels = products.Select(c => new ProductListItem()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                CategoryId = c.CategoryId,  
                Category = c.Category,

            }).ToList();
            var productListModel = new ProductListViewModel();
            productListModel.ProductList = productModels;
            return View(productListModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductCreate model)
        {

            if (ModelState.IsValid)
            {
                var categories = _categoryRepository.GetAll();
                
                var product = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId,
                };
                //Database operations 
                bool isSuccess = _productRepository.Add(product);

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

            var product = _productRepository.GetById((int)id);

            if (product == null)
            {
                ViewBag.Error = "Sorry, no product found for this id.";
                return View();
            }

            var model = new ProductEditVM()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductEditVM model)
        {
            if (ModelState.IsValid)
            {
                var product = _productRepository.GetById(model.Id);

                if (product == null)
                {
                    ViewBag.Error = "Customer not found to update!";
                    return View(model);
                }

                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;


                bool isSuccess = _productRepository.Update(product);
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

            var product = _productRepository.GetById((int)id);
            
            if (product == null)
            {
                ViewBag.Error = "Sorry, no product found for this id.";
                return View();
            }
            bool isSuccess = _productRepository.Delete(product);
            if (isSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
