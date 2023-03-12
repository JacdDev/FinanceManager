using FinanceManager.Domain.AccountAggregate;
using FinanceManager.Domain.AccountAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Persistence.Configurations
{
    public class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            ConfigureAccountsTable(builder);
            ConfigureAccountUserIdsTable(builder);
        }

        private void ConfigureAccountUserIdsTable(EntityTypeBuilder<Account> builder)
        {
            builder.OwnsMany(x => x.Users, ub =>
            {
                ub.ToTable("AccountUserIds");

                ub.WithOwner().HasForeignKey("AccountId");

                ub.HasKey("Id");

                ub.Property(ui => ui.Value)
                    .HasColumnName("UserId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Account.Users))?
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureAccountsTable(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => AccountId.Create(value));

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(250);

            builder.Property(x => x.Amount);

            builder.HasMany(a => a.Movements);
            builder.HasMany(a => a.Tags);
        }
    }
}
