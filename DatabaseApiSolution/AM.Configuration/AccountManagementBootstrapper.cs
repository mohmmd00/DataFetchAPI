using AM.Application;
using AM.Application.Contracts.AccountAgg;
using AM.Infrastructure.EFCore;
using AM.Infrastructure.EFCore.Repository;
using AM_Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AM.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services , string connectionstring)
        {
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IAccountApplication, AccountApplication>();

            services.AddDbContext<AccountContext>(options => options.UseSqlServer(connectionstring));
        }
    }
}
