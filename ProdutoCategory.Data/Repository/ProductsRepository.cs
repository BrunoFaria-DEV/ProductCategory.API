using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Entity;
using ProdutoCategory.Data.Context;
using ProdutoCategory.Data.Interface;

namespace ProdutoCategory.Data.Repository
{
    public class ProductsRepository(ApplicationContext context) : IProductsRepository
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

        public void Add(Product entity)
        {
            _context.Product.Add(entity);
        }

        public void Update(Product entity)
        {
            _context.Product.Update(entity);
        }

        public void Delete(Product entity)
        {
            _context.Product.Remove(entity);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
