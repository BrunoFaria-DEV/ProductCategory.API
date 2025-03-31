using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Application.Extensions
{
    public static class ProductExtensions
    {
        public static ProductDto ToDto(this Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
            };
        }

        public static IEnumerable<ProductDto> ToDto(this IEnumerable<Product> products)
        {
            return products.Select(product => product.ToDto());
        }
    }
}
