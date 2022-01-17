using System;
using FruitStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FruitStore.DAL.EF
{
    public partial class fruitstoreContext : DbContext
    {
        public fruitstoreContext()
        {
        }

        public fruitstoreContext(DbContextOptions<fruitstoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartDetail> CartDetail { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Fruit> Fruit { get; set; }
        public virtual DbSet<Infor> Infor { get; set; }
        public virtual DbSet<Origin> Origin { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OA32JNB\\SQLEXPRESS;Database=fruitstore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CusId).HasColumnName("cus_id");
                entity.Property(e => e.create_date).HasColumnName("create_date");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CusId)
                    .HasConstraintName("FK__cart__cus_id__59FA5E80");
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.ToTable("cart_detail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Ispaid).HasColumnName("ispaid");

                entity.Property(e => e.OrderStatus).HasColumnName("order_status");

                entity.Property(e => e.Pric).HasColumnName("pric");

                entity.Property(e => e.ProId).HasColumnName("pro_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartDetail)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__cart_deta__cart___5CD6CB2B");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.CartDetail)
                    .HasForeignKey(d => d.ProId)
                    .HasConstraintName("FK__cart_deta__pro_i__5DCAEF64");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("nvarchar(max)")
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Addr)
                    .HasColumnName("addr")
                    .HasColumnType("nvarchar(max)")
                    .IsUnicode(true);

                entity.Property(e => e.Phonenumber)
                    .HasColumnName("phonenumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.ToTable("fruit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descrip)
                    .HasColumnName("descrip")
                    .HasColumnType("nvarchar(max)")
                    .IsUnicode(true);

                entity.Property(e => e.FruitName)
                    .HasColumnName("fruit_name")
                    .HasColumnType("nvarchar(max)")
                    .IsUnicode(true);

                entity.Property(e => e.IdCate).HasColumnName("id_cate");

                entity.Property(e => e.IdOrigin).HasColumnName("id_origin");

                entity.Property(e => e.IdUnit).HasColumnName("id_unit");

                entity.Property(e => e.Img)
                    .HasColumnName("img")
                    .HasColumnType("nvarchar(max)")
                    .IsUnicode(true);

                entity.Property(e => e.ImpDate)
                    .HasColumnName("imp_date")
                    .HasColumnType("date");

                entity.Property(e => e.IsImported).HasColumnName("isImported");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdCateNavigation)
                    .WithMany(p => p.Fruit)
                    .HasForeignKey(d => d.IdCate)
                    .HasConstraintName("FK__fruit__id_cate__4F7CD00D");

                entity.HasOne(d => d.IdOriginNavigation)
                    .WithMany(p => p.Fruit)
                    .HasForeignKey(d => d.IdOrigin)
                    .HasConstraintName("FK__fruit__id_origin__5165187F");

                entity.HasOne(d => d.IdUnitNavigation)
                    .WithMany(p => p.Fruit)
                    .HasForeignKey(d => d.IdUnit)
                    .HasConstraintName("FK__fruit__id_unit__5070F446");
            });

            modelBuilder.Entity<Infor>(entity =>
            {
                entity.ToTable("infor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                   .HasColumnType("nvarchar(max)")
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("origin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                   .HasColumnType("nvarchar(max)")
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("nvarchar(max)")
                    .IsUnicode(true);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
