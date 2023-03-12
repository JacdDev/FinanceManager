using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Persistence.Configurations
{
    public class MovementConfiguration : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            ConfigureMovementsTable(builder);
        }
        private void ConfigureMovementsTable(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("Movements");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MovementId.Create(value));

            builder.Property(m => m.Concept)
                    .HasMaxLength(250);

            builder.Property(m => m.Amount);

            builder.Property(m => m.IsIncoming);

            builder.Property(m => m.ExecutionDate);

            builder.HasOne(m => m.Account);
            builder.HasMany(m => m.Tags);
        }

    }
}