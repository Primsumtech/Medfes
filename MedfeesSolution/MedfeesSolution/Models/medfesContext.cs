using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedfeesSolution.Models
{
    public partial class medfesContext : DbContext
    {
        public medfesContext()
        {
        }

        public medfesContext(DbContextOptions<medfesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .HasColumnName("address1");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.Countrycode)
                    .HasMaxLength(20)
                    .HasColumnName("countrycode");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(300)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(300)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(300)
                    .HasColumnName("middlename");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(100)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.States)
                    .HasMaxLength(50)
                    .HasColumnName("states");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
