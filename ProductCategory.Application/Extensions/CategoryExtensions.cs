using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Application.Extensions
{
    public static class CategoryExtensions
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto()
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Products = category.Products
            };
        }

        public static IEnumerable<CategoryDto> ToCategoryDto(this IEnumerable<Category> categories)
        {
            return categories.Select(category => category.ToCategoryDto());
        }
    }
}
