using ProductCategory.Domain.Dto;

namespace ProductCategory.Application.Interface
{
    public interface IProductService
    {
        Task<List<ProductDto>> Get();
        Task<ProductDto> GetById(int id);
        Task<List<ProductDto>> GetByName(string name);
        Task<bool> Add(ProductDto dto);
        Task<bool> Update(int id, ProductDto dto);
        Task<bool> Delete(int id);
    }
}
