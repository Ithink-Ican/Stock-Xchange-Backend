using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarketApp.Features.InstrumentTypes.Domain;

namespace StockMarketApp.Features.InstrumentTypes.Infrastructure;

internal class InstrumentTypeConfiguration : IEntityTypeConfiguration<InstrumentType>
{
    public void Configure(EntityTypeBuilder<InstrumentType> builder)
    {
        builder.ToTable("instrumenttype");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasConversion(
                instrumentTypeId => instrumentTypeId.Value,
                value => new InstrumentTypeId(value)
            )
            .HasColumnName("id");

        builder.Property(i => i.Name)
            .HasColumnName("name");
    }
}