using ProdutoCategory.Data.Interface;
using ProdutoCategory.Data.Repository;

namespace ProductCategory.API.Dependencies
{
    public static class DependencyInjection
    {
        public static void Injectable(this IServiceCollection service)
        {
            service.AddScoped<IProductsRepository, ProductsRepository>();
        }
    }
}