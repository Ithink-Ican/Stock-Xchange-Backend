﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Features.Industries.Domain;

namespace StockMarket.Features.Industries.Infrastructure;

public class IndustryConfiguration : IEntityTypeConfiguration<Industry>
{
    public void Configure(EntityTypeBuilder<Industry> builder)
    {
        builder.ToTable("industry");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasConversion(
                industryId => industryId.Value,
                value => new IndustryId(value)
            )
            .HasColumnName("id");

        builder.Property(i => i.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
    }
}