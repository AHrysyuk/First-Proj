using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Stocks_Exchange
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
                    .HasName("UQ_EXCHANGE_FULLNAME") //TODO: drop in db and create named constaint
                    .IsUnique();

                entity.HasIndex(e => e.ShortName)
                    .HasName("UQ_EXCHANGE_SHORTNAME")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(30);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("FULL_NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasColumnName("SHORT_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.YearOfFound).HasColumnName("YEAR_OF_FOUND");
            });


            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ_STOCKS_NAME")
                    .IsUnique();

                entity.HasOne(d => d.Exchange)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ExchangeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STOCKS_EXCHANGE_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
