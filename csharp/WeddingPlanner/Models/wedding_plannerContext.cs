// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore;
// using WeddingPlanner.Models;
// using WeddingPlanner.Data;
// using WeddingPlanner.Services;
// using WeddingPlanner.Controllers;

// namespace WeddingPlanner
// {
//     public class wedding_plannerContext : DbContext
//     {
//         public wedding_plannerContext(DbContextOptions<wedding_plannerContext> options)
//             : base(options)
//         {
//         }

//         public virtual DbSet<Rsvps> Rsvps { get; set; }
//         public virtual DbSet<Users> Users { get; set; }
//         public virtual DbSet<Weddings> Weddings { get; set; }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<Rsvps>(entity =>
//             {
//                 entity.HasKey(e => new { e.RsvpId, e.UserId, e.WeddingId });

//                 entity.ToTable("rsvps");

//                 entity.Property(e => e.RsvpId)
//                     .HasColumnName("rsvp_id")
//                     .HasColumnType("int(11)");

//                 entity.Property(e => e.UserId)
//                     .HasColumnName("user_id")
//                     .HasColumnType("int(11)");

//                 entity.Property(e => e.WeddingId)
//                     .HasColumnName("wedding_id")
//                     .HasColumnType("int(11)");
//             });

//             modelBuilder.Entity<Users>(entity =>
//             {
//                 entity.HasKey(e => e.UserId);

//                 entity.ToTable("users");

//                 entity.Property(e => e.UserId)
//                     .HasColumnName("user_id")
//                     .HasColumnType("int(11)")
//                     .ValueGeneratedNever();

//                 entity.Property(e => e.Email)
//                     .HasColumnName("email")
//                     .HasMaxLength(45);

//                 entity.Property(e => e.FirstName)
//                     .HasColumnName("first_name")
//                     .HasMaxLength(45);

//                 entity.Property(e => e.LastName)
//                     .HasColumnName("last_name")
//                     .HasMaxLength(45);

//                 entity.Property(e => e.Password)
//                     .HasColumnName("password")
//                     .HasMaxLength(255);
//             });

//             modelBuilder.Entity<Weddings>(entity =>
//             {
//                 entity.HasKey(e => new { e.WeddingId });

//                 entity.ToTable("weddings");

//                 entity.Property(e => e.WeddingId)
//                     .HasColumnName("wedding_id")
//                     .HasColumnType("int(11)");

//                 entity.Property(e => e.UserId)
//                     .HasColumnName("user_id")
//                     .HasColumnType("int(11)");

//                 entity.Property(e => e.Address)
//                     .HasColumnName("address")
//                     .HasMaxLength(100);

//                 entity.Property(e => e.BrideName)
//                     .HasColumnName("bride_name")
//                     .HasMaxLength(45);

//                 entity.Property(e => e.GroomName)
//                     .HasColumnName("groom_name")
//                     .HasMaxLength(45);

//                 entity.Property(e => e.Date)
//                     .HasColumnName("date")
//                     .HasColumnType("datetime");
//             });
//         }
//     }
// }
