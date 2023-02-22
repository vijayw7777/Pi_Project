using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProductDasboard1.Models
{
    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }

        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual DbSet<OrderTbl> OrderTbls { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductDiscription> ProductDiscriptions { get; set; } = null!;

        public DbSet<IndexViewModel> IndexViewModels { get; set; } = null!;
        // public object IndexViewModels { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ProductDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength();
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.ToTable("Order_Product");

                entity.Property(e => e.OrderProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_product_id");

                entity.Property(e => e.LineTotal).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Pro__Order__4316F928");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_Pro__Produ__440B1D61");
            });

            modelBuilder.Entity<OrderTbl>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderTbl__C3905BCF0FC48916");

                entity.ToTable("OrderTbl");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderTbls)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__OrderTbl__Custom__3F466844");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Catagory)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Colour)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                         .HasMaxLength(20)
                         .IsUnicode(false);

                entity.HasOne(d => d.Desc)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DescId)
                    .HasConstraintName("FK__Product__DescId__3C69FB99");
            });

            modelBuilder.Entity<ProductDiscription>(entity =>
            {
                entity.HasKey(e => e.DescId)
                    .HasName("PK__ProductD__EB5434A976FD1C84");

                entity.ToTable("ProductDiscription");

                entity.Property(e => e.DescId).ValueGeneratedNever();

                entity.Property(e => e.Discription)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<IndexViewModel>().HasNoKey().ToView(null);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
