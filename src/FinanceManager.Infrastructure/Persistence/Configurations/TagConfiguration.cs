using FinanceManager.Domain.TagAggregate;
using FinanceManager.Domain.TagAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.Persistence.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            ConfigureTagsTable(builder);
        }

        private void ConfigureTagsTable(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => TagId.Create(value));

            builder.Property(t => t.Name)
                .HasMaxLength(25);

            builder.Property(t => t.Color)
                .HasMaxLength(7);

            builder.HasOne(t => t.Account);
            builder.HasMany(t => t.Movements);
        }
    }
}
