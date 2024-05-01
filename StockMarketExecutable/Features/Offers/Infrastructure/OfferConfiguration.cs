using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarketApp.Features.Offers.Domain;
using StockMarketApp.Features.Traders.Domain;
using StockMarketApp.Features.Instruments.Domain;
using StockMarketApp.Features.Currencies.Domain;

namespace StockMarketApp.Features.Offers.Infrastructure;

public class OfferConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("offer");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
            .HasConversion(
                offerId => offerId.Value,
                value => new OfferId(value)
            )
            .HasColumnName("id");

        builder.Property(o => o.TraderId).HasConversion(
            traderId => traderId.Value,
            value => new TraderId(value)
            )
            .HasColumnName("trader_id");

        builder.Property(o => o.CurrencyId).HasConversion(
            currencyId => currencyId.Value,
            value => new CurrencyId(value)
            )
            .HasColumnName("currency_id");

        builder.Property(o => o.InstrumentId).HasConversion(
            instrumentId => instrumentId.Value,
            value => new InstrumentId(value)
            )
            .HasColumnName("instrument_id");

        builder.Property(o => o.Amount)
            .HasColumnName("amount");

        builder.Property(a => a.Price)
            .HasPrecision(4)
            .HasColumnType("money")
            .HasColumnName("price");

        builder.Property(o => o.IsSale)
            .HasColumnName("is_sale");

        builder.Property(o => o.IsSale)
            .HasColumnName("is_satisfied");

        builder.Property(e => e.PlacementDate).HasColumnName("placement_date");

        builder.HasOne<Trader>()
                .WithMany()
                .HasForeignKey(t => t.TraderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_trader_id_fkey");

        builder.HasOne<Instrument>()
                .WithMany()
                .HasForeignKey(i => i.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_instrument_id_fkey");

        builder.HasOne<Currency>()
                .WithMany()
                .HasForeignKey(c => c.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_currency_id_fkey");
    }
}

