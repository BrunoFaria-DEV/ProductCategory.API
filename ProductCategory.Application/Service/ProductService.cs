using ProductCategory.Application.Interface;
using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;
using ProdutoCategory.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Application.Service
{
    public class ProductService(IProductsRepository _repository) : IProductService
    {
        public async Task<List<ProductDto>> Get()
        {
            var entities = await _repository.Get();
            List<ProductDto> dto = [];
            //automapper
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    dto.Add(
                            new ProductDto() { Name = item.Name, Description = item.Description }
                        );
                };
            }
            //automapper
            return dto;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var entity = await _repository.GetById(id);
            var dto = new ProductDto() { Id = entity.Id, Name =entity.Name, Description = entity.Description };
            return dto;
        }

        public async Task<List<ProductDto>> GetByName(string name)
        {
            var entities = await _repository.GetByName(name);
            List<ProductDto> dto = [];
            //automapper
            if (entities != null)
            {
                foreach (var item in entities)
                {
                    dto.Add(
                            new ProductDto() { Name = item.Name, Description = item.Description }
                        );
                };
            }
            //automapper
            return dto;
        }

        public async Task<bool> Add(ProductDto dto)
        {
            Product entity = new Product(dto.Name, dto.Description);
            _repository.Add(entity);
            return await _repository.SaveChanges();
        }

        public void Update(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
