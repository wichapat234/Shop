using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Shop.Models.DBModels
{
    public partial class _711_databaseContext : DbContext
    {
        public _711_databaseContext()
        {
        }

        public _711_databaseContext(DbContextOptions<_711_databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<BillDetail> BillDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=0656327851;database=7-11_database", x => x.ServerVersion("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.IdBill)
                    .HasName("PRIMARY");

                entity.ToTable("bill");

                entity.Property(e => e.IdBill).HasColumnName("id_bill");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.NameBill)
                    .IsRequired()
                    .HasColumnName("name_bill")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_bin");

                entity.Property(e => e.PriceAfter).HasColumnName("price_after");

                entity.Property(e => e.PriceBefore).HasColumnName("price_before");

                entity.Property(e => e.TotalDiscount).HasColumnName("total_discount");
            });

            modelBuilder.Entity<BillDetail>(entity =>
            {
                entity.HasKey(e => e.IdBillDetail)
                    .HasName("PRIMARY");

                entity.ToTable("bill_detail");

                entity.HasIndex(e => e.IdBill)
                    .HasName("id_bill_idx");

                entity.HasIndex(e => e.IdProduct)
                    .HasName("fk_bill_product1_idx");

                entity.Property(e => e.IdBillDetail).HasColumnName("id_bill_detail");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.IdBill).HasColumnName("id_bill");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.LastPrice).HasColumnName("last_price");

                entity.Property(e => e.TotalPrice).HasColumnName("total_price");

                entity.HasOne(d => d.IdBillNavigation)
                    .WithMany(p => p.BillDetail)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_bill");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.BillDetail)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.IdProduct)
                    .HasName("idProduct_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdUnit)
                    .HasName("IdNoun_idx");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdUnit).HasColumnName("id_unit");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdUnit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdNoun");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.IdUnit)
                    .HasName("PRIMARY");

                entity.ToTable("unit");

                entity.HasComment("คำนาม");

                entity.HasIndex(e => e.IdUnit)
                    .HasName("idNoun_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUnit).HasColumnName("id_unit");

                entity.Property(e => e.NameUnit)
                    .IsRequired()
                    .HasColumnName("name_unit")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
