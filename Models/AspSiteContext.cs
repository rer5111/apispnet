using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Apispnet.Models;

public partial class AspSiteContext : DbContext
{
    public AspSiteContext()
    {
    }

    public AspSiteContext(DbContextOptions<AspSiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartItem> CartItems { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-IM0M7ME\\SQLEXPRESS;Initial Catalog=asp_site;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.IdCart).HasName("PK__Cart__7017949005709D57");

            entity.ToTable("Cart");

            entity.HasIndex(e => new { e.OwnerId, e.ItemsId }, "UQ__Cart__23426774D5CC62B0").IsUnique();

            entity.Property(e => e.IdCart).HasColumnName("ID_cart");
            entity.Property(e => e.ItemsId).HasColumnName("items_ID");
            entity.Property(e => e.OwnerId).HasColumnName("owner_ID");
        });

        modelBuilder.Entity<CartItem>(entity =>
        {
            entity.HasKey(e => e.IdItems).HasName("PK__CartItem__BE1AA188361E0537");

            entity.Property(e => e.IdItems).HasColumnName("ID_items");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ProductId).HasColumnName("product_ID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__categori__AC5CA40E2B0DCA6D");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Title, "UQ__categori__E52A1BB3D169C3CD").IsUnique();

            entity.Property(e => e.IdCategory).HasColumnName("ID_category");
            entity.Property(e => e.Title)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Orders__89BFCD592CA57F4D");

            entity.HasIndex(e => new { e.OwnerId, e.ItemsId }, "UQ__Orders__23426774EEFA0D80").IsUnique();

            entity.Property(e => e.IdOrder).HasColumnName("ID_order");
            entity.Property(e => e.ItemsId).HasColumnName("items_ID");
            entity.Property(e => e.OwnerId).HasColumnName("owner_ID");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.IdItems).HasName("PK__OrderIte__BE1AA18843A4F3B9");

            entity.Property(e => e.IdItems).HasColumnName("ID_items");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.ProductId).HasColumnName("product_ID");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__products__FD7FEC23725328A4");

            entity.ToTable("products");

            entity.HasIndex(e => e.Title, "UQ__products__E52A1BB32E66F9C6").IsUnique();

            entity.Property(e => e.IdProduct).HasColumnName("ID_product");
            entity.Property(e => e.CategoryId).HasColumnName("category_ID");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.Img)
                .HasMaxLength(256)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Title)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__roles__45DFFBDBE33BFDBB");

            entity.ToTable("roles");

            entity.HasIndex(e => e.Title, "UQ__roles__E52A1BB3515295B3").IsUnique();

            entity.Property(e => e.IdRole).HasColumnName("ID_role");
            entity.Property(e => e.Title)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__users__D7B4671E677D94B2");

            entity.ToTable("users");

            entity.HasIndex(e => e.UsernameHash, "UQ__users__D1ED50DCA7816C72").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("ID_user");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.RoleId).HasColumnName("role_ID");
            entity.Property(e => e.UsernameHash)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username_hash");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
