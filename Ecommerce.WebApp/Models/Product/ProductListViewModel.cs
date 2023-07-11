using Ecommerce.Models.UtilityModels;
using Ecommerce.WebApp.Models.CustomerList;

namespace Ecommerce.WebApp.Models.Product
{
    public class ProductListViewModel
    {
        public ProductSearchCriteria ProductSearchCriteria { get; set; }
        public ICollection<ProductListItem> ProductList { get; set; }
    }
}
