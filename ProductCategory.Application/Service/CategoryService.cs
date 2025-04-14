using ProductCategory.Application.Extensions;
using ProductCategory.Application.Interface;
using ProductCategory.Data.Interface;
using ProductCategory.Data.Paginate;
using ProductCategory.Domain.Dto;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Application.Service
{
    public class CategoryService(ICategoryRepository repository) : ICategoryService
    {
        private readonly ICategoryRepository _repository = repository;

        public async Task<CategoryPaginatedDto> Get(int pageNumber, int pageSize)
        {
            var query = _repository.Get();

            var paginateResult = await SimplePaginations.CompletePaginate(query, pageNumber, pageSize);
            if (!paginateResult.Items.Any())
                return new CategoryPaginatedDto();

            var categoryPaginatedDto = new CategoryPaginatedDto()
            {
                Categories = paginateResult.Items.ToCategoryDto().ToList(),
                TotalItems = paginateResult.TotalItems,
                TotalPages = paginateResult.TotalPages,
                CurrentPage = paginateResult.CurrentPage,
                PageSize = paginateResult.PageSize,
            };

            return categoryPaginatedDto;
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await _repository.GetById(id);
            if (category == null)
                return null;

            var categoryDto = category.ToCategoryDto();
            return categoryDto;
        }

        public async Task<CategoryPaginatedDto> GetByName(string categoryName, int pageNumber, int pageSize)
        {
            var query = _repository.GetByName(categoryName);

            var paginateResult = await SimplePaginations.CompletePaginate(query, pageNumber, pageSize);
            if (!paginateResult.Items.Any())
                return new CategoryPaginatedDto();

            var categoryPaginatedDto = new CategoryPaginatedDto()
            {
                Categories = paginateResult.Items.ToCategoryDto().ToList(),
                TotalItems = paginateResult.TotalItems,
                TotalPages = paginateResult.TotalPages,
                CurrentPage = paginateResult.CurrentPage,
                PageSize = paginateResult.PageSize,
            };

            return categoryPaginatedDto;
        }


        public async Task<bool> Add(CategoryDto categoryDto)
        {
            Category category = new Category(categoryDto.CategoryName);
            _repository.Add(category);
            return await _repository.SaveChanges();
        }

        public async Task<bool> Update(int id, CategoryDto categoryDto)
        {
            var category = await _repository.GetById(id);
            if (category == null)
                return false;

            category.Update(categoryDto.CategoryName);
            _repository.Update(category);
            return await _repository.SaveChanges();
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _repository.GetById(id);
            if (category == null)
                return false;

            _repository.Delete(category);
            return await _repository.SaveChanges();
        }
    }
}