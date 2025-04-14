using ProductCategory.Domain.Dto;

namespace ProductCategory.Application.Interface
{
    public interface IProductService
    {
        Task<ProductPaginatedDto> Get(int pageNumber, int pageSize);
        Task<ProductDto> GetById(int id);
        Task<ProductPaginatedDto> GetByName(string name, int pageNumber, int pageSize);
        Task<bool> Add(ProductDto dto);
        Task<bool> Update(int id, ProductDto dto);
        Task<bool> Delete(int id);
    }
}
