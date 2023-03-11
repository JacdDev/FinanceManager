using FinanceManager.Domain.AccountAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Domain.MovementAggregate;
using FinanceManager.Domain.MovementAggregate.ValueObjects;
using FinanceManager.Domain.TagAggregate;
using FinanceManager.Domain.AccountAggregate.ValueObjects;

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