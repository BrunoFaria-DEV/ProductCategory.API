using Microsoft.EntityFrameworkCore;
using ProductCategory.Domain.Entity;

namespace ProductCategory.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {}
    }
}