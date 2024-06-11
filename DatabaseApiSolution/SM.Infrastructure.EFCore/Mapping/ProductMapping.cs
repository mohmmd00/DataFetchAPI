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

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Quantity).HasMaxLength(20).IsRequired();
            builder.Property(x=>x.Price).HasMaxLength(20).IsRequired();


            builder.HasOne(x =>x.Category).WithMany(x=>x.Products).HasForeignKey(x=>x.ProductCategoryId);
        }
    }
}
