using AspNetPractice.Models;

namespace AspNetPractice.Context
{
    public static class DbInitializer
    {
        public static void Initialize(WebApplication app)
        {
            var db = app
                .Services
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            if(db.Categories.Any() || db.Products.Any())
            {
                return;
            }

            var pcComponentsCategory = new Category("PC Components");
            var cablesAndAccessoriesCategory = new Category("Cables & Accessories");
         
            var products = new Product[]
            {
                new()
                {
                    Name = "Ryzen 5 5600X",
                    Price = 299.99M,
                    Description = "Super fast 6-core 12-thread processor!",
                    ImageUrl = "/images/products/1.png",
                    Category = pcComponentsCategory
                },
                new()
                {
                    Name = "HDMI 2.1 48Gbit 1.5m Cable",
                    Price = 14.99M,
                    Description = "Long desc long desc long desc long desc long desc long desc long desc long desc long desc long desc long desc long desc long desc long desc long desc long desc long desc. END.",
                    ImageUrl = "/images/products/1.png",
                    Category = cablesAndAccessoriesCategory
                },
                new()
                {
                    Name = "USB Type-C male-to-male cable",
                    Price = 4.99M,
                    ImageUrl = "/images/products/1.png",
                    Category = cablesAndAccessoriesCategory
                }
            };

            db.Products.AddRange(products);
            db.SaveChanges();
        }
    }
}
