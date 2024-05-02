using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockMarketApp.Features.Accounts.Domain;
using StockMarketApp.Features.Accounts.Infrastructure.Configuration;
using StockMarketApp.Features.Currencies.Domain;
using StockMarketApp.Features.Currencies.Infrastructure;
using StockMarketApp.Features.Deals.Domain;
using StockMarketApp.Features.Deals.Infrastructure;
using StockMarketApp.Features.Industries.Domain;
using StockMarketApp.Features.Industries.Infrastructure;
using StockMarketApp.Features.Instruments.Domain;
using StockMarketApp.Features.Instruments.Infrastructure;
using StockMarketApp.Features.InstrumentTypes.Domain;
using StockMarketApp.Features.InstrumentTypes.Infrastructure;
using StockMarketApp.Features.Issuers.Domain;
using StockMarketApp.Features.Issuers.Infrastructure;
using StockMarketApp.Features.Offers.Domain;
using StockMarketApp.Features.Offers.Infrastructure;
using StockMarketApp.Features.Portfolios.Domain;
using StockMarketApp.Features.Portfolios.Infrastructure;
using StockMarketApp.Features.Traders.Domain;
using StockMarketApp.Features.Traders.Infrastructure;

namespace StockMarketApp.Shared.Infrastructure;

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
    public virtual DbSet<InstrumentType> Instrumenttypes { get; set; } = null!;
    public virtual DbSet<Issuer> Issuers { get; set; } = null!;
    public virtual DbSet<Offer> Offers { get; set; } = null!;
    public virtual DbSet<Portfolio> Portfolios { get; set; } = null!;
    public virtual DbSet<Trader> Traders { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

        }
    }
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
