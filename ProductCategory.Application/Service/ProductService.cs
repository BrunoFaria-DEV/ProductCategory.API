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
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public async Task<List<ProductDto>> Get()
        {
            var products = await _repository.Get();
            List<ProductDto> productDto = new List<ProductDto>();
            //automapper
            if (products != null)
            {
                foreach (var item in products)
                {
                    productDto.Add(
                            new ProductDto() { Id = item.Id, Name = item.Name, Description = item.Description }
                        );
                };
            }
            //automapper
            return productDto;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _repository.GetById(id);
            //automapper
            var productDto = new ProductDto() { Id = product.Id, Name =product.Name, Description = product.Description };
            //automapper
            return productDto;
        }

        public async Task<List<ProductDto>> GetByName(string name)
        {
            var products = await _repository.GetByName(name);
            List<ProductDto> productDto = [];
            //automapper
            if (products != null)
            {
                foreach (var item in products)
                {
                    productDto.Add(
                            new ProductDto() { Id = item.Id, Name = item.Name, Description = item.Description }
                        );
                };
            }
            //automapper
            return productDto;
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
            {
                return false;
            }
            //automapper
            product.Update(productDto.Name, productDto.Description);
            //automapper

            _repository.Update(product);

            return await _repository.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _repository.GetById(id);
            if (product == null)
            {
                return false;
            }

            _repository.Delete(product);

            return await _repository.SaveChanges();
        }
    }
}