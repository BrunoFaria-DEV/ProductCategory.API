using ProductCategory.Domain.Entity;

namespace ProductCategory.Data.Interface
{
    public interface IProductRepository
    {
        IQueryable<Product> Get();
        Task<Product> GetById(int id);
        IQueryable<Product> GetByName(string name);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Task<bool> SaveChanges();
    }
}