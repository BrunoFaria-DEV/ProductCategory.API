using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Entity;
using ProductCategory.Data.Context;
using ProductCategory.Data.Interface;

namespace ProductCategory.Data.Repository
{
    public class ProductRepository(ApplicationContext context) : IProductRepository
    {
        private readonly ApplicationContext _context = context;

        public IQueryable<Product> Get()
        {
            return _context.Product.AsNoTracking().Include(c => c.Category);
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Product.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<Product> GetByName(string name)
        {
            return _context.Product.AsNoTracking()
                                    .Where(p => p.Name != null && p.Name.Contains(name))
                                    .OrderBy(p => p.Id);
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
