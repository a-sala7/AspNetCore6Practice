namespace AspNetPractice.Models
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
    }
}