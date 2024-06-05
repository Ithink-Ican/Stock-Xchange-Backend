using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockMarket.Features.Accounts.Domain;
using StockMarket.Features.Accounts.Infrastructure.Configuration;
using StockMarket.Features.Currencies.Domain;
using StockMarket.Features.Currencies.Infrastructure;
using StockMarket.Features.Deals.Domain;
using StockMarket.Features.Deals.Infrastructure;
using StockMarket.Features.Industries.Domain;
using StockMarket.Features.Industries.Infrastructure;
using StockMarket.Features.Instruments.Domain;
using StockMarket.Features.Instruments.Infrastructure;
using StockMarket.Features.InstrumentTypes.Domain;
using StockMarket.Features.InstrumentTypes.Infrastructure;
using StockMarket.Features.Issuers.Domain;
using StockMarket.Features.Issuers.Infrastructure;
using StockMarket.Features.Offers.Domain;
using StockMarket.Features.Offers.Infrastructure;
using StockMarket.Features.Portfolios.Domain;
using StockMarket.Features.Portfolios.Infrastructure;
using StockMarket.Features.Traders.Domain;
using StockMarket.Features.Traders.Infrastructure;
using StockMarket.Features.UserTypes.Domain;
using StockMarket.Features.UserTypes.Infrastructure;
using StockMarket.Features.Users.Domain;
using StockMarket.Features.Users.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace StockMarket.Shared.Infrastructure;

public partial class StockMarketAppDbContext : DbContext
{
    public StockMarketAppDbContext()
    {
    }

    public StockMarketAppDbContext(DbContextOptions<StockMarketAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; } = null!;
    //public virtual DbSet<Appuser> Appusers { get; set; } = null!;
    //public virtual DbSet<Appusertype> Appusertypes { get; set; } = null!;
    public virtual DbSet<Currency> Currencies { get; set; } = null!;
    public virtual DbSet<Deal> Deals { get; set; } = null!;
    public virtual DbSet<Industry> Industries { get; set; } = null!;
    public virtual DbSet<Instrument> Instruments { get; set; } = null!;
    public virtual DbSet<InstrumentType> InstrumentTypes { get; set; } = null!;
    public virtual DbSet<Issuer> Issuers { get; set; } = null!;
    public virtual DbSet<Offer> Offers { get; set; } = null!;
    public virtual DbSet<Portfolio> Portfolios { get; set; } = null!;
    public virtual DbSet<Trader> Traders { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;
    public virtual DbSet<UserType> UserTypes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=StockExchange; User Id = postgres; Password = WRTh379Chmpns!;");
        }
    }
    /* protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<decimal>()
            .HavePrecision(12, 2);
    } */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CurrencyConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DealConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IndustryConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InstrumentConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InstrumentTypeConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IssuerConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OfferConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortfolioConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TraderConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserTypeConfiguration).Assembly);

        //modelBuilder.Entity<Appuser>(entity =>
        //{
        //    entity.ToTable("appuser");

        //    entity.Property(e => e.Id).HasColumnName("id");

        //    entity.Property(e => e.Email)
        //        .HasMaxLength(100)
        //        .HasColumnName("email");

        //    entity.Property(e => e.FirstName)
        //        .HasMaxLength(100)
        //        .HasColumnName("first_name");

        //    entity.Property(e => e.LastName)
        //        .HasMaxLength(100)
        //        .HasColumnName("last_name");

        //    entity.Property(e => e.MiddleName)
        //        .HasMaxLength(100)
        //        .HasColumnName("middle_name");

        //    entity.Property(e => e.Password)
        //        .HasMaxLength(100)
        //        .HasColumnName("password");

        //    entity.Property(e => e.PhoneNumber)
        //        .HasMaxLength(100)
        //        .HasColumnName("phone_number");

        //    entity.Property(e => e.SignupDate).HasColumnName("signup_date");

        //    entity.Property(e => e.UserType).HasColumnName("user_type");

        //    entity.Property(e => e.Username)
        //        .HasMaxLength(100)
        //        .HasColumnName("username");

        //    entity.HasOne(d => d.UserTypeNavigation)
        //        .WithMany(p => p.Appusers)
        //        .HasForeignKey(d => d.UserType)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("appuser_user_type_fkey");
        //});

        //modelBuilder.Entity<Appusertype>(entity =>
        //{
        //    entity.ToTable("appusertype");

        //    entity.Property(e => e.Id).HasColumnName("id");

        //    entity.Property(e => e.Name)
        //        .HasMaxLength(100)
        //        .HasColumnName("name");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
