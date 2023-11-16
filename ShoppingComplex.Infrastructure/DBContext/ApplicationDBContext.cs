using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShoppingComplex.Core.Entities;

namespace ShoppingComplex.Infrastructure.DBContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contractor> Contractors { get; set; } = null!;
        public virtual DbSet<Floor> Floors { get; set; } = null!;
        public virtual DbSet<Maintenance> Maintenances { get; set; } = null!;
        public virtual DbSet<Space> Spaces { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoreCatogory> StoreCatogories { get; set; } = null!;
        public virtual DbSet<StoreOwner> StoreOwners { get; set; } = null!;
        public virtual DbSet<StorePayment> StorePayments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-E339CMN\\SQLEXPRESS;Database=shopping_complex;Trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.ToTable("Contractor");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.ContactNo).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Floor>(entity =>
            {
                entity.ToTable("Floor");

                entity.Property(e => e.FloorNumber).IsUnicode(false);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Maintenance>(entity =>
            {
                entity.ToTable("Maintenance");

                entity.Property(e => e.EndDate).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.MaintenanceType).IsUnicode(false);

                entity.Property(e => e.StartDate).IsUnicode(false);

                entity.HasOne(d => d.ContractorNavigation)
                    .WithMany(p => p.Maintenances)
                    .HasForeignKey(d => d.Contractor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Maintenance_T_Contractor");
            });

            modelBuilder.Entity<Space>(entity =>
            {
                entity.Property(e => e.SpaceNumber).IsUnicode(false);

                entity.Property(e => e.SpaceSize).IsUnicode(false);

                entity.HasOne(d => d.FloorNavigation)
                    .WithMany(p => p.Spaces)
                    .HasForeignKey(d => d.Floor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Spaces_T_Floor");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.RentalDate).IsUnicode(false);

                entity.Property(e => e.RentalEndDate).IsUnicode(false);

                entity.Property(e => e.StoreName).IsUnicode(false);

                entity.HasOne(d => d.SpaceNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.Space)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Store_T_Spaces");

                entity.HasOne(d => d.StoreCategoryNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Store_T_StoreCatogory");

                entity.HasOne(d => d.StoreOwnerNavigation)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_Store_T_StoreOwner");
            });

            modelBuilder.Entity<StoreCatogory>(entity =>
            {
                entity.ToTable("StoreCatogory");

                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<StoreOwner>(entity =>
            {
                entity.ToTable("StoreOwner");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.ContactNo).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Nic)
                    .IsUnicode(false)
                    .HasColumnName("NIC");
            });

            modelBuilder.Entity<StorePayment>(entity =>
            {
                entity.ToTable("StorePayment");

                entity.Property(e => e.Month).IsUnicode(false);

                entity.Property(e => e.Year).IsUnicode(false);

                entity.HasOne(d => d.StoreNavigation)
                    .WithMany(p => p.StorePayments)
                    .HasForeignKey(d => d.Store)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_StorePayment_T_Store");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
