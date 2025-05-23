﻿namespace ProductCategory.Domain.Dto
{
    public class ProductPaginatedDto
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
