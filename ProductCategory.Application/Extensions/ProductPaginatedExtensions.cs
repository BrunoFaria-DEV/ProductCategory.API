using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Application.Extensions
{
    public static class ProductPaginatedExtensions
    {
        public static ProductDto ToPaginatedDto(this Product product)
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

        public static ProductPaginatedDto ToPaginatedDto(this IEnumerable<Product> products, int totalPages, int pageNumber, int pageSize)
        {
            return new ProductPaginatedDto()
            {
                Products = products.Select(product => product.ToPaginatedDto()).ToList(),
                CurrentPage = pageNumber,
                TotalPages = totalPages,
                PageSize = pageSize
            };
        }
    }
}
