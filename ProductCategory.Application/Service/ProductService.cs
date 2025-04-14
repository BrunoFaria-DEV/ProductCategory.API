using ProductCategory.Application.Extensions;
using ProductCategory.Application.Interface;
using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;
using ProductCategory.Data.Interface;
using ProductCategory.Data.Paginate;

namespace ProductCategory.Application.Service
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public async Task<ProductPaginatedDto> Get(int pageNumber, int pageSize)
        {
            var query = _repository.Get();

            var paginateResult = await SimplePaginations.CompletePaginate(query, pageNumber, pageSize);
            if (!paginateResult.Items.Any())
                return new ProductPaginatedDto();

            var productsPaginatedDto = new ProductPaginatedDto()
            {
                Products = paginateResult.Items.ToProductDto().ToList(),
                TotalItems = paginateResult.TotalItems,
                TotalPages = paginateResult.TotalPages,
                CurrentPage = paginateResult.CurrentPage,
                PageSize = paginateResult.PageSize,
            };

            return productsPaginatedDto;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
                return null;

            var productDto = product.ToProductDto();
            return productDto;
        }

        public async Task<ProductPaginatedDto> GetByName(string name, int pageNumber, int pageSize)
        {
            var query = _repository.GetByName(name);

            var paginateResult = await SimplePaginations.CompletePaginate(query, pageNumber, pageSize);
            if (!paginateResult.Items.Any())
                return new ProductPaginatedDto();

            var productsPaginatedDto = new ProductPaginatedDto()
            {
                Products = paginateResult.Items.ToProductDto().ToList(),
                TotalItems = paginateResult.TotalItems,
                TotalPages = paginateResult.TotalPages,
                CurrentPage = paginateResult.CurrentPage,
                PageSize = paginateResult.PageSize,
            };

            return productsPaginatedDto;
        }


        public async Task<bool> Add(ProductDto productDto)
        {
            Product product = new Product(productDto.Name, productDto.Description);
            _repository.Add(product);
            return await _repository.SaveChanges();
        }

        public async Task<bool> Update(int id, ProductDto productDto)
        {
            var product = await _repository.GetById(id);
            if (product == null) 
                return false;
            
            product.Update(productDto.Name, productDto.Description);
            _repository.Update(product);
            return await _repository.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
                return false;
            
            _repository.Delete(product);
            return await _repository.SaveChanges();
        }
    }
}