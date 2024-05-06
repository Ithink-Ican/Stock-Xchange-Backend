using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Features.Users.Domain;
using StockMarket.Features.Traders.Domain;

namespace StockMarket.Features.Traders.Infrastructure;

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
            .HasColumnName("inn");

        builder.Property(i => i.UserId).HasConversion(
                userId => userId.Value,
                value => new UserId(value)
                )
       .HasColumnName("user_id");
    }
}
