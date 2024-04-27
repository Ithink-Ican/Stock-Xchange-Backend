using Domain.Currencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasConversion(
            currencyId => currencyId.Value,
            value => new CurrencyId(value));
        builder.Property(p => p.IntCode)
            .HasConversion<int>()
            .HasMaxLength(3)
            ;
        builder.Property(p => p.ChrCode)
            .HasConversion<String>()
            .HasMaxLength(3);
        builder.Property(p => p.Amount).HasConversion<int>();
        builder.Property(p => p.Name).HasConversion<String>();
        builder.Property(p => p.Rate)
            .HasConversion<double>()
            .HasPrecision(4);
    }
}
