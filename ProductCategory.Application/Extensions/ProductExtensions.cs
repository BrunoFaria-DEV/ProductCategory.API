using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Application.Extensions
{
    public static class ProductExtensions
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CategoryId = product.CategoryId,
                Category = product.Category,
            };
        }

        public static IEnumerable<ProductDto> ToProductDto(this IEnumerable<Product> products)
        {
            return products.Select(product => product.ToProductDto());
        }
    }
}
