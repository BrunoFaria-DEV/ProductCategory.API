using ProductCategory.Domain.Entity;

namespace ProdutoCategory.Data.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> Get();
        Task<Product> GetById(int id);
        Task<List<Product>> GetByName(string name);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Task<bool> SaveChanges();
    }
}