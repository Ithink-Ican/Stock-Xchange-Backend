using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarketApp.Features.Issuers.Domain;

namespace StockMarketApp.Features.Issuers.Infrastructure;
public class IssuerConfiguration : IEntityTypeConfiguration<Issuer>
{
    public void Configure(EntityTypeBuilder<Issuer> builder)
    {
        builder.ToTable("issuer");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasConversion(
                issuerId => issuerId.Value,
                value => new IssuerId(value)
            )
            .HasColumnName("id");

        builder.Property(i => i.Name)
            .HasColumnName("name");

        builder.Property(i => i.Description)
            .HasColumnName("description");
    }
}