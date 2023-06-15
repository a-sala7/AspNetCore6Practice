using Microsoft.EntityFrameworkCore;

namespace AspNetPractice.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _db.Categories.ToListAsync();
        }
    }
}
