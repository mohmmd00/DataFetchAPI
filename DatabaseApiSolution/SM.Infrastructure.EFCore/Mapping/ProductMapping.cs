using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SM.Domain.ProductAgg;

namespace SM.Infrastructure.EFCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ProductName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.ProductDescription).HasMaxLength(500).IsRequired();

            builder.HasOne(x =>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductCategoryId);
        }
    }
}
