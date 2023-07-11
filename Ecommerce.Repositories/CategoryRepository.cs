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
    }
}
