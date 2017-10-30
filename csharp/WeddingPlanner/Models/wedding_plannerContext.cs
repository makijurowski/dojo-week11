using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WeddingPlanner
{
    public partial class wedding_plannerContext : DbContext
    {
        public virtual DbSet<Rsvps> Rsvps { get; set; }
        public virtual DbSet<Users> Users { get; set; }
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
            modelBuilder.Entity<Rsvps>(entity =>
            {
                entity.HasKey(e => new { e.RsvpId, e.UsersUserId, e.WeddingId, e.UserId });

                entity.ToTable("rsvps");

                entity.HasIndex(e => e.UsersUserId)
                    .HasName("fk_rsvps_users1_idx");

                entity.HasIndex(e => new { e.WeddingId, e.UserId })
                    .HasName("fk_rsvps_weddings1_idx");

                entity.Property(e => e.RsvpId)
                    .HasColumnName("rsvp_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsersUserId)
                    .HasColumnName("users_user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WeddingId)
                    .HasColumnName("wedding_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UsersUser)
                    .WithMany(p => p.Rsvps)
                    .HasForeignKey(d => d.UsersUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rsvps_users1");

                entity.HasOne(d => d.Weddings)
                    .WithMany(p => p.Rsvps)
                    .HasForeignKey(d => new { d.WeddingId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rsvps_weddings1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(45);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(45);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Weddings>(entity =>
            {
                entity.HasKey(e => new { e.WeddingId, e.UserId });

                entity.ToTable("weddings");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_weddings_users_idx");

                entity.Property(e => e.WeddingId)
                    .HasColumnName("wedding_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(100);

                entity.Property(e => e.BrideName)
                    .HasColumnName("bride_name")
                    .HasMaxLength(45);

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.GroomName)
                    .HasColumnName("groom_name")
                    .HasMaxLength(45);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Weddings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_weddings_users");
            });
        }
    }
}
