using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Asset_Management_System_Exam.Model;

public partial class AssetManagementDbContext : DbContext
{
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetType> AssetTypes { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public AssetManagementDbContext()
    {

    }

    public AssetManagementDbContext(DbContextOptions<AssetManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssetDetail> AssetDetails { get; set; }

    public virtual DbSet<AssetMain> AssetMains { get; set; }

    public virtual DbSet<AssetType> AssetType { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    public virtual DbSet<Vendor> Vendor { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-FFEBCDBH\\SQLEXPRESS;Initial Catalog=AssetManagementDB;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssetDetail>(entity =>
        {
            entity.HasKey(e => e.AssetDetailId).HasName("PK__AssetDet__876801DD225475D4");

            entity.HasIndex(e => e.SerialNumber, "UQ__AssetDet__048A0008F501124B").IsUnique();

            entity.Property(e => e.CurrentOwner).HasMaxLength(100);
            entity.Property(e => e.LastUpdated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.SerialNumber).HasMaxLength(100);
            entity.Property(e => e.WarrantyPeriod).HasMaxLength(50);
        });

        modelBuilder.Entity<AssetMain>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__AssetMai__4349235228F7A494");

            entity.ToTable("AssetMain");

            entity.Property(e => e.AssetName).HasMaxLength(100);
            entity.Property(e => e.DateAdded)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.AssetDetails).WithMany(p => p.AssetMains)
                .HasForeignKey(d => d.AssetDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetMain_AssetDetails");

            entity.HasOne(d => d.AssetType).WithMany(p => p.AssetMains)
                .HasForeignKey(d => d.AssetTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetMain_AssetType");

            entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.AssetMains)
                .HasForeignKey(d => d.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetMain_PurchaseOrder");

            entity.HasOne(d => d.Vendor).WithMany(p => p.AssetMains)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetMain_Vendor");
        });

        modelBuilder.Entity<AssetType>(entity =>
        {
            entity.HasKey(e => e.AssetTypeId).HasName("PK__AssetTyp__FD33C2C23BE36F33");

            entity.ToTable("AssetType");

            entity.HasIndex(e => e.AssetTypeName, "UQ__AssetTyp__6824772C15D2B6FD").IsUnique();

            entity.Property(e => e.AssetTypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.PurchaseOrderId).HasName("PK__Purchase__036BACA437FF4297");

            entity.ToTable("PurchaseOrder");

            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Vendor).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PurchaseOrder_Vendor");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AE5D1D893");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B6160AB306E4A").IsUnique();

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.LoginId).HasName("PK__UserLogi__4DDA28189012BB74");

            entity.ToTable("UserLogin");

            entity.HasIndex(e => e.Username, "UQ__UserLogi__536C85E4350A414C").IsUnique();

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserLogin_UserId");
        });

        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserRegi__1788CC4C78E5A25F");

            entity.ToTable("UserRegistration");

            entity.HasIndex(e => e.Username, "UQ__UserRegi__536C85E4F21E04EE").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.UserRegistrations)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRegistration_Role");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendor__FC8618F3F4587632");

            entity.ToTable("Vendor");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.ContactNumber).HasMaxLength(15);
            entity.Property(e => e.VendorName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
