using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCategory.Domain.Entity;

namespace ProdutoCategory.Data.EntityConfiguration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product"); /* Observation: The method ToTable requires the "Microsoft.EntityFrameworkCore.Relational" package. */
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(120);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        }
    }
}
