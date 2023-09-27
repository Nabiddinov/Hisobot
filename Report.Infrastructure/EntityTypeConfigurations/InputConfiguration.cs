using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Domain.Entities;

namespace Report.Infrastructure.EntityTypeConfigurations;

public sealed class InputConfiguration : IEntityTypeConfiguration<Input>
{
    public void Configure(EntityTypeBuilder<Input> builder)
    {
        builder.ToTable("Inputs");

        builder.HasKey(input => input.Id);

        builder
            .Property(input => input.Summa)
            .IsRequired(true);

        builder
            .Property(input => input.Comment)
            .HasMaxLength(200)
            .IsRequired(false);

    }
}
