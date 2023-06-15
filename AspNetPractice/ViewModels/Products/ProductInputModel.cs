using AspNetPractice.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AspNetPractice.ViewModels.Products
{
    public class ProductInputModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(4000)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public static ProductInputModel FromProduct(Product product)
        {
            return new ProductInputModel()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId
            };
        }
    }
}
