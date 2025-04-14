using Moq;
using ProductCategory.Application.Service;
using ProductCategory.Data.Interface;
using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Test.TestServices
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> _repositoryMock;
        private readonly CategoryService _service;

        public CategoryServiceTests()
        {
            _repositoryMock = new Mock<ICategoryRepository>();
            _service = new CategoryService(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnCategoryDto_WhenCategoryExists()
        {
            // Arrange
            var category = new Category(1, "Books");
            _repositoryMock.Setup(r => r.GetById(1)).ReturnsAsync(category);

            // Act
            var result = await _service.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Books", result.CategoryName);
        }

        [Fact]
        public async Task GetById_ShouldReturnNull_WhenCategoryDoesNotExist()
        {
            _repositoryMock.Setup(r => r.GetById(1)).ReturnsAsync((Category)null!);
            var result = await _service.GetById(1);
            Assert.Null(result);
        }

        [Fact]
        public async Task Add_ShouldReturnTrue_WhenSaveChangesSucceeds()
        {
            var dto = new CategoryDto { CategoryName = "New Category" };
            _repositoryMock.Setup(r => r.SaveChanges()).ReturnsAsync(true);

            var result = await _service.Add(dto);

            _repositoryMock.Verify(r => r.Add(It.IsAny<Category>()), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task Update_ShouldReturnFalse_WhenCategoryNotFound()
        {
            _repositoryMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Category)null!);

            var result = await _service.Update(1, new CategoryDto());

            Assert.False(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnFalse_WhenCategoryNotFound()
        {
            _repositoryMock.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Category)null!);

            var result = await _service.Delete(1);

            Assert.False(result);
        }
    }
}
