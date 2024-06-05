using AM.Infrastructure.EFCore.Mapping;
using AM_Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure.EFCore
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public AccountContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
