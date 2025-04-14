using Microsoft.EntityFrameworkCore;
using ProductCategory.Data.Context;
using ProductCategory.Data.Interface;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Data.Repository
{
    public class CategoryRepository(ApplicationContext context) : ICategoryRepository
    {
        private readonly ApplicationContext _context = context;

        public IQueryable<Category> Get()
        {
            return _context.Category.AsNoTracking().Include(c => c.Products);
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Category.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public IQueryable<Category> GetByName(string categoryName)
        {
            return _context.Category.AsNoTracking()
                                    .Where(p => p.CategoryName != null && p.CategoryName.Contains(categoryName))
                                    .OrderBy(p => p.Id);
        }

        public void Add(Category category)
        {
            _context.Category.Add(category);
        }

        public void Update(Category category)
        {
            _context.Category.Update(category);
        }

        public void Delete(Category category)
        {
            _context.Category.Remove(category);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
