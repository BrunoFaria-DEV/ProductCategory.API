using ProductCategory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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