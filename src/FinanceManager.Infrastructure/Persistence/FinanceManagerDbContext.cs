using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.TagAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Persistence
{
    public class FinanceManagerDbContext : IdentityDbContext
    {
        public FinanceManagerDbContext(DbContextOptions<FinanceManagerDbContext> options)
            : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Movement> Movements { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfigurationsFromAssembly(typeof(FinanceManagerDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
