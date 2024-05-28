using Microsoft.EntityFrameworkCore;
using SM.Domain.ProductAgg;
using SM.Domain.ProductCategoryAgg;
using SM.Infrastructure.EFCore.Mapping;

namespace SM.Infrastructure.EFCore
{
    public class StoreContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }


        public StoreContext(DbContextOptions options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);


            base.OnModelCreating(modelBuilder);
        }

    }
}
