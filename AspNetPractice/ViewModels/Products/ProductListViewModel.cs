using AspNetPractice.Models;

namespace AspNetPractice.ViewModels.Products
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; }

        public ProductListViewModel(IEnumerable<Product> products)
        {
            Products = products;
        }
    }
}
