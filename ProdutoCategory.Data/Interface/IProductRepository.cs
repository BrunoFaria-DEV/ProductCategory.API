using ProductCategory.Domain.Entity;

namespace ProdutoCategory.Data.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> Get();
        Task<Product> GetById(int id);
        Task<List<Product>> GetByName(string name, int pageNumber, int pageSize);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Task<int> Count();
        Task<int> CountByName(string name);
        Task<bool> SaveChanges();
    }
}