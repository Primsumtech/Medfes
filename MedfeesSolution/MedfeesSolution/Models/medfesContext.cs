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

        public virtual DbSet<Diagnosticmaster> Diagnosticmasters { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Doctorsdesignation> Doctorsdesignations { get; set; } = null!;
        public virtual DbSet<Errorlog> Errorlogs { get; set; } = null!;
        public virtual DbSet<Hospitaltenant> Hospitaltenants { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
           }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnosticmaster>(entity =>
            {
                entity.HasKey(e => e.Diagnosticid)
                    .HasName("diagnosticmaster_pkey");

                entity.ToTable("diagnosticmaster");

                entity.Property(e => e.Diagnosticid)
                    .HasColumnType("character varying")
                    .HasColumnName("diagnosticid")
                    .HasDefaultValueSql("to_char(nextval('sequence_for_alpha_numeric'::regclass), '\"LAB\"fm000000'::text)");

                entity.Property(e => e.Diagnosticname)
                    .HasColumnType("character varying")
                    .HasColumnName("diagnosticname");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctors");

                entity.Property(e => e.Doctorid).HasColumnName("doctorid");

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

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Designation)
                    .HasMaxLength(300)
                    .HasColumnName("designation");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(300)
                    .HasColumnName("firstname");

                entity.Property(e => e.Hospitallocation)
                    .HasMaxLength(300)
                    .HasColumnName("hospitallocation");

                entity.Property(e => e.Hospitaltenantid).HasColumnName("hospitaltenantid");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(300)
                    .HasColumnName("lastname");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Midlename)
                    .HasMaxLength(300)
                    .HasColumnName("midlename");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modifiedon");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(100)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.States)
                    .HasMaxLength(50)
                    .HasColumnName("states");

                entity.HasOne(d => d.Hospitaltenant)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.Hospitaltenantid)
                    .HasConstraintName("doctors_hospitaltenantid_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("doctors_roleid_fkey");
            });

            modelBuilder.Entity<Doctorsdesignation>(entity =>
            {
                entity.HasKey(e => e.Docdesigid)
                    .HasName("docdesigid_pkey");

                entity.ToTable("doctorsdesignation");

                entity.Property(e => e.Docdesigid).HasColumnName("docdesigid");

                entity.Property(e => e.Designationname)
                    .HasMaxLength(300)
                    .HasColumnName("designationname");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");
            });

            modelBuilder.Entity<Errorlog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("errorlog");

                entity.Property(e => e.Creadteddate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("creadteddate")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Errorcontroller)
                    .HasMaxLength(300)
                    .HasColumnName("errorcontroller");

                entity.Property(e => e.Errorid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("errorid");

                entity.Property(e => e.Errormessage)
                    .HasMaxLength(3000)
                    .HasColumnName("errormessage");

                entity.Property(e => e.Errormethodname)
                    .HasMaxLength(300)
                    .HasColumnName("errormethodname");
            });

            modelBuilder.Entity<Hospitaltenant>(entity =>
            {
                entity.ToTable("hospitaltenant");

                entity.Property(e => e.Hospitaltenantid).HasColumnName("hospitaltenantid");

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

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Hospitallocation)
                    .HasMaxLength(300)
                    .HasColumnName("hospitallocation");

                entity.Property(e => e.Hospitalname)
                    .HasMaxLength(300)
                    .HasColumnName("hospitalname");

                entity.Property(e => e.Hospitaluniqueid)
                    .HasMaxLength(300)
                    .HasColumnName("hospitaluniqueid");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modifiedon");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(100)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.States)
                    .HasMaxLength(50)
                    .HasColumnName("states");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(300)
                    .HasColumnName("rolename");
            });

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

                entity.Property(e => e.Email)
                    .HasMaxLength(300)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(300)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(300)
                    .HasColumnName("lastname");

                entity.Property(e => e.Middlename)
                    .HasMaxLength(300)
                    .HasColumnName("middlename");

                entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");

                entity.Property(e => e.Passwordsalt).HasColumnName("passwordsalt");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(100)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.States)
                    .HasMaxLength(50)
                    .HasColumnName("states");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("users_roleid_fkey");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.Property(e => e.Staffid).HasColumnName("staffid");

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

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Designation)
                    .HasMaxLength(300)
                    .HasColumnName("designation");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(300)
                    .HasColumnName("firstname");

                entity.Property(e => e.Hospitallocation)
                    .HasMaxLength(300)
                    .HasColumnName("hospitallocation");

                entity.Property(e => e.Hospitaltenantid).HasColumnName("hospitaltenantid");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(300)
                    .HasColumnName("lastname");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Midlename)
                    .HasMaxLength(300)
                    .HasColumnName("midlename");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modifiedon");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(100)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.States)
                    .HasMaxLength(50)
                    .HasColumnName("states");

                entity.HasOne(d => d.Hospitaltenant)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.Hospitaltenantid)
                    .HasConstraintName("staff_hospitaltenantid_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.Roleid)
                    .HasConstraintName("staff_roleid_fkey");
            });

            modelBuilder.HasSequence("sequence_for_alpha_numeric");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
