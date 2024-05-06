using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Features.UserTypes.Domain;

namespace StockMarket.Features.UserTypes.Infrastructure;

public class UserTypeConfiguration : IEntityTypeConfiguration<UserType>
{
    public void Configure(EntityTypeBuilder<UserType> builder)
    {
        builder.ToTable("appusertype");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
            userTypeId => userTypeId.Value,
            value => new UserTypeId(value)
            )
            .HasColumnName("id");

        builder.Property(p => p.Name)
            .HasColumnName("name");
    }
}
