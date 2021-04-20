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
        public virtual DbSet<Noun> Noun { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SumaryBill> SumaryBill { get; set; }

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

                entity.HasIndex(e => e.IdBill)
                    .HasName("idBill_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdProduct)
                    .HasName("fk_bill_product1_idx");

                entity.HasIndex(e => e.IdsumaryBill)
                    .HasName("idsumary_bill_idx");

                entity.Property(e => e.IdBill).HasColumnName("idBill");

                entity.Property(e => e.BillNumber).HasColumnName("bill_number");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.IdsumaryBill).HasColumnName("idsumary_bill");

                entity.Property(e => e.LastPrice).HasColumnName("last_price");

                entity.Property(e => e.Totalprice).HasColumnName("totalprice");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("fk_bill_product1");

                entity.HasOne(d => d.IdsumaryBillNavigation)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.IdsumaryBill)
                    .HasConstraintName("idsumary_bill");
            });

            modelBuilder.Entity<Noun>(entity =>
            {
                entity.HasKey(e => e.IdNoun)
                    .HasName("PRIMARY");

                entity.ToTable("noun");

                entity.HasComment("คำนาม");

                entity.HasIndex(e => e.IdNoun)
                    .HasName("idNoun_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdNoun).HasColumnName("idNoun");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PRIMARY");

                entity.ToTable("product");

                entity.HasIndex(e => e.IdNoun)
                    .HasName("IdNoun_idx");

                entity.HasIndex(e => e.IdProduct)
                    .HasName("idProduct_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdProduct).HasColumnName("idProduct");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductPrice).HasColumnName("Product_price");

                entity.HasOne(d => d.IdNounNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdNoun)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IdNoun");
            });

            modelBuilder.Entity<SumaryBill>(entity =>
            {
                entity.HasKey(e => e.IdsumaryBill)
                    .HasName("PRIMARY");

                entity.ToTable("sumary_bill");

                entity.HasIndex(e => e.BillNumber)
                    .HasName("bill_number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdsumaryBill).HasColumnName("idsumary_bill");

                entity.Property(e => e.BillNumber)
                    .HasColumnName("bill_number")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.PriceAfter).HasColumnName("price_after");

                entity.Property(e => e.PriceBefore).HasColumnName("price_before");

                entity.Property(e => e.TotalDiscount).HasColumnName("total_discount");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
