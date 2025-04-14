using ProductCategory.Application.Interface;
using ProductCategory.Application.Service;
using ProductCategory.Data.Interface;
using ProductCategory.Data.Repository;

namespace ProductCategory.API.Configurations
{
    public static class DependencyInjection
    {
        public static void Injectable(this IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<ICategoryService, CategoryService>();
            service.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}