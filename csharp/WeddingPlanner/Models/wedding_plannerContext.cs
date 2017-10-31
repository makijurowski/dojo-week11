using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using WeddingPlanner.Data;
using WeddingPlanner.Services;
using WeddingPlanner.Controllers;

namespace WeddingPlanner
{
    public class wedding_plannerContext : ApplicationDbContext
    {
        public new virtual DbSet<Rsvps> Rsvps { get; set; }
        public new virtual DbSet<Users> Users { get; set; }
        public new virtual DbSet<Weddings> Weddings { get; set; }

        public wedding_plannerContext()
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rsvps>(entity =>
            {
                entity.HasKey(e => new { e.RsvpId, e.GuestId, e.WeddingId, e.Weddings });

                entity.ToTable("rsvps");

                entity.HasIndex(e => e.GuestId)
                    .HasName("fk_rsvps_users1_idx");

                entity.HasIndex(e => new { e.WeddingId, e.GuestId })
                    .HasName("fk_rsvps_weddings1_idx");

                entity.Property(e => e.RsvpId)
                    .HasColumnName("rsvp_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GuestId)
                    .HasColumnName("users_guest_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WeddingId)
                    .HasColumnName("wedding_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GuestId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Weddings)
                    .WithMany(p => p.Guests)
                    .HasForeignKey(d => new { d.WeddingId, d.GuestId })
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
                entity.HasKey(e => new { e.WeddingId, e.GuestId });

                entity.ToTable("weddings");

                entity.HasIndex(e => e.GuestId)
                    .HasName("fk_weddings_users_idx");

                entity.Property(e => e.WeddingId)
                    .HasColumnName("wedding_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GuestId)
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
                    .HasForeignKey(d => d.GuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_weddings_users");
            });
        }
    }
}
