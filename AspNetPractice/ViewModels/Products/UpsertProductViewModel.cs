using AspNetPractice.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AspNetPractice.ViewModels.Products
{
    public class UpsertProductViewModel
    {
        public ProductInputModel Product { get; set; }
        public IDictionary<int, string> Categories { get; set; }

        public UpsertProductViewModel(IDictionary<int, string> categories)
        {
            Categories = categories;
        }

        public UpsertProductViewModel(ProductInputModel product, IDictionary<int, string> categories)
        {
            Product = product;
            Categories = categories;
        }
    }
}
