using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Entity;
using ProdutoCategory.Data.Context;
using ProdutoCategory.Data.Interface;

namespace ProdutoCategory.Data.Repository
{
    public class ProductRepository(ApplicationContext context) : IProductRepository
    {
        private readonly ApplicationContext _context = context;

        public async Task<List<Product>> Get()
        {
            return await _context.Product.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Product.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetByName(string name)
        {
            return await _context.Product.AsNoTracking().Where(p => EF.Functions.Like(p.Name, $"%{name}%")).ToListAsync();
        }

        public void Add(Product product)
        {
            _context.Product.Add(product);
        }

        public void Update(Product product)
        {
            _context.Product.Update(product);
        }

        public void Delete(Product product)
        {
            _context.Product.Remove(product);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
