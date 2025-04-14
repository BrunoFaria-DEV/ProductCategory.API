namespace ProductCategory.Data.Paginate
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
 
        public PaginatedResult(IEnumerable<T> items, int totalItems, int totalPages, int currentPage, int pageSize)
        {
            Items = items;
            TotalItems = totalItems;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }

        public PaginatedResult()
        {
            Items = new List<T>();
        }
    }
}
