using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SecondDbFirstAfterFluentApi.Models
{
    public partial class EfCodeFirstWithFluentApiContext : DbContext
    {
        public EfCodeFirstWithFluentApiContext()
        {
        }

        public EfCodeFirstWithFluentApiContext(DbContextOptions<EfCodeFirstWithFluentApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeDepartmen> EmployeeDepartmen { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }
        public virtual DbSet<JobCandidate> JobCandidate { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<SalesPerson> SalesPerson { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7QBD7T4;Database=EfCodeFirstWithFluentApi;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.HasIndex(e => e.Name, "IX_Department_Name")
                    .IsUnique()
                    .HasFilter("([Name] IS NOT NULL)");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId);

                entity.ToTable("Employee");

                entity.HasIndex(e => e.LoginId, "IX_Employee_LoginID")
                    .IsUnique();

                entity.HasIndex(e => e.NationalIdnumber, "IX_Employee_NationalIDNumber")
                    .IsUnique();

                entity.HasIndex(e => e.PersonId, "IX_Employee_PersonID");

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.NationalIdnumber).HasColumnName("NationalIDNumber");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<EmployeeDepartmen>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.HasIndex(e => e.BusinessEntityId, "IX_EmployeeDepartmen_BusinessEntityID");

                entity.HasIndex(e => e.ShiftId, "IX_EmployeeDepartmen_ShiftID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.BusinessEntity)
                    .WithMany(p => p.EmployeeDepartmen)
                    .HasForeignKey(d => d.BusinessEntityId);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeDepartmen)
                    .HasForeignKey(d => d.ShiftId);
            });

            modelBuilder.Entity<EmployeePayHistory>(entity =>
            {
                entity.ToTable("EmployeePayHistory");

                entity.HasIndex(e => e.BusinessEntityId, "IX_EmployeePayHistory_BusinessEntityID")
                    .IsUnique();

                entity.HasIndex(e => e.RateChangeDate, "IX_EmployeePayHistory_RateChangeDate")
                    .IsUnique();

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.HasOne(d => d.BusinessEntity)
                    .WithOne(p => p.EmployeePayHistory)
                    .HasForeignKey<EmployeePayHistory>(d => d.BusinessEntityId);
            });

            modelBuilder.Entity<JobCandidate>(entity =>
            {
                entity.ToTable("JobCandidate");

                entity.HasIndex(e => e.BusinessEntityId, "IX_JobCandidate_BusinessEntityID");

                entity.Property(e => e.JobCandidateId).HasColumnName("JobCandidateID");

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.HasOne(d => d.BusinessEntity)
                    .WithMany(p => p.JobCandidates)
                    .HasForeignKey(d => d.BusinessEntityId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.ToTable("SalesPerson");

                entity.HasIndex(e => e.BusinessEntityId, "IX_SalesPerson_BusinessEntityID");

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.HasOne(d => d.BusinessEntity)
                    .WithMany(p => p.SalesPeople)
                    .HasForeignKey(d => d.BusinessEntityId);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.HasIndex(e => e.ShiftId, "IX_Shift_ShiftID")
                    .IsUnique();

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
