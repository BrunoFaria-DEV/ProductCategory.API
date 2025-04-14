using Microsoft.EntityFrameworkCore;

namespace ProductCategory.Data.Paginate
{
    public static class SimplePaginations
    {
        public static IQueryable<T> Paginate<T>(IQueryable<T> query, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;

            return query
                   .Skip((pageNumber - 1) * pageSize)
                   .Take(pageSize);
        }
        public static async Task<PaginatedResult<T>> CompletePaginate<T>(IQueryable<T> query, int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var items = await query
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

            return new PaginatedResult<T>(items, totalItems, totalPages, pageNumber, pageSize);
        }
    }
}