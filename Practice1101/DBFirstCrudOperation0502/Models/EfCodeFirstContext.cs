using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DBFirstCrudOperation0502.Models
{
    public partial class EfCodeFirstContext : DbContext
    {
        public EfCodeFirstContext()
        {
        }

        public EfCodeFirstContext(DbContextOptions<EfCodeFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual DbSet<EmployeePayHistory> EmployeePayHistories { get; set; }
        public virtual DbSet<JobCandidate> JobCandidates { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<SalesPerson> SalesPeople { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-7QBD7T4;Database=EfCodeFirst;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.BusinessEntityId);

                entity.ToTable("Employee");

                entity.HasIndex(e => e.PersonId, "IX_Employee_PersonID");

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.Property(e => e.LoginId).HasColumnName("LoginID");

                entity.Property(e => e.NationalIdnumber).HasColumnName("NationalIDNumber");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PersonId);
            });

            modelBuilder.Entity<EmployeeDepartment>(entity =>
            {
                entity.ToTable("EmployeeDepartment");

                entity.HasIndex(e => e.DepartmentId, "IX_EmployeeDepartment_DepartmentID");

                entity.HasIndex(e => e.EmployeeBusinessEntityId, "IX_EmployeeDepartment_EmployeeBusinessEntityID");

                entity.HasIndex(e => e.ShiftId, "IX_EmployeeDepartment_ShiftID");

                entity.Property(e => e.EmployeeDepartmentId).HasColumnName("EmployeeDepartmentID");

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.EmployeeBusinessEntityId).HasColumnName("EmployeeBusinessEntityID");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.EmployeeBusinessEntity)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.EmployeeBusinessEntityId);

                entity.HasOne(d => d.Shift)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.ShiftId);
            });

            modelBuilder.Entity<EmployeePayHistory>(entity =>
            {
                entity.ToTable("EmployeePayHistory");

                entity.HasIndex(e => e.EmployeeBusinessEntityId, "IX_EmployeePayHistory_EmployeeBusinessEntityID");

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.Property(e => e.EmployeeBusinessEntityId).HasColumnName("EmployeeBusinessEntityID");

                entity.HasOne(d => d.EmployeeBusinessEntity)
                    .WithMany(p => p.EmployeePayHistories)
                    .HasForeignKey(d => d.EmployeeBusinessEntityId);
            });

            modelBuilder.Entity<JobCandidate>(entity =>
            {
                entity.ToTable("JobCandidate");

                entity.HasIndex(e => e.EmployeeBusinessEntityId, "IX_JobCandidate_EmployeeBusinessEntityID");

                entity.Property(e => e.JobCandidateId).HasColumnName("JobCandidateID");

                entity.Property(e => e.BusinessEntityId).HasColumnName("BusinessEntityID");

                entity.Property(e => e.EmployeeBusinessEntityId).HasColumnName("EmployeeBusinessEntityID");

                entity.HasOne(d => d.EmployeeBusinessEntity)
                    .WithMany(p => p.JobCandidates)
                    .HasForeignKey(d => d.EmployeeBusinessEntityId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.PersonId).HasColumnName("PersonID");
            });

            modelBuilder.Entity<SalesPerson>(entity =>
            {
                entity.ToTable("SalesPerson");

                entity.HasIndex(e => e.EmployeeBusinessEntityId, "IX_SalesPerson_EmployeeBusinessEntityID");

                entity.Property(e => e.SalesPersonId).HasColumnName("SalesPersonID");

                entity.Property(e => e.BusinessEntitiId).HasColumnName("BusinessEntitiID");

                entity.Property(e => e.EmployeeBusinessEntityId).HasColumnName("EmployeeBusinessEntityID");

                entity.HasOne(d => d.EmployeeBusinessEntity)
                    .WithMany(p => p.SalesPeople)
                    .HasForeignKey(d => d.EmployeeBusinessEntityId);
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
