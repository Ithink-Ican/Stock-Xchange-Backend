using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarketApp.Features.Traders.Domain;

namespace StockMarketApp.Features.Traders.Infrastructure;

public class TraderConfiguration : IEntityTypeConfiguration<Trader>
{
    public void Configure(EntityTypeBuilder<Trader> builder)
    {
        builder.ToTable("trader");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
            traderId => traderId.Value,
            value => new TraderId(value)
            )
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .HasColumnName("name");

        builder.Property(p => p.INN).HasConversion(
            inn => inn.Value,
            value => INN.Create(value)
            )


    .HasColumnName("trader_id");
    }
}
