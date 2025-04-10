using ProductCategory.Domain.Entity;

namespace ProductCategory.Domain.Dto
{
    public class ProductPaginatedDto
    {
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public bool HasNextPage => CurrentPage < TotalPages;
        public bool HasPreviousPage => CurrentPage > 1;
    }
}
