using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SM.Application;
using SM.Application.Contracts.ProductAgg;
using SM.Application.Contracts.ProductCategoryAgg;
using SM.Domain.ProductAgg;
using SM.Domain.ProductCategoryAgg;
using SM.Infrastructure.EFCore;
using SM.Infrastructure.EFCore.Repository;

namespace SM.Configuration
{
    public class StoreManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();


            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();



            services.AddDbContext<StoreContext>(x => x.UseSqlServer(connectionstring));
        }

    }
}
