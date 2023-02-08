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
            ConfgureAccountsTable(builder);
            ConfgureAccountUserIdsTable(builder);
            ConfgureAccountMovementIdsTable(builder);
        }

        private void ConfgureAccountMovementIdsTable(EntityTypeBuilder<Account> builder)
        {
            builder.OwnsMany(x => x.Movements, ui =>
            {
                ui.ToTable("AccountMovementIds");

                ui.WithOwner().HasForeignKey("AccountId");

                ui.HasKey("Id");

                ui.Property(x => x.Value)
                    .HasColumnName("MovementId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Account.Movements))?
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfgureAccountUserIdsTable(EntityTypeBuilder<Account> builder)
        {
            builder.OwnsMany(x => x.Users, ui =>
            {
                ui.ToTable("AccountUserIds");

                ui.WithOwner().HasForeignKey("AccountId");

                ui.HasKey("Id");

                ui.Property(x => x.Value)
                    .HasColumnName("UserId")
                    .ValueGeneratedNever();
            });

            builder.Metadata.FindNavigation(nameof(Account.Users))?
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfgureAccountsTable(EntityTypeBuilder<Account> builder)
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
        }
    }
}
