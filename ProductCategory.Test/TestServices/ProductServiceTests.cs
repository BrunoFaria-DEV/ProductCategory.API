using Moq;
using ProductCategory.Application.Service;
using ProductCategory.Data.Interface;
using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Test.TestServices
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetById_ReturnsProductDto_WhenExists()
        {
            // Arrange
            var product = new Product("Produto Teste", "Descrição");
            _mockRepo.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync(product);

            // Act
            var result = await _service.GetById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(product.Name, result.Name);
        }

        [Fact]
        public async Task Add_ReturnsTrue_WhenProductIsValid()
        {
            // Arrange
            var productDto = new ProductDto
            {
                Name = "Produto Novo",
                Description = "Descrição do Produto"
            };
            _mockRepo.Setup(r => r.SaveChanges()).ReturnsAsync(true);

            // Act
            var result = await _service.Add(productDto);

            // Assert
            Assert.True(result);
            _mockRepo.Verify(r => r.Add(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public async Task Update_ReturnsFalse_WhenProductNotFound()
        {
            _mockRepo.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Product)null);

            var result = await _service.Update(1, new ProductDto());

            Assert.False(result);
        }

        [Fact]
        public async Task Delete_ReturnsFalse_WhenProductNotFound()
        {
            _mockRepo.Setup(r => r.GetById(It.IsAny<int>())).ReturnsAsync((Product)null);

            var result = await _service.Delete(1);

            Assert.False(result);
        }
    }
}
