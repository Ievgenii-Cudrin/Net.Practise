using CodeFirstWithFluentApiCrudOperation.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirstWithFluentApiCrudOperation.DataContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7QBD7T4;Database=EfCodeFirstWithFluentApi;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(x => x.PersonID);

            modelBuilder.Entity<Employee>().HasKey(x => x.BusinessEntityID);

            modelBuilder.Entity<Employee>()
                .HasIndex(u => u.NationalIDNumber)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasIndex(u => u.LoginID)
                .IsUnique();

            modelBuilder.Entity<Person>()
                .HasMany<Employee>(g => g.Employees)
                .WithOne(s => s.Person)
                .HasForeignKey(s => s.PersonID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobCandidate>().HasKey(x => x.JobCandidateID);

            modelBuilder.Entity<Employee>()
                .HasMany<JobCandidate>(g => g.JobCandidates)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.BusinessEntityID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<SalesPerson>().HasKey(x => x.SalesPersonID);

            modelBuilder.Entity<Employee>()
                .HasMany<SalesPerson>(g => g.SalesPersons)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.BusinessEntityID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeePayHistory>().HasKey(x => x.EmployeePayHistoryId);

            modelBuilder.Entity<EmployeePayHistory>()
                .HasIndex(u => u.BusinessEntityID)
                .IsUnique();

            modelBuilder.Entity<EmployeePayHistory>()
                .HasIndex(u => u.RateChangeDate)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasMany<EmployeePayHistory>(g => g.EmployeePayHistories)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.BusinessEntityID)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<EmployeeDepartmen>().HasKey(x => x.StartDateDocument);
            
            modelBuilder.Entity<EmployeeDepartmen>().HasKey(x => x.BusinessEntityID);

            modelBuilder.Entity<Employee>()
                .HasMany<EmployeeDepartmen>(g => g.EmployeeDepartments)
                .WithOne(s => s.Employee)
                .HasForeignKey(s => s.BusinessEntityID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Shift>().HasKey(x => x.ShiftID);

            modelBuilder.Entity<Shift>()
                .HasIndex(u => u.ShiftID)
                .IsUnique();

            modelBuilder.Entity<Shift>()
                .HasMany<EmployeeDepartmen>(g => g.EmployeeDepartments)
                .WithOne(s => s.Shift)
                .HasForeignKey(s => s.ShiftID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeDepartmen>().HasKey(x => x.ShiftID);

        }
    }
}
