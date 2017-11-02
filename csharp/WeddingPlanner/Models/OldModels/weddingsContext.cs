// using System;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata;

// namespace WeddingPlanner
// {
//     public partial class weddingsContext : DbContext
//     {
//         public virtual DbSet<Users> AspNetUsers { get; set; }
//         public virtual DbSet<Rsvps> Rsvps { get; set; }
//         public virtual DbSet<Weddings> Weddings { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseMySql("Server=127.0.0.1;User Id=root;Password=root;Database=weddings");
//             }
//         }

//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             modelBuilder.Entity<Users>().ToTable("AspNetUsers");
//             modelBuilder.Entity<Users>(entity =>
//             {
//                 entity.HasIndex(e => e.NormalizedEmail)
//                     .HasName("EmailIndex");

//                 entity.HasIndex(e => e.NormalizedUserName)
//                     .HasName("UserNameIndex")
//                     .IsUnique();

//                 entity.HasIndex(e => e.UserId)
//                     .HasName("UserId_4");

//                 entity.Property(e => e.Id).ValueGeneratedNever();

//                 entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

//                 entity.Property(e => e.Birthdate).HasColumnType("datetime");

//                 entity.Property(e => e.Email).HasMaxLength(256);

//                 entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

//                 entity.Property(e => e.Fname)
//                     .HasColumnName("FName")
//                     .HasMaxLength(256);

//                 entity.Property(e => e.Lname)
//                     .HasColumnName("LName")
//                     .HasMaxLength(256);

//                 entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

//                 entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

//                 entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

//                 entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

//                 entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

//                 entity.Property(e => e.UserId).HasColumnType("int(11)");

//                 entity.Property(e => e.UserName).HasMaxLength(256);
//             });

//             modelBuilder.Entity<Rsvps>(entity =>
//             {
//                 entity.HasKey(e => e.RsvpId);

//                 entity.HasIndex(e => e.UserId);

//                 entity.HasIndex(e => e.WeddingId);

//                 entity.Property(e => e.RsvpId)
//                     .HasColumnType("int(11)")
//                     .ValueGeneratedNever();

//                 entity.Property(e => e.UserId).HasColumnType("int(11)");

//                 entity.Property(e => e.WeddingId).HasColumnType("int(11)");

//                 entity.HasOne(d => d.Wedding)
//                     .WithMany(p => p.Rsvps)
//                     .HasForeignKey(d => d.WeddingId)
//                     .HasConstraintName("rsvps_ibfk_2");
//             });

//             modelBuilder.Entity<Weddings>(entity =>
//             {
//                 entity.HasKey(e => e.WeddingId);

//                 entity.HasIndex(e => e.UserId);

//                 entity.HasIndex(e => e.WeddingId)
//                     .HasName("WeddingId_3");

//                 entity.Property(e => e.WeddingId)
//                     .HasColumnType("int(11)")
//                     .ValueGeneratedNever();

//                 entity.Property(e => e.UserId).HasColumnType("int(11)");
//             });
//         }
//     }
// }
