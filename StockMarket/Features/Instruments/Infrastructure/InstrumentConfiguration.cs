using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Features.Industries.Domain;
using StockMarket.Features.Issuers.Domain;

namespace StockMarket.Features.Instruments.Infrastructure;

public class InstrumentConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.ToTable("instrument");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasConversion(
                instrumentId => instrumentId.Value,
                value => new InstrumentId(value)
            )
            .HasColumnName("id");

        builder.Property(i => i.Code).HasConversion(
            code => code.Value,
            value => Code.Create(value)
            )
        .HasColumnName("code");

        builder.Property(i => i.InstrumentTypeId).HasConversion(
            instrumentTypeId => instrumentTypeId.Value,
            value => new InstrumentTypeId(value)
            )
            .HasColumnName("type_id");

        builder.Property(i => i.IndustryId).HasConversion(
            industryId => industryId.Value,
            value => new IndustryId(value)
            )
            .HasColumnName("industry_id");

        builder.Property(i => i.IssuerId).HasConversion(
            issuerId => issuerId.Value,
            value => new IssuerId(value)
            )
            .HasColumnName("issuer_id");

        builder.Property(i => i.IsActive).HasColumnName("is_active");

        builder.HasOne<InstrumentType>()
                .WithMany()
                .HasForeignKey(iT => iT.InstrumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("instrument_type_id_fkey");

        builder.HasOne<Industry>()
                .WithMany()
                .HasForeignKey(iN => iN.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stock_industry_id_fkey");

        builder.HasOne<Issuer>()
                .WithMany()
                .HasForeignKey(iS => iS.IssuerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("issuer_id_fkey");
    }
}
