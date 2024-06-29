using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CosmeticHealth.Models;

public partial class CosmeticHeathContext : DbContext
{
    public CosmeticHeathContext()
    {
    }

    public CosmeticHeathContext(DbContextOptions<CosmeticHeathContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<Irritant> Irritants { get; set; }

    public virtual DbSet<Problem> Problems { get; set; }

    public virtual DbSet<ProblemSymptom> ProblemSymptoms { get; set; }

    public virtual DbSet<ProblemTypeOfSkin> ProblemTypeOfSkins { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductIngredient> ProductIngredients { get; set; }

    public virtual DbSet<ProductProblem> ProductProblems { get; set; }

    public virtual DbSet<ProductShop> ProductShops { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Symptom> Symptoms { get; set; }

    public virtual DbSet<TypeOfProduct> TypeOfProducts { get; set; }

    public virtual DbSet<TypeOfSkin> TypeOfSkins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CosmeticHeath;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.DateFound).HasColumnType("date");
            entity.Property(e => e.NameBrand).HasMaxLength(100);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredient");

            entity.Property(e => e.NameIngredient).HasMaxLength(200);

            entity.HasOne(d => d.IrritantNavigation).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.Irritant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ingredient_Irritant");
        });

        modelBuilder.Entity<Irritant>(entity =>
        {
            entity.ToTable("Irritant");

            entity.Property(e => e.IrritantName).HasMaxLength(3);
        });

        modelBuilder.Entity<Problem>(entity =>
        {
            entity.ToTable("Problem");

            entity.Property(e => e.ProblemName).HasMaxLength(200);
        });

        modelBuilder.Entity<ProblemSymptom>(entity =>
        {
            entity.HasKey(e => e.ProductSyId).HasName("PK__Problem___421432B16411A2D8");

            entity.ToTable("Problem_Symptom");

            entity.HasOne(d => d.ProblemNavigation).WithMany(p => p.ProblemSymptoms)
                .HasForeignKey(d => d.Problem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Problem_Symptom_Problem");

            entity.HasOne(d => d.SymptomNavigation).WithMany(p => p.ProblemSymptoms)
                .HasForeignKey(d => d.Symptom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Problem_Symptom_Symptom");
        });

        modelBuilder.Entity<ProblemTypeOfSkin>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("PK__Problem___A1312F6EAEEE764E");

            entity.ToTable("Problem_TypeOfSkin");

            entity.HasOne(d => d.ProblemNavigation).WithMany(p => p.ProblemTypeOfSkins)
                .HasForeignKey(d => d.Problem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Problem_TypeOfSkin_Problem");

            entity.HasOne(d => d.TypeOfSkinNavigation).WithMany(p => p.ProblemTypeOfSkins)
                .HasForeignKey(d => d.TypeOfSkin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Problem_TypeOfSkin_TypeOfSkin");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.ProductName).HasMaxLength(100);

            entity.HasOne(d => d.BrandNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Brand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Brand");

            entity.HasOne(d => d.IrritantNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Irritant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Irritant");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_TypeOfProduct");

            entity.HasOne(d => d.TypeOfSkinNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.TypeOfSkin)
                .HasConstraintName("FK_Product_TypeOfSkin");
        });

        modelBuilder.Entity<ProductIngredient>(entity =>
        {
            entity.HasKey(e => e.ProductIngredientId).HasName("PK__Product___074807649E009401");

            entity.ToTable("Product_Ingredient");

            entity.HasOne(d => d.IngredientNavigation).WithMany(p => p.ProductIngredients)
                .HasForeignKey(d => d.Ingredient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Ingredient_Ingredient");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.ProductIngredients)
                .HasForeignKey(d => d.Product)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Ingredient_Product");
        });

        modelBuilder.Entity<ProductProblem>(entity =>
        {
            entity.HasKey(e => e.ProductProblemId).HasName("PK__Product___FED12AF799D05D4D");

            entity.ToTable("Product_Problem");

            entity.HasOne(d => d.ProblemNavigation).WithMany(p => p.ProductProblems)
                .HasForeignKey(d => d.Problem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Problem_Problem");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.ProductProblems)
                .HasForeignKey(d => d.Product)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Problem_Product");
        });

        modelBuilder.Entity<ProductShop>(entity =>
        {
            entity.HasKey(e => e.ProductShopId).HasName("PK__Product___5F6DB25ADD3D7B45");

            entity.ToTable("Product_Shop");

            entity.HasOne(d => d.ProductNavigation).WithMany(p => p.ProductShops)
                .HasForeignKey(d => d.Product)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Shop_Product");

            entity.HasOne(d => d.ShopNavigation).WithMany(p => p.ProductShops)
                .HasForeignKey(d => d.Shop)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Shop_Shop");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.ToTable("Shop");

            entity.Property(e => e.NameShop).HasMaxLength(100);
            entity.Property(e => e.UrAddress).HasMaxLength(200);
        });

        modelBuilder.Entity<Symptom>(entity =>
        {
            entity.ToTable("Symptom");

            entity.Property(e => e.NameSymptom).HasMaxLength(200);
        });

        modelBuilder.Entity<TypeOfProduct>(entity =>
        {
            entity.ToTable("TypeOfProduct");

            entity.Property(e => e.NameTypeOfProduct).HasMaxLength(100);
        });

        modelBuilder.Entity<TypeOfSkin>(entity =>
        {
            entity.ToTable("TypeOfSkin");

            entity.Property(e => e.TypeOfSkinName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
