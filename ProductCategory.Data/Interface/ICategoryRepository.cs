using ProductCategory.Domain.Entity;

namespace ProductCategory.Data.Interface
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Get();
        Task<Category> GetById(int id);
        IQueryable<Category> GetByName(string categoryName);
        void Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Task<bool> SaveChanges();
    }
}
