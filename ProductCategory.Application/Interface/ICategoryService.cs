using ProductCategory.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategory.Application.Interface
{
    public interface ICategoryService
    {
        Task<CategoryPaginatedDto> Get(int pageNumber, int pageSize);
        Task<CategoryDto> GetById(int id);
        Task<CategoryPaginatedDto> GetByName(string categoryName, int pageNumber, int pageSize);
        Task<bool> Add(CategoryDto dto);
        Task<bool> Update(int id, CategoryDto dto);
        Task<bool> Delete(int id);
    }
}
