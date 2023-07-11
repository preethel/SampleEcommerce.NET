using Ecommerce.Database;
using Ecommerce.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repositories
{
    public class CategoryRepository
    {
        ApplicationDbContext _db;

        public CategoryRepository()
        {
            _db = new ApplicationDbContext();
        }

        public bool Add(Category Category)
        {
            _db.Categories.Add(Category);
            return _db.SaveChanges() > 0;
        }
        public ICollection<Category> GetAll()
        {
            return _db.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == id);
        }
        public bool Update(Category Category)
        {
            _db.Categories.Update(Category);

            return _db.SaveChanges() > 0;
        }
        public bool Delete(Category Category)
        {
            _db.Categories.Remove(Category);
            return _db.SaveChanges() > 0;
        }

    }
}
