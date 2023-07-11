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
    }
}
