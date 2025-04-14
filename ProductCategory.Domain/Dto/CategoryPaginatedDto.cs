namespace ProductCategory.Domain.Dto
{
    public class CategoryPaginatedDto
    {
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
