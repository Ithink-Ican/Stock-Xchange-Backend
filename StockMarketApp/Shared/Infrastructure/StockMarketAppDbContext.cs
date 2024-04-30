using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockMarketApp.Features.Accounts.Domain;
using StockMarketApp.Features.Currencies.Domain;
using StockMarketApp.Features.Deals.Domain;
using StockMarketApp.Features.Industries.Domain;
using StockMarketApp.Features.Instruments.Domain;
using StockMarketApp.Features.InstrumentTypes.Domain;
using StockMarketApp.Features.Issuers.Domain;
using StockMarketApp.Features.Offers.Domain;
using StockMarketApp.Features.Potfolios.Domain;
using StockMarketApp.Features.Traders.Domain;

namespace StockMarketApp.Shared.Infrastructure;

public class StockMarketAppDbContext : DbContext
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
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=StockExchange; User Id = postgres; Password = WRTh379Chmpns!;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.ApplyConfiguration<Account>
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("account");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Balance)
                .HasColumnType("money")
                .HasColumnName("balance");

            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

            entity.Property(e => e.TraderId).HasColumnName("trader_id");

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_currency_id_fkey");

            entity.HasOne(d => d.Trader)
                .WithMany(p => p.Accounts)
                .HasForeignKey(d => d.TraderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("account_trader_id_fkey");
        });

        modelBuilder.Entity<Appuser>(entity =>
        {
            entity.ToTable("appuser");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("first_name");

            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("last_name");

            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .HasColumnName("middle_name");

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");

            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(100)
                .HasColumnName("phone_number");

            entity.Property(e => e.SignupDate).HasColumnName("signup_date");

            entity.Property(e => e.UserType).HasColumnName("user_type");

            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.UserTypeNavigation)
                .WithMany(p => p.Appusers)
                .HasForeignKey(d => d.UserType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appuser_user_type_fkey");
        });

        modelBuilder.Entity<Appusertype>(entity =>
        {
            entity.ToTable("appusertype");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comment");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");

            entity.Property(e => e.CommentText).HasColumnName("comment_text");

            entity.Property(e => e.DatePosted).HasColumnName("date_posted");

            entity.HasOne(d => d.Author)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comment_author_fkey");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("currency");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.Property(e => e.ChrCode)
                .HasMaxLength(30)
                .HasColumnName("chr_code");

            entity.Property(e => e.IntCode).HasColumnName("int_code");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.Property(e => e.Rate)
                .HasColumnType("money")
                .HasColumnName("rate");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.ToTable("deal");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.BuyOfferId).HasColumnName("buy_offer_id");

            entity.Property(e => e.DealDate).HasColumnName("deal_date");

            entity.Property(e => e.SellOfferId).HasColumnName("sell_offer_id");

            entity.HasOne(d => d.BuyOffer)
                .WithMany(p => p.DealBuyOffers)
                .HasForeignKey(d => d.BuyOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deal_buy_offer_id_fkey");

            entity.HasOne(d => d.SellOffer)
                .WithMany(p => p.DealSellOffers)
                .HasForeignKey(d => d.SellOfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deal_sell_offer_id_fkey");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.ToTable("industry");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Instrument>(entity =>
        {
            entity.ToTable("instrument");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("nextval('stock_id_seq'::regclass)");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .HasColumnName("code");

            entity.Property(e => e.IndustryId).HasColumnName("industry_id");

            entity.Property(e => e.IsActive).HasColumnName("is_active");

            entity.Property(e => e.Isin)
                .HasMaxLength(100)
                .HasColumnName("isin");

            entity.Property(e => e.SubInstrument).HasColumnName("sub_instrument");

            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Industry)
                .WithMany(p => p.Instruments)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stock_industry_id_fkey");

            entity.HasOne(d => d.SubInstrumentNavigation)
                .WithMany(p => p.InverseSubInstrumentNavigation)
                .HasForeignKey(d => d.SubInstrument)
                .HasConstraintName("instrument_sub_instrument_fkey");

            entity.HasOne(d => d.Type)
                .WithMany(p => p.Instruments)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("instrument_type_id_fkey");
        });

        modelBuilder.Entity<Instrumenttype>(entity =>
        {
            entity.ToTable("instrumenttype");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Issuer>(entity =>
        {
            entity.ToTable("issuer");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Comment).HasColumnName("comment");

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.CommentNavigation)
                .WithMany(p => p.Issuers)
                .HasForeignKey(d => d.Comment)
                .HasConstraintName("issuer_comment_fkey");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.ToTable("offer");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

            entity.Property(e => e.IsSale).HasColumnName("is_sale");

            entity.Property(e => e.PlacementDate).HasColumnName("placement_date");

            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.Property(e => e.StockId).HasColumnName("stock_id");

            entity.Property(e => e.TraderId).HasColumnName("trader_id");

            entity.HasOne(d => d.Currency)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_currency_id_fkey");

            entity.HasOne(d => d.Stock)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.StockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_stock_id_fkey");

            entity.HasOne(d => d.Trader)
                .WithMany(p => p.Offers)
                .HasForeignKey(d => d.TraderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("offer_trader_id_fkey");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.ToTable("portfolio");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.Property(e => e.InstrumentId).HasColumnName("instrument_id");

            entity.Property(e => e.TraderId).HasColumnName("trader_id");

            entity.HasOne(d => d.Instrument)
                .WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.InstrumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("portfolio_instrument_id_fkey");

            entity.HasOne(d => d.Trader)
                .WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.TraderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("portfolio_trader_id_fkey");
        });

        modelBuilder.Entity<Trader>(entity =>
        {
            entity.ToTable("trader");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Inn)
                .HasMaxLength(100)
                .HasColumnName("inn");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Traders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trader_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
