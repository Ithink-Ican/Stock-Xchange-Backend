using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Currencies.Domain;

namespace StockMarket.Features.Accounts.Infrastructure.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("account");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasConversion(
                accountId => accountId.Value,
                value => new AccountId(value)
            )
            .HasColumnName("id");

        builder.Property(a => a.TraderId).HasConversion(
            traderId => traderId.Value,
            value => new TraderId(value)
            )
            .HasColumnName("trader_id");

        builder.Property(a => a.CurrencyId).HasConversion(
            currencyId => currencyId.Value,
            value => new CurrencyId(value)
            )
            .HasColumnName("currency_id");

        builder.Property(a => a.Balance)
            .HasColumnType("decimal")
            .HasPrecision(12, 2)
            .HasColumnName("balance");

        builder.HasOne<Currency>()
                .WithMany()
                .HasForeignKey(c => c.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_currency_id_fkey");

        builder.HasOne<Trader>()
                .WithMany()
                .HasForeignKey(t => t.TraderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_trader_id_fkey");
    }
}
