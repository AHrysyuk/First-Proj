using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Stocks_Exchanges
{
    public partial class StockExchangeDbContext : DbContext
    {
        public StockExchangeDbContext()
        {
        }

        public StockExchangeDbContext(DbContextOptions<StockExchangeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exchange> Exchanges { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-NV1QAEQ\\SQLEXPRESS;Database=STOCKS_EXCHANGE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exchange>(entity =>
            {
                entity.ToTable("EXCHANGES");

                entity.HasIndex(e => e.FullName)
                    .HasName("UQ__EXCHANGE__A2E98BF299D6DEA0")
                    .IsUnique();

                entity.HasIndex(e => e.ShortName)
                    .HasName("UQ__EXCHANGE__F4E7E33E499C64F5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("FULL_NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("SHORT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.YearOfFound).HasColumnName("YEAR_OF_FOUND");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("STOCKS");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__STOCKS__D9C1FA00F6A9F2D1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("COMPANY")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ExchangeId).HasColumnName("EXCHANGE_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Exchange)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ExchangeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__STOCKS__EXCHANGE__0F624AF8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
