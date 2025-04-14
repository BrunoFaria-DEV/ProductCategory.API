using ProductCategory.Application.Interface;
using Moq;
using ProductCategory.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using ProductCategory.Domain.Dto;

namespace ProductCategory.Test.TestControllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockService;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _mockService = new Mock<IProductService>();
            _controller = new ProductController(_mockService.Object);
        }

        [Fact]
        public async Task Get_ReturnsOk_WhenProductsExist()
        {
            var mockResult = new ProductPaginatedDto
            {
                Products = new List<ProductDto> { new ProductDto { Id = 1, Name = "Produto 1", Description = "Descrição" } },
                TotalItems = 1,
                PageSize = 10,
                CurrentPage = 1,
                TotalPages = 1
            };

            _mockService.Setup(s => s.Get(1, 10)).ReturnsAsync(mockResult);

            var result = await _controller.Get(1, 10);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(mockResult, okResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenNoProductsExist()
        {
            _mockService.Setup(s => s.Get(1, 10)).ReturnsAsync(new ProductPaginatedDto());

            var result = await _controller.Get(1, 10);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenProductExists()
        {
            var product = new ProductDto { Id = 1, Name = "Produto", Description = "Descrição" };
            _mockService.Setup(s => s.GetById(1)).ReturnsAsync(product);

            var result = await _controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(product, okResult.Value);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            _mockService.Setup(s => s.GetById(99)).ReturnsAsync((ProductDto?)null);

            var result = await _controller.GetById(99);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetByName_ReturnsOk_WhenProductsExist()
        {
            var paginated = new ProductPaginatedDto
            {
                Products = new List<ProductDto> { new ProductDto { Id = 1, Name = "Produto", Description = "Descrição" } }
            };
            _mockService.Setup(s => s.GetByName("Produto", 1, 10)).ReturnsAsync(paginated);

            var result = await _controller.GetByName("Produto", 1, 10);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(paginated, okResult.Value);
        }

        [Fact]
        public async Task GetByName_ReturnsNotFound_WhenNoProductsMatch()
        {
            _mockService.Setup(s => s.GetByName("Inexistente", 1, 10)).ReturnsAsync(new ProductPaginatedDto());

            var result = await _controller.GetByName("Inexistente", 1, 10);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Add_ReturnsOk_WhenProductIsValid()
        {
            var product = new ProductDto { Name = "Novo", Description = "Descrição" };
            _mockService.Setup(s => s.Add(product)).ReturnsAsync(true);

            var result = await _controller.Add(product);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(product, okResult.Value);
        }

        [Fact]
        public async Task Add_ReturnsBadRequest_WhenServiceFails()
        {
            var product = new ProductDto { Name = "Novo", Description = "Descrição" };
            _mockService.Setup(s => s.Add(product)).ReturnsAsync(false);

            var result = await _controller.Add(product);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenUpdateSucceeds()
        {
            var product = new ProductDto { Name = "Atualizado", Description = "Nova Descrição" };
            _mockService.Setup(s => s.Update(1, product)).ReturnsAsync(true);

            var result = await _controller.Update(1, product);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(product, okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsBadRequest_WhenUpdateFails()
        {
            var product = new ProductDto { Name = "Atualizado", Description = "Nova Descrição" };
            _mockService.Setup(s => s.Update(1, product)).ReturnsAsync(false);

            var result = await _controller.Update(1, product);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenDeleteSucceeds()
        {
            _mockService.Setup(s => s.Delete(1)).ReturnsAsync(true);

            var result = await _controller.Delete(1);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_WhenDeleteFails()
        {
            _mockService.Setup(s => s.Delete(1)).ReturnsAsync(false);

            var result = await _controller.Delete(1);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
