using ProductCategory.Application.Extensions;
using ProductCategory.Application.Interface;
using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;
using ProdutoCategory.Data.Interface;

namespace ProductCategory.Application.Service
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public async Task<List<ProductDto>> Get()
        {
            var products = await _repository.Get();
            if (!products.Any())
                return new List<ProductDto>();

            var productsDto = products.ToDto().ToList();
            return productsDto;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
                return null;

            var productDto = product.ToDto();
            return productDto;
        }

        //public async Task<List<ProductDto>> GetByName(string name, int pageNumber, int pageSize)
        //{
        //    var products = await _repository.GetByName(name, pageNumber, pageSize);
        //    if (!products.Any())
        //        return new List<ProductDto>();

        //    var productsDto = products.ToDto().ToList();
        //    return productsDto;
        //}

        public async Task<ProductPaginatedDto> GetByName(string name, int pageNumber, int pageSize)
        {
            var totalPages = (int)Math.Ceiling((double)await _repository.CountByName(name) / pageSize);

            var products = await _repository.GetByName(name, pageNumber, pageSize);
            if (!products.Any())
                return new ProductPaginatedDto();

            var productsPaginatedDto = products.ToPaginatedDto(totalPages, pageNumber, pageSize);
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