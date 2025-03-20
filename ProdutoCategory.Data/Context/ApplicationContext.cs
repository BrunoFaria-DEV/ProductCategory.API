using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Entity;
using ProdutoCategory.Data.EntityConfiguration;

namespace ProdutoCategory.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* To automatically map based on the application's assembly and save lines of code, use: modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly); */

            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
        }
    }
}