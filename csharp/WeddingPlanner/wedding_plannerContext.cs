using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WeddingPlanner
{
    public partial class wedding_plannerContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Rsvps> Rsvps { get; set; }
        public virtual DbSet<Weddings> Weddings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1;User Id=root;Password=root;Database=wedding_planner");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId_4");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Birthdate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.Fname)
                    .HasColumnName("FName")
                    .HasMaxLength(256);

                entity.Property(e => e.Lname)
                    .HasColumnName("LName")
                    .HasMaxLength(256);

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(95)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Rsvps>(entity =>
            {
                entity.HasKey(e => e.RsvpId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.WeddingId);

                entity.Property(e => e.RsvpId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.WeddingId).HasColumnType("int(11)");

                entity.HasOne(d => d.Wedding)
                    .WithMany(p => p.Rsvps)
                    .HasForeignKey(d => d.WeddingId);
            });

            modelBuilder.Entity<Weddings>(entity =>
            {
                entity.HasKey(e => e.WeddingId);

                entity.HasIndex(e => e.UserId);

                entity.HasIndex(e => e.WeddingId)
                    .HasName("WeddingId_3");

                entity.Property(e => e.WeddingId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserId).HasColumnType("int(11)");
            });
        }
    }
}
