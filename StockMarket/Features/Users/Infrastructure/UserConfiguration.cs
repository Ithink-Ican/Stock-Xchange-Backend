using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockMarket.Features.Users.Domain;
using StockMarket.Features.UserTypes.Domain;

namespace StockMarket.Features.Users.Infrastructure;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("appuser");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasConversion(
            userId => userId.Value,
            value => new UserId(value)
            )
            .HasColumnName("id");

        builder.Property(p => p.Password)
            .HasColumnName("password");

        builder.Property(p => p.Salt)
            .HasColumnName("salt");

        builder.Property(p => p.Email)
            .HasColumnName("email");

        builder.Property(p => p.Name)
            .HasColumnName("name");

        builder.Property(p => p.SignUpDate)
            .HasColumnType("timestamp")
            .HasColumnName("signup_date");

        builder.Property(p => p.UserTypeId).HasConversion(
            userTypeId => userTypeId.Value,
            value => new UserTypeId(value)
            )
            .HasColumnName("user_type");
    }
}
