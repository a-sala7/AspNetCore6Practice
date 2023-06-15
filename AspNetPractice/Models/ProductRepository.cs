using Microsoft.EntityFrameworkCore;

namespace AspNetPractice.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _db
                .Products
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task Add(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            Product? productInDb = await _db
                .Products
                .SingleOrDefaultAsync(p => p.Id == product.Id);

            if(productInDb == null)
            {
                throw new Exception($"Product with ID {product.Id} not found.");
            }
            await _db.SaveChangesAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _db
                .Products
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
