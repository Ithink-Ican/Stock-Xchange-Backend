using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarketApp.Features.Portfolios.Domain;
using StockMarketApp.Features.Traders.Domain;
using StockMarketApp.Features.Instruments.Domain;

namespace StockMarketApp.Features.Portfolios.Infrastructure;

public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
{
    public void Configure(EntityTypeBuilder<Portfolio> builder)
    {
        builder.ToTable("portfolio");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
                portfolioId => portfolioId.Value,
                value => new PortfolioId(value)
            )
            .HasColumnName("id");

        builder.Property(p => p.TraderId).HasConversion(
            traderId => traderId.Value,
            value => new TraderId(value)
            )
            .HasColumnName("trader_id");

        builder.Property(p => p.InstrumentId).HasConversion(
            instrumentId => instrumentId.Value,
            value => new InstrumentId(value)
            )
            .HasColumnName("instrument_id");

        builder.Property(p => p.Amount)
            .HasColumnName("amount");

        builder.HasOne<Instrument>()
                .WithMany()
                .HasForeignKey(i => i.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("portfolio_instrument_id_fkey");

        builder.HasOne<Trader>()
                .WithMany()
                .HasForeignKey(t => t.TraderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("portfolio_trader_id_fkey");
    }
}
