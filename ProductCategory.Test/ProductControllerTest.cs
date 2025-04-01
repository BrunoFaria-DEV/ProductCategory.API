using ProductCategory.Application.Interface;
using Moq;
using ProductCategory.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using ProductCategory.Domain.Dto;

namespace ProductCategory.Test
{
    public class ProductControllerTest
    {
        [Fact] 
        public async Task Get_ReturnOK_WhenProductsExist()
        {
            // Arrange
            var fakeProducts = new List<ProductDto>
            {
                new ProductDto { Id = 1, Name = "Produto1", Description = "Descrição prod 1" },
                new ProductDto { Id = 2, Name = "Produto2", Description = "Descrição prod 2" },
                new ProductDto { Id = 3, Name = "Produto3", Description = "Descrição prod 3" }
            };

            var mockProductService = new Mock<IProductService>();
            var productController = new ProductController(mockProductService.Object);
            var expectedResult = new OkObjectResult(fakeProducts);

            mockProductService.Setup(x => x.Get()).ReturnsAsync(fakeProducts);

            // Act
            var result = await productController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult.Value, okResult.Value);
        }

        [Fact]
        public async Task Get_ReturnNotFound_WhenNoProductsExist()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var productController = new ProductController(mockProductService.Object);

            mockProductService.Setup(x => x.Get()).ReturnsAsync(new List<ProductDto>());

            // Act
            var result = await productController.Get();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
