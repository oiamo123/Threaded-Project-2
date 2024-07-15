using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThreadedProject2.Models;

public partial class TravelExpertsContext : DbContext
{
    public TravelExpertsContext()
    {
    }

    public TravelExpertsContext(DbContextOptions<TravelExpertsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductsSupplier> ProductsSuppliers { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierContact> SupplierContacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-EIT06H1F\\SQLEXPRESS;Initial Catalog=TravelExperts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.PackageId)
                .HasName("aaaaaPackages_PK")
                .IsClustered(false);

            entity.Property(e => e.PkgAgencyCommission).HasDefaultValue(0m);

            entity.HasMany(d => d.ProductSuppliers).WithMany(p => p.Packages)
                .UsingEntity<Dictionary<string, object>>(
                    "PackagesProductsSupplier",
                    r => r.HasOne<ProductsSupplier>().WithMany()
                        .HasForeignKey("ProductSupplierId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Packages_Products_Supplie_FK01"),
                    l => l.HasOne<Package>().WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Packages_Products_Supplie_FK00"),
                    j =>
                    {
                        j.HasKey("PackageId", "ProductSupplierId")
                            .HasName("aaaaaPackages_Products_Suppliers_PK")
                            .IsClustered(false);
                        j.ToTable("Packages_Products_Suppliers");
                        j.HasIndex(new[] { "PackageId" }, "PackagesPackages_Products_Suppliers");
                        j.HasIndex(new[] { "ProductSupplierId" }, "ProductSupplierId");
                        j.HasIndex(new[] { "ProductSupplierId" }, "Products_SuppliersPackages_Products_Suppliers");
                    });
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId)
                .HasName("aaaaaProducts_PK")
                .IsClustered(false);
        });

        modelBuilder.Entity<ProductsSupplier>(entity =>
        {
            entity.HasKey(e => e.ProductSupplierId)
                .HasName("aaaaaProducts_Suppliers_PK")
                .IsClustered(false);

            entity.Property(e => e.ProductId).HasDefaultValue(0);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsSuppliers).HasConstraintName("Products_Suppliers_FK00");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ProductsSuppliers).HasConstraintName("Products_Suppliers_FK01");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId)
                .HasName("aaaaaSuppliers_PK")
                .IsClustered(false);
        });

        modelBuilder.Entity<SupplierContact>(entity =>
        {
            entity.HasKey(e => e.SupplierContactId)
                .HasName("aaaaaSupplierContacts_PK")
                .IsClustered(false);

            entity.Property(e => e.SupplierContactId).ValueGeneratedNever();
            entity.Property(e => e.SupplierId).HasDefaultValue(0);

            entity.HasOne(d => d.Supplier).WithMany(p => p.SupplierContacts).HasConstraintName("SupplierContacts_FK01");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
