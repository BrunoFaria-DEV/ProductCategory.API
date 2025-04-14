using Microsoft.EntityFrameworkCore;
using ProductCategory.Data.Context;
using ProductCategory.Data.Repository;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Test.TestRepositories
{
    public class ProductRepositoryTests
    {
        private readonly ApplicationContext _context;
        private readonly ProductRepository _repository;

        public ProductRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationContext(options);
            _repository = new ProductRepository(_context);
        }

        [Fact]
        public async Task AddProduct_ShouldPersist_WhenSaveChangesIsCalled()
        {
            var product = new Product("Produto", "Descrição");

            _repository.Add(product);
            var result = await _repository.SaveChanges();

            Assert.True(result);
            Assert.Single(await _context.Product.ToListAsync());
        }

        [Fact]
        public async Task GetById_ShouldReturnProduct()
        {
            var product = new Product("Produto", "Descrição");
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            var result = await _repository.GetById(product.Id);

            Assert.NotNull(result);
            Assert.Equal("Produto", result.Name);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllProducts()
        {
            _context.Product.AddRange(
                new Product("P1", "D1"),
                new Product("P2", "D2")
            );
            await _context.SaveChangesAsync();

            var result = _repository.Get().ToList();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Update_ShouldModifyProductName()
        {
            var product = new Product("Old", "Desc");
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            product.Update("New", "Updated Desc");
            _repository.Update(product);
            await _repository.SaveChanges();

            var updated = await _repository.GetById(product.Id);
            Assert.Equal("New", updated.Name);
        }

        [Fact]
        public async Task Delete_ShouldRemoveProduct()
        {
            var product = new Product("Produto", "Descrição");
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            _repository.Delete(product);
            var result = await _repository.SaveChanges();

            Assert.True(result);
            Assert.DoesNotContain(await _context.Product.ToListAsync(), p => p.Id == product.Id);
        }

        [Fact]
        public async Task Exists_ShouldReturnTrue_WhenProductExists()
        {
            var product = new Product("Produto", "Descrição");
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            var exists = await _repository.GetById(product.Id);
            Assert.NotNull(exists);
        }

        [Fact]
        public async Task Exists_ShouldReturnFalse_WhenProductDoesNotExist()
        {
            var exists = await _repository.GetById(12345);
            Assert.Null(exists);
        }
    }
}
