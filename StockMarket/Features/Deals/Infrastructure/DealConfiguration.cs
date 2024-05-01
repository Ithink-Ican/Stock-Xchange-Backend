using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarketApp.Features.Deals.Domain;
using StockMarketApp.Features.Offers.Domain;

namespace StockMarketApp.Features.Deals.Infrastructure;

public class DealConfiguration : IEntityTypeConfiguration<Deal>
{
    public void Configure(EntityTypeBuilder<Deal> builder)
    {
        builder.ToTable("deal");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasConversion(
                dealId => dealId.Value,
                value => new DealId(value)
            )
            .HasColumnName("id");

        builder.Property(d => d.SellOfferId).HasConversion(
            sellOfferId => sellOfferId.Value,
            value => new OfferId(value)
            )
            .HasColumnName("sell_offer_id");

        builder.Property(d => d.BuyOfferId).HasConversion(
            buyOfferId => buyOfferId.Value,
            value => new OfferId(value)
            )
            .HasColumnName("buy_offer_id");

        builder.Property(d => d.DealDate).HasColumnName("deal_date");

        builder.HasOne<Offer>()
                .WithMany()
                .HasForeignKey(s => s.SellOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deal_sell_offer_id_fkey");

        builder.HasOne<Offer>()
                .WithMany()
                .HasForeignKey(b => b.BuyOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deal_buy_offer_id_fkey");
    }
}