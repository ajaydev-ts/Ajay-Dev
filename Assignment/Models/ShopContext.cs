using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment.Models
{
    public partial class ShopContext : DbContext
    {
        public ShopContext()
        {
        }

        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Subcategory> Subcategories { get; set; } = null!;

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=AJAYDEVTS-991\\SQLEXPRESS;Initial Catalog=Shop;Integrated Security=True;Pooling=False");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Catid)
                    .HasName("PK__category__17B9D93E483DAAE5");

                entity.ToTable("category");

                entity.Property(e => e.Catid)
                    .ValueGeneratedNever()
                    .HasColumnName("catid");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Custid)
                    .HasName("PK__customer__973AFEFE2DD7794C");

                entity.ToTable("customer");

                entity.Property(e => e.Custid)
                    .ValueGeneratedNever()
                    .HasColumnName("custid");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("PK__orders__C2FFCF132FC88E8F");

                entity.ToTable("orders");

                entity.Property(e => e.Oid)
                    .ValueGeneratedNever()
                    .HasColumnName("oid");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.DateOfPurchase)
                    .HasColumnType("date")
                    .HasColumnName("date of purchase");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Custid)
                    .HasConstraintName("fkcustid");

                entity.HasOne(d => d.PidNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Pid)
                    .HasConstraintName("fkpid");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK__product__DD37D91AEEE32FCC");

                entity.ToTable("product");

                entity.Property(e => e.Pid)
                    .ValueGeneratedNever()
                    .HasColumnName("pid");

                entity.Property(e => e.Pname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pname");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Subcatid).HasColumnName("subcatid");

                entity.HasOne(d => d.Subcat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Subcatid)
                    .HasConstraintName("fksubcatid");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.HasKey(e => e.Subcatid)
                    .HasName("PK__subcateg__B283C12494567523");

                entity.ToTable("subcategory");

                entity.Property(e => e.Subcatid)
                    .ValueGeneratedNever()
                    .HasColumnName("subcatid");

                entity.Property(e => e.Catid).HasColumnName("catid");

                entity.Property(e => e.Subcatname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subcatname");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.Catid)
                    .HasConstraintName("fkcatid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
