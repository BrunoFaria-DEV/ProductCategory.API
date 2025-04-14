using Moq;
using ProductCategory.API.Controllers;
using ProductCategory.Application.Interface;
using ProductCategory.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ProductCategory.Test.TestControllers
{
    public class CategoryControllerTests
    {
        private readonly Mock<ICategoryService> _categoryServiceMock;
        private readonly CategoryController _controller;

        public CategoryControllerTests()
        {
            _categoryServiceMock = new Mock<ICategoryService>();
            _controller = new CategoryController(_categoryServiceMock.Object);
        }

        [Fact]
        public async Task Get_ReturnsOk_WhenCategoriesExist()
        {
            // Arrange
            var categories = new CategoryPaginatedDto
            {
                Categories = new List<CategoryDto> { new() { Id = 1, CategoryName = "Eletrônicos" } },
                TotalItems = 1,
                TotalPages = 1,
                CurrentPage = 1,
                PageSize = 10
            };

            _categoryServiceMock.Setup(x => x.Get(1, 10)).ReturnsAsync(categories);

            // Act
            var result = await _controller.Get(1, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(categories, okResult.Value);
        }

        [Fact]
        public async Task Get_ReturnsNotFound_WhenNoCategoriesExist()
        {
            // Arrange
            _categoryServiceMock.Setup(x => x.Get(1, 10))
                .ReturnsAsync(new CategoryPaginatedDto());

            // Act
            var result = await _controller.Get(1, 10);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenCategoryExists()
        {
            var category = new CategoryDto { Id = 1, CategoryName = "Roupas" };

            _categoryServiceMock.Setup(x => x.GetById(1))
                .ReturnsAsync(category);

            var result = await _controller.GetById(1);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(category, okResult.Value);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenCategoryDoesNotExist()
        {
            _categoryServiceMock.Setup(x => x.GetById(999))
                .ReturnsAsync((CategoryDto)null);

            var result = await _controller.GetById(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetByName_ReturnsOk_WhenMatchesFound()
        {
            var paged = new CategoryPaginatedDto
            {
                Categories = new List<CategoryDto> { new() { Id = 1, CategoryName = "Comida" } }
            };

            _categoryServiceMock.Setup(x => x.GetByName("Comida", 1, 10)).ReturnsAsync(paged);

            var result = await _controller.GetByName("Comida", 1, 10);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(paged, okResult.Value);
        }

        [Fact]
        public async Task GetByName_ReturnsNotFound_WhenNoMatches()
        {
            _categoryServiceMock.Setup(x => x.GetByName("Nada", 1, 10))
                .ReturnsAsync(new CategoryPaginatedDto());

            var result = await _controller.GetByName("Nada", 1, 10);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Add_ReturnsOk_WhenSuccess()
        {
            var category = new CategoryDto { CategoryName = "Livros" };

            _categoryServiceMock.Setup(x => x.Add(category)).ReturnsAsync(true);

            var result = await _controller.Add(category);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(category, okResult.Value);
        }

        [Fact]
        public async Task Add_ReturnsBadRequest_WhenFail()
        {
            var category = new CategoryDto { CategoryName = "Falha" };

            _categoryServiceMock.Setup(x => x.Add(category)).ReturnsAsync(false);

            var result = await _controller.Add(category);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenSuccess()
        {
            var category = new CategoryDto { CategoryName = "Atualizada" };

            _categoryServiceMock.Setup(x => x.Update(1, category)).ReturnsAsync(true);

            var result = await _controller.Update(1, category);

            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(category, okResult.Value);
        }

        [Fact]
        public async Task Update_ReturnsBadRequest_WhenFail()
        {
            var category = new CategoryDto { CategoryName = "Falha" };

            _categoryServiceMock.Setup(x => x.Update(1, category)).ReturnsAsync(false);

            var result = await _controller.Update(1, category);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenSuccess()
        {
            _categoryServiceMock.Setup(x => x.Delete(1)).ReturnsAsync(true);

            var result = await _controller.Delete(1);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_WhenFail()
        {
            _categoryServiceMock.Setup(x => x.Delete(1)).ReturnsAsync(false);

            var result = await _controller.Delete(1);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
