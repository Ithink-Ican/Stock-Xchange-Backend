﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Features.Currencies.Domain;

namespace StockMarket.Features.Currencies.Infrastructure;

public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {
        builder.ToTable("currency");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasConversion(
                currencyId => currencyId.Value,
                value => new CurrencyId(value)
            )
            .HasColumnName("id");
        
        builder.Property(c => c.IntCode).HasConversion(
            intCode => intCode.value,
            value => IntCode.Create(value)
            )
            .HasColumnName("int_code");

        builder.Property(c => c.ChrCode).HasConversion(
            chrCode => chrCode.value,
            value => ChrCode.Create(value)
            )
            .HasColumnName("chr_code");

        builder.Property(c => c.Amount)
            .HasColumnName("amount");

        builder.Property(c => c.Name)
            .HasColumnName("name");

        builder.Property(c => c.Rate)
            .HasPrecision(4)
            .HasColumnType("money")
            .HasColumnName("rate");

    }
}
