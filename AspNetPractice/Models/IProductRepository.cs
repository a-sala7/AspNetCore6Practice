namespace AspNetPractice.Models
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Delete(Product product);
        Task<IEnumerable<Product>> GetAll();
        Task Update(Product product);
        Task<Product?> GetById(int id);
    }
}