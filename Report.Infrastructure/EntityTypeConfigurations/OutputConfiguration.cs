using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Domain.Entities;

namespace Report.Infrastructure.EntityTypeConfigurations;

public sealed class OutputConfiguration : IEntityTypeConfiguration<Output>
{
    public void Configure(EntityTypeBuilder<Output> builder)
    {
        builder.ToTable("Output");

        builder.HasKey(output => output.Id);

        builder
           .Property(output => output.Summa)
           .IsRequired(true);

        builder
            .Property(output => output.Comment)
            .HasMaxLength(200)
            .IsRequired(false);
    }
}
