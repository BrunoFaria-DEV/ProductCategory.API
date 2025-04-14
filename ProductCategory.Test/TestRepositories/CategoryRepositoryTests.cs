using Microsoft.EntityFrameworkCore;
using ProductCategory.Data.Context;
using ProductCategory.Data.Repository;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Test.TestRepositories
{
    public class CategoryRepositoryTests
    {
        private ApplicationContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new ApplicationContext(options);
        }

        [Fact]
        public async Task AddCategory_ShouldPersist_WhenSaveChangesIsCalled()
        {
            var context = CreateContext();
            var repository = new CategoryRepository(context);
            var category = new Category("Test Category");

            repository.Add(category);
            var result = await repository.SaveChanges();

            Assert.True(result);
            Assert.Single(await context.Category.ToListAsync());
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllCategories()
        {
            var context = CreateContext();
            var repository = new CategoryRepository(context);

            context.Category.AddRange(new Category("Action"), new Category("Adventure"));
            await context.SaveChangesAsync();

            var result = repository.Get().ToList();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnCorrectCategory()
        {
            var context = CreateContext();
            var repository = new CategoryRepository(context);
            var category = new Category("Books");

            context.Category.Add(category);
            await context.SaveChangesAsync();

            var result = await repository.GetById(category.Id);

            Assert.NotNull(result);
            Assert.Equal("Books", result.CategoryName);
        }

        [Fact]
        public async Task Update_ShouldModifyCategoryName()
        {
            var context = CreateContext();
            var repository = new CategoryRepository(context);
            var category = new Category("Old Name");

            context.Category.Add(category);
            await context.SaveChangesAsync();

            category.Update("New Name");
            repository.Update(category);
            await repository.SaveChanges();

            var updated = await repository.GetById(category.Id);
            Assert.Equal("New Name", updated.CategoryName);
        }

        [Fact]
        public async Task Delete_ShouldRemoveCategory()
        {
            var context = CreateContext();
            var repository = new CategoryRepository(context);
            var category = new Category("To Delete");

            context.Category.Add(category);
            await context.SaveChangesAsync();

            repository.Delete(category);
            await repository.SaveChanges();

            var result = await repository.GetById(category.Id);
            Assert.Null(result);
        }

        [Fact]
        public async Task Exists_ShouldReturnTrue_WhenCategoryExists()
        {
            var context = CreateContext();
            var repository = new CategoryRepository(context);
            var category = new Category("Exists");

            context.Category.Add(category);
            await context.SaveChangesAsync();

            var exists = await repository.GetById(category.Id);
            Assert.NotNull(exists);
        }

        [Fact]
        public async Task Exists_ShouldReturnFalse_WhenCategoryDoesNotExist()
        {
            var context = CreateContext();
            var repository = new CategoryRepository(context);

            var exists = await repository.GetById(999);
            Assert.Null(exists);
        }
    }
}
