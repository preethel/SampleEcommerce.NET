using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.UtilityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class ProductRepository
    {
        ApplicationDbContext _db;

        public ProductRepository()
        {
            _db = new ApplicationDbContext();
        }

        public bool Add(Product Product)
        {
            _db.Products.Add(Product);
            return _db.SaveChanges() > 0;
        }

        public bool AddRange(ICollection<Product> Products)
        {
            _db.Products.AddRange(Products);
            return _db.SaveChanges() > 0;
        }

        public bool Update(Product Product)
        {
            _db.Products.Update(Product);

            return _db.SaveChanges() > 0;
        }

        public bool UpdateRange(ICollection<Product> Products)
        {
            _db.Products.UpdateRange(Products);
            return _db.SaveChanges() > 0;
        }

        public bool Delete(Product Product)
        {
            _db.Products.Remove(Product);
            return _db.SaveChanges() > 0;
        }

        public Product GetById(int id)
        {
            return _db.Products.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Product> GetAll()
        {
            return _db.Products.ToList();
        }

        //public ICollection<Product> Search(ProductSearchCriteria searchCriteria)
        //{
        //    var Products = _db.Products.AsQueryable();

        //    if (!string.IsNullOrEmpty(searchCriteria.SearchText))
        //    {
        //        string searchText = searchCriteria.SearchText.ToLower();

        //        Products = Products.Where(c => c.Name.ToLower().Contains(searchText)
        //        || c.Phone.ToLower().Contains(searchText)
        //        || c.Email.ToLower().Contains(searchText));
        //    }


        //    if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Name))
        //    {
        //        Products = Products.Where(c => c.Name.ToLower().Contains(searchCriteria.Name.ToLower()));
        //    }

        //    if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Phone))
        //    {
        //        Products = Products.Where(c => c.Phone.ToLower().Contains(searchCriteria.Phone.ToLower()));
        //    }

        //    if (searchCriteria != null && !string.IsNullOrEmpty(searchCriteria.Email))
        //    {
        //        Products = Products.Where(c => c.Email.ToLower().Contains(searchCriteria.Email.ToLower()));
        //    }



        //    int skipSize = (searchCriteria.CurrentPage - 1) * searchCriteria.PageSize;

        //    return Products.Skip(skipSize).Take(searchCriteria.PageSize).ToList();



        //}
    }
}
