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

        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Diagnosticmaster> Diagnosticmasters { get; set; }
        public virtual DbSet<Doctorsdesignation> Doctorsdesignations { get; set; }
        public virtual DbSet<Errorlog> Errorlogs { get; set; }
        public virtual DbSet<Hospitallocation> Hospitallocations { get; set; }
        public virtual DbSet<Hospitaltenant> Hospitaltenants { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("audit");

                entity.Property(e => e.Auditid)
                    .ValueGeneratedNever()
                    .HasColumnName("auditid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createddate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createddate");

                entity.Property(e => e.Modifieddate).HasColumnType("timestamp without time zone");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Cityname)
                    .HasMaxLength(300)
                    .HasColumnName("cityname");

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.Stateid)
                    .HasConstraintName("states_stateid_fkey");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Countryname)
                    .HasMaxLength(300)
                    .HasColumnName("countryname");
            });

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
                entity.HasKey(e => e.Errorid)
                    .HasName("errorlog_pkey");

                entity.ToTable("errorlog");

                entity.Property(e => e.Errorid).HasColumnName("errorid");

                entity.Property(e => e.Creadteddate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("creadteddate")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Errorcontroller)
                    .HasMaxLength(300)
                    .HasColumnName("errorcontroller");

                entity.Property(e => e.Errormessage)
                    .HasMaxLength(3000)
                    .HasColumnName("errormessage");

                entity.Property(e => e.Errormethodname)
                    .HasMaxLength(300)
                    .HasColumnName("errormethodname");
            });

            modelBuilder.Entity<Hospitallocation>(entity =>
            {
                entity.ToTable("hospitallocation");

                entity.Property(e => e.Hospitallocationid).HasColumnName("hospitallocationid");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Address1)
                    .HasMaxLength(100)
                    .HasColumnName("address1");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Hospitallocation1)
                    .HasMaxLength(300)
                    .HasColumnName("hospitallocation");

                entity.Property(e => e.Hospitaltenantid).HasColumnName("hospitaltenantid");

                entity.Property(e => e.Hospitaluniqueid)
                    .HasMaxLength(300)
                    .HasColumnName("hospitaluniqueid");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modifiedon");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(100)
                    .HasColumnName("phonenumber");

                entity.HasOne(d => d.Hospitaltenant)
                    .WithMany(p => p.Hospitallocations)
                    .HasForeignKey(d => d.Hospitaltenantid)
                    .HasConstraintName("hospitaltenant_hospitaltenantid_fkey");
            });

            modelBuilder.Entity<Hospitaltenant>(entity =>
            {
                entity.ToTable("hospitaltenant");

                entity.Property(e => e.Hospitaltenantid).HasColumnName("hospitaltenantid");

                entity.Property(e => e.Countrycode)
                    .HasMaxLength(20)
                    .HasColumnName("countrycode");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdon")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Hospitalname)
                    .HasMaxLength(300)
                    .HasColumnName("hospitalname");

                entity.Property(e => e.Hospitaluniqueid)
                    .HasMaxLength(300)
                    .HasColumnName("hospitaluniqueid");

                entity.Property(e => e.Isactive)
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("modifiedon");

                entity.Property(e => e.Stateid).HasColumnName("stateid");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patient");

                entity.Property(e => e.Patientid)
                    .ValueGeneratedNever()
                    .HasColumnName("patientid");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(100)
                    .HasColumnName("emailid");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("firstname");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("gender");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phonenumber)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("phonenumber");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(300)
                    .HasColumnName("rolename");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("states");

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Statename)
                    .HasMaxLength(300)
                    .HasColumnName("statename");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("country_countryid_fkey");
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

            modelBuilder.HasSequence("sequence_for_alpha_numeric");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
